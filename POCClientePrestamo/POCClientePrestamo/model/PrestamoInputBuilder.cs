using POCClientePrestamo.model;

namespace POCClientePrestamo.builders
{
    public class PrestamoInputBuilder
    {
        private readonly PrestamoInput _prestamo;

        public PrestamoInputBuilder()
        {
            _prestamo = new PrestamoInput { estado = true }; // Activo por defecto
        }

        public PrestamoInputBuilder ConId(int id)
        {
            _prestamo.idPrestamo = id;
            return this;
        }

        public PrestamoInputBuilder ConMonto(double monto)
        {
            _prestamo.monto = monto;
            return this;
        }

        public PrestamoInputBuilder ConTasa(double tasa)
        {
            _prestamo.tasaIntereses = tasa;
            return this;
        }

        public PrestamoInputBuilder ConFecha(string fecha)
        {
            _prestamo.fechaRegistro = fecha;
            return this;
        }

        public PrestamoInputBuilder ConTipo(string tipo)
        {
            _prestamo.tipo = tipo;
            return this;
        }

        public PrestamoInput Build()
        {
            return _prestamo;
        }
    }
}