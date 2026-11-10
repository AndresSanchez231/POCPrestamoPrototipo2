using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo.services
{
    public class PrestamoService
    {
        private readonly GraphQLHttpClient _client;

        public PrestamoService()
        {
            _client = new GraphQLHttpClient(
                "http://localhost:8080/graphql",
                new SystemTextJsonSerializer());
        }

        // 1. LISTAR PRÉSTAMOS
        public async Task<List<PrestamoData>?> ListarPrestamosAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query {
                        prestamos {
                            _id
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                "
            };

            var response = await _client.SendQueryAsync<ResponseListaPrestamos>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.prestamos;
        }

        // 2. BUSCAR PRÉSTAMO POR ID
        public async Task<PrestamoData?> BuscarPrestamoPorIdAsync(string idPrestamo)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query buscarPrestamo ($idPrestamo: String!) {
                        prestamoPorId(idPrestamo: $idPrestamo) {
                            _id
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                ",
                Variables = new { idPrestamo }
            };

            var response = await _client.SendQueryAsync<ResponsePrestamo>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.prestamo;
        }

        // 3. LISTAR POR TIPO (Método que faltaba)
        public async Task<List<PrestamoData>?> ListarPorTipoInmuebleAsync(string tipo)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query listarPorTipo ($tipo: String!) {
                        prestamosPorTipoInmueble(tipoInmueble: $tipo) {
                            _id
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                ",
                Variables = new { tipo }
            };

            var response = await _client.SendQueryAsync<ResponseListaPorTipo>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.prestamos;
        }

        // 4. INSERTAR PRÉSTAMO
        public async Task<PrestamoData?> InsertarPrestamoAsync(PrestamoInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation addPrestamo ($input: PrestamoInput!) {
                        addPrestamo(input: $input) {
                            idPrestamo
                        }
                    }
                ",
                Variables = new { input }
            };

            var response = await _client.SendMutationAsync<AddPrestamoResponse>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.AddPrestamo;
        }

        // 5. ACTUALIZAR PRÉSTAMO
        public async Task<PrestamoData?> ActualizarPrestamoAsync(string idPrestamo, PrestamoInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation actualizarPrestamo ($idPrestamo: String!, $input: PrestamoInput!) {
                        actualizarPrestamo(idPrestamo: $idPrestamo, input: $input) {
                            idPrestamo
                        }
                    }
                ",
                Variables = new { idPrestamo, input }
            };

            var response = await _client.SendMutationAsync<AddPrestamoResponse>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.ActualizarPrestamo;
        }

        // 6. ELIMINAR PRÉSTAMO
        public async Task<bool> EliminarPrestamoAsync(string idPrestamo)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation eliminarPrestamo ($idPrestamo: String!) {
                        eliminarPrestamo(idPrestamo: $idPrestamo)
                    }
                ",
                Variables = new { idPrestamo }
            };

            var response = await _client.SendMutationAsync<DeletePrestamoResponse>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data.EliminarPrestamo;
        }
    }
}