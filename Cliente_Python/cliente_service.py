import requests

class ClienteService:
    _instance = None

    def __new__(cls):
        if cls._instance is None:
            cls._instance = super(ClienteService, cls).__new__(cls)
            cls._instance.url = "http://localhost:8080/graphql"
        return cls._instance

    def _enviar(self, query, variables=None):
        response = requests.post(self.url, json={'query': query, 'variables': variables})
        data = response.json()
        if 'errors' in data:
            raise Exception(data['errors'][0]['message'])
        return data.get('data', {})

    def listar_todos_clientes(self):
        q = "query { clientes { idCliente nombreCompleto cedula ingresosMensuales fechaNacimiento idPrestamo estado } }"
        return self._enviar(q).get('clientes', [])

    def listar_clientes(self, id_p):
        q = "query ($id: Int!) { clientesPorPrestamo(idPrestamo: $id) { idCliente nombreCompleto cedula ingresosMensuales fechaNacimiento idPrestamo estado } }"
        return self._enviar(q, {"id": id_p}).get('clientesPorPrestamo', [])

    def buscar_cliente(self, id_c):
        q = "query ($id: Int!) { clientePorId(idCliente: $id) { idCliente nombreCompleto cedula ingresosMensuales fechaNacimiento idPrestamo estado } }"
        return self._enviar(q, {"id": id_c}).get('clientePorId')

    def insertar_cliente(self, input_data):
        q = "mutation ($input: ClienteInput!) { addCliente(input: $input) { idCliente } }"
        return self._enviar(q, {"input": input_data})

    def actualizar_cliente(self, id_c, input_data):
        q = "mutation ($id: Int!, $input: ClienteInput!) { actualizarCliente(idCliente: $id, input: $input) { idCliente } }"
        return self._enviar(q, {"id": id_c, "input": input_data})

    def eliminar_cliente(self, id_c):
        q = "mutation ($id: Int!) { eliminarCliente(idCliente: $id) }"
        return self._enviar(q, {"id": id_c})