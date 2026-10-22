import requests

class PrestamoService:
    _instance = None

    def __new__(cls):
        if cls._instance is None:
            cls._instance = super(PrestamoService, cls).__new__(cls)
            cls._instance.url = "http://localhost:8080/graphql"
        return cls._instance

    def _enviar(self, query, variables=None):
        response = requests.post(self.url, json={'query': query, 'variables': variables})
        data = response.json()
        if 'errors' in data:
            raise Exception(data['errors'][0]['message'])
        return data.get('data', {})

    def listar_prestamos(self):
        q = "query { prestamos { idPrestamo monto tasaIntereses fechaRegistro tipo estado } }"
        return self._enviar(q).get('prestamos', [])

    # --- MÉTODO NUEVO PARA FILTRAR ---
    def listar_prestamos_por_tipo(self, tipo):
        q = """
            query ($tipo: String!) {
                prestamosPorTipoInmueble(tipoInmueble: $tipo) {
                    idPrestamo
                    monto
                    tasaIntereses
                    fechaRegistro
                    tipo
                    estado
                }
            }
        """
        return self._enviar(q, {"tipo": tipo}).get('prestamosPorTipoInmueble', [])

    def buscar_prestamo(self, id_p):
        q = "query ($id: Int!) { prestamoPorId(idPrestamo: $id) { idPrestamo monto tasaIntereses fechaRegistro tipo estado } }"
        return self._enviar(q, {"id": id_p}).get('prestamoPorId')

    def insertar_prestamo(self, input_data):
        q = "mutation ($input: PrestamoInput!) { addPrestamo(input: $input) { idPrestamo } }"
        return self._enviar(q, {"input": input_data})

    def actualizar_prestamo(self, id_p, input_data):
        q = "mutation ($id: Int!, $input: PrestamoInput!) { actualizarPrestamo(idPrestamo: $id, input: $input) { idPrestamo } }"
        return self._enviar(q, {"id": id_p, "input": input_data})

    def eliminar_prestamo(self, id_p):
        q = "mutation ($id: Int!) { eliminarPrestamo(idPrestamo: $id) }"
        return self._enviar(q, {"id": id_p})