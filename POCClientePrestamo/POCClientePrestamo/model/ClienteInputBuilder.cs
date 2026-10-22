using POCClientePrestamo.model;

namespace POCClientePrestamo.builders
{
    public class ClienteInputBuilder
    {
        private readonly ClienteInput _cliente;

        public ClienteInputBuilder()
        {
            _cliente = new ClienteInput { estado = true }; // Activo por defecto
        }

        public ClienteInputBuilder ConId(int id)
        {
            _cliente.idCliente = id;
            return this;
        }

        public ClienteInputBuilder ConNombre(string nombre)
        {
            _cliente.nombreCompleto = nombre;
            return this;
        }

        public ClienteInputBuilder ConCedula(string cedula)
        {
            _cliente.cedula = cedula;
            return this;
        }

        public ClienteInputBuilder ConIngresos(double ingresos)
        {
            _cliente.ingresosMensuales = ingresos;
            return this;
        }

        public ClienteInputBuilder ConFechaNacimiento(string fecha)
        {
            _cliente.fechaNacimiento = fecha;
            return this;
        }

        public ClienteInputBuilder ConIdPrestamo(int idPrestamo)
        {
            _cliente.idPrestamo = idPrestamo;
            return this;
        }

        public ClienteInput Build()
        {
            return _cliente;
        }
    }
}