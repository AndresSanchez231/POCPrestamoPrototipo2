using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace POCClientePrestamo.model
{
    // Respuesta para búsqueda individual
    public class ResponsePrestamo
    {
        [JsonPropertyName("prestamoPorId")]
        public PrestamoData prestamo { get; set; }
    }

    // Respuesta para listar (varios)
    public class ResponseListaPrestamos
    {
        [JsonPropertyName("prestamos")]
        public List<PrestamoData> prestamos { get; set; }
    }

    // Respuesta para listar por tipo
    // Respuesta para listar por tipo de inmueble
    public class ResponseListaPorTipo
    {
        [JsonPropertyName("prestamosPorTipoInmueble")]
        public List<PrestamoData> prestamos { get; set; }
    }



    // Respuesta para add/update
    public class AddPrestamoResponse
    {
        [JsonPropertyName("addPrestamo")]
        public PrestamoData AddPrestamo { get; set; }

        [JsonPropertyName("actualizarPrestamo")]
        public PrestamoData ActualizarPrestamo { get; set; }
    }

    // Respuesta para eliminar
    public class DeletePrestamoResponse
    {
        [JsonPropertyName("eliminarPrestamo")]
        public bool EliminarPrestamo { get; set; }
    }

    // Modelo del préstamo
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
    }

    // Input para GraphQL
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
}