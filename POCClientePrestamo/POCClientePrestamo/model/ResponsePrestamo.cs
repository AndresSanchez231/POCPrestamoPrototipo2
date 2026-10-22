using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace POCClientePrestamo.model
{
    // ==========================================
    // MODELOS DE RESPUESTA (READ)
    // ==========================================

    public class ResponsePrestamo
    {
        [JsonPropertyName("prestamoPorId")]
        public PrestamoData prestamo { get; set; }
    }

    public class ResponseListaPrestamos
    {
        [JsonPropertyName("prestamos")]
        public List<PrestamoData> prestamos { get; set; }
    }

    public class ResponseListaPorTipo
    {
        [JsonPropertyName("prestamosPorTipoInmueble")]
        public List<PrestamoData> prestamos { get; set; }
    }

    public class AddPrestamoResponse
    {
        [JsonPropertyName("addPrestamo")]
        public PrestamoData AddPrestamo { get; set; }

        [JsonPropertyName("actualizarPrestamo")]
        public PrestamoData ActualizarPrestamo { get; set; }
    }

    public class DeletePrestamoResponse
    {
        [JsonPropertyName("eliminarPrestamo")]
        public bool EliminarPrestamo { get; set; }
    }

    // --- RESPUESTAS DE CLIENTE ---
    public class ResponseCliente
    {
        [JsonPropertyName("clientePorId")]
        public ClienteData cliente { get; set; }

        [JsonPropertyName("addCliente")]
        public ClienteData AddCliente { get; set; }

        [JsonPropertyName("actualizarCliente")]
        public ClienteData ActualizarCliente { get; set; }
    }

    public class ResponseListaClientes
    {
        [JsonPropertyName("clientesPorPrestamo")]
        public List<ClienteData> clientes { get; set; }
    }

    // NUEVA CLASE PARA LISTAR TODOS
    public class ResponseListaTodosClientes
    {
        [JsonPropertyName("clientes")]
        public List<ClienteData> clientes { get; set; }
    }

    public class DeleteClienteResponse
    {
        [JsonPropertyName("eliminarCliente")]
        public bool EliminarCliente { get; set; }
    }


    // ==========================================
    // MODELOS DE DATOS (OBJETOS)
    // ==========================================

    public class PrestamoData
    {
        [JsonPropertyName("idPrestamo")]
        public int idPrestamo { get; set; }

        [JsonPropertyName("monto")]
        public double monto { get; set; }

        [JsonPropertyName("tasaIntereses")]
        public double tasaIntereses { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public string fechaRegistro { get; set; }

        [JsonPropertyName("tipo")]
        public string tipo { get; set; }

        [JsonPropertyName("estado")]
        public bool estado { get; set; }

        [JsonPropertyName("clientes")]
        public List<ClienteData> clientes { get; set; }
    }

    public class ClienteData
    {
        [JsonPropertyName("idCliente")]
        public int idCliente { get; set; }

        [JsonPropertyName("nombreCompleto")]
        public string nombreCompleto { get; set; }

        [JsonPropertyName("cedula")]
        public string cedula { get; set; }

        [JsonPropertyName("ingresosMensuales")]
        public double ingresosMensuales { get; set; }

        [JsonPropertyName("fechaNacimiento")]
        public string fechaNacimiento { get; set; }

        [JsonPropertyName("idPrestamo")]
        public int idPrestamo { get; set; }

        [JsonPropertyName("estado")]
        public bool estado { get; set; }
    }

    // ==========================================
    // MODELOS DE ENTRADA (INPUT)
    // ==========================================

    public class PrestamoInput
    {
        [JsonPropertyName("idPrestamo")]
        public int idPrestamo { get; set; }

        [JsonPropertyName("monto")]
        public double monto { get; set; }

        [JsonPropertyName("tasaIntereses")]
        public double tasaIntereses { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public string fechaRegistro { get; set; }

        [JsonPropertyName("tipo")]
        public string tipo { get; set; }

        [JsonPropertyName("estado")]
        public bool estado { get; set; }
    }

    public class ClienteInput
    {
        [JsonPropertyName("idCliente")]
        public int idCliente { get; set; }

        [JsonPropertyName("nombreCompleto")]
        public string nombreCompleto { get; set; }

        [JsonPropertyName("cedula")]
        public string cedula { get; set; }

        [JsonPropertyName("ingresosMensuales")]
        public double ingresosMensuales { get; set; }

        [JsonPropertyName("fechaNacimiento")]
        public string fechaNacimiento { get; set; }

        [JsonPropertyName("idPrestamo")]
        public int idPrestamo { get; set; }

        [JsonPropertyName("estado")]
        public bool estado { get; set; }
    }
}