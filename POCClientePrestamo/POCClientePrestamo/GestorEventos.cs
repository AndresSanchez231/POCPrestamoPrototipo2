using System;

namespace POCClientePrestamo
{
    public static class GestorEventos
    {
        // Eventos para Préstamos
        public static event Action PrestamoCambiado;

        // Eventos para Clientes
        public static event Action ClienteCambiado;

        public static void NotificarPrestamo()
        {
            PrestamoCambiado?.Invoke();
        }

        public static void NotificarCliente()
        {
            ClienteCambiado?.Invoke();
        }
    }
}