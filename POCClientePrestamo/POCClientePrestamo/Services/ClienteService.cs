using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo.services
{
    public class ClienteService
    {
        private readonly GraphQLHttpClient _client;

        public ClienteService()
        {
            _client = new GraphQLHttpClient(
                "http://localhost:8080/graphql",
                new SystemTextJsonSerializer());
        }

        // 1. LISTAR CLIENTES DE UN PRÉSTAMO
        public async Task<List<ClienteData>?> ListarClientesPorPrestamoAsync(int idPrestamo)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query listarClientes ($idPrestamo: Int!) {
                        clientesPorPrestamo(idPrestamo: $idPrestamo) {
                            idCliente
                            nombreCompleto
                            cedula
                            ingresosMensuales
                            fechaNacimiento
                            idPrestamo
                            estado
                        }
                    }
                ",
                Variables = new { idPrestamo }
            };

            var response = await _client.SendQueryAsync<ResponseListaClientes>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.clientes;
        }

        // 2. LISTAR TODOS LOS CLIENTES (NUEVO)
        public async Task<List<ClienteData>?> ListarTodosClientesAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query {
                        clientes {
                            idCliente
                            nombreCompleto
                            cedula
                            ingresosMensuales
                            fechaNacimiento
                            idPrestamo
                            estado
                        }
                    }
                "
            };

            var response = await _client.SendQueryAsync<ResponseListaTodosClientes>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.clientes;
        }

        // 3. BUSCAR CLIENTE POR ID
        public async Task<ClienteData?> BuscarClientePorIdAsync(int idCliente)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query buscarCliente ($id: Int!) {
                        clientePorId(idCliente: $id) {
                            idCliente
                            nombreCompleto
                            cedula
                            ingresosMensuales
                            fechaNacimiento
                            idPrestamo
                            estado
                        }
                    }
                ",
                Variables = new { id = idCliente }
            };

            var response = await _client.SendQueryAsync<ResponseCliente>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.cliente;
        }

        // 4. INSERTAR CLIENTE
        public async Task<ClienteData?> InsertarClienteAsync(ClienteInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation addCliente ($input: ClienteInput!) {
                        addCliente(input: $input) {
                            idCliente
                            nombreCompleto
                            cedula
                            ingresosMensuales
                            fechaNacimiento
                            idPrestamo
                            estado
                        }
                    }
                ",
                Variables = new { input }
            };

            var response = await _client.SendMutationAsync<ResponseCliente>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.AddCliente;
        }

        // 5. ACTUALIZAR CLIENTE
        public async Task<ClienteData?> ActualizarClienteAsync(int idCliente, ClienteInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation actualizarCliente ($id: Int!, $input: ClienteInput!) {
                        actualizarCliente(idCliente: $id, input: $input) {
                            idCliente
                            nombreCompleto
                            cedula
                            ingresosMensuales
                            fechaNacimiento
                            idPrestamo
                            estado
                        }
                    }
                ",
                Variables = new { id = idCliente, input }
            };

            var response = await _client.SendMutationAsync<ResponseCliente>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data?.ActualizarCliente;
        }

        // 6. ELIMINAR CLIENTE
        public async Task<bool> EliminarClienteAsync(int idCliente)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation eliminarCliente ($id: Int!) {
                        eliminarCliente(idCliente: $id)
                    }
                ",
                Variables = new { id = idCliente }
            };

            var response = await _client.SendMutationAsync<DeleteClienteResponse>(request);
            if (response.Errors != null && response.Errors.Length > 0) throw new Exception(response.Errors[0].Message);
            return response.Data.EliminarCliente;
        }
    }
}