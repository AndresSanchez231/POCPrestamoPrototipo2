using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace POCClientePrestamo.model
{
    // ==========================================
    // RESPUESTAS
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

    public class ResponseClientesConPrestamo
    {
        [JsonPropertyName("clientesConDatosPrestamo")]
        public List<ClienteConPrestamoData> clientesConDatosPrestamo { get; set; }
    }

    // ==========================================
    // MODELOS DE DATOS
    // ==========================================

    public class PrestamoData
    {
        [JsonPropertyName("_id")]
        public string _id { get; set; } // <-- ObjectId de Mongo

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
        public string idPrestamo { get; set; } // <-- String (ObjectId)

        [JsonPropertyName("estado")]
        public bool estado { get; set; }
    }

    public class ClienteConPrestamoData
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

        [JsonPropertyName("estado")]
        public bool estado { get; set; }

        [JsonPropertyName("montoPrestamo")]
        public double montoPrestamo { get; set; }

        [JsonPropertyName("tipoPrestamo")]
        public string tipoPrestamo { get; set; }
    }

    // ==========================================
    // INPUTS
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
        public string idPrestamo { get; set; } // <-- String (ObjectId)

        [JsonPropertyName("estado")]
        public bool estado { get; set; }
    }
}