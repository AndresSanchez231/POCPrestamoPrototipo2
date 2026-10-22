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

        // 🔹 LISTAR TODOS
        public async Task<List<PrestamoData>?> ListarPrestamosAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query {
                        prestamos {
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

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception(response.Errors[0].Message);

            return response.Data?.prestamos;
        }

        // 🔹 BUSCAR POR ID
        public async Task<PrestamoData?> BuscarPrestamoPorIdAsync(int idPrestamo)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query buscarPrestamoPorId ($id: Int!) {
                        prestamoPorId(idPrestamo: $id) {
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                ",
                Variables = new { id = idPrestamo }
            };

            var response = await _client.SendQueryAsync<ResponsePrestamo>(request);

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception(response.Errors[0].Message);

            return response.Data?.prestamo;
        }

        // 🔹 INSERTAR
        public async Task<PrestamoData?> InsertarPrestamoAsync(PrestamoInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation addPrestamo ($input: PrestamoInput!) {
                        addPrestamo(input: $input) {
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                ",
                Variables = new { input }
            };

            var response = await _client.SendMutationAsync<AddPrestamoResponse>(request);

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception(response.Errors[0].Message);

            return response.Data?.AddPrestamo;
        }

        // 🔹 ACTUALIZAR
        public async Task<PrestamoData?> ActualizarPrestamoAsync(int idPrestamo, PrestamoInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation actualizarPrestamo ($id: Int!, $input: PrestamoInput!) {
                        actualizarPrestamo(idPrestamo: $id, input: $input) {
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                ",
                Variables = new { id = idPrestamo, input }
            };

            var response = await _client.SendMutationAsync<AddPrestamoResponse>(request);

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception(response.Errors[0].Message);

            return response.Data?.ActualizarPrestamo;
        }

        // 🔹 ELIMINAR (borrado lógico)
        public async Task<bool> EliminarPrestamoAsync(int idPrestamo)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation eliminarPrestamo ($id: Int!) {
                        eliminarPrestamo(idPrestamo: $id)
                    }
                ",
                Variables = new { id = idPrestamo }
            };

            var response = await _client.SendMutationAsync<DeletePrestamoResponse>(request);

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception(response.Errors[0].Message);

            return response.Data.EliminarPrestamo;
        }

        // 🔹 FILTRAR POR TIPO DE INMUEBLE
        public async Task<List<PrestamoData>?> ListarPorTipoInmuebleAsync(string tipoInmueble)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query filtrarPorTipo ($tipoInmueble: String!) {
                        prestamosPorTipoInmueble(tipoInmueble: $tipoInmueble) {
                            idPrestamo
                            monto
                            tasaIntereses
                            fechaRegistro
                            tipo
                            estado
                        }
                    }
                ",
                Variables = new { tipoInmueble }
            };

            var response = await _client.SendQueryAsync<ResponseListaPorTipo>(request);

            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception(response.Errors[0].Message);

            return response.Data?.prestamos;
        }
    }
}