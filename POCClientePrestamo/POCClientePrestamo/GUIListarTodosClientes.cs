using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIListarTodosClientes : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIListarTodosClientes()
        {
            InitializeComponent();
            GestorEventos.ClienteCambiado += CargarDatos;
        }

        private void GUIListarTodosClientes_Load(object sender, EventArgs e) { }

        // CAMBIO: Ahora se llama btnRefrescar_Click para que coincida con el diseñador
        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async void CargarDatos()
        {
            if (this.IsDisposed) return;
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                var clientes = await _clienteService.ListarTodosClientesAsync();

                dgvClientes.DataSource = null;
                dgvClientes.Columns.Clear();
                dgvClientes.AutoGenerateColumns = true;

                if (clientes == null || clientes.Count == 0)
                {
                    MessageBox.Show("No hay clientes registrados.");
                    return;
                }

                // Cargamos todos los préstamos para hacer la conversión de ObjectId a ID manual
                var prestamos = await _prestamoService.ListarPrestamosAsync();

                var lista = new List<object>();
                foreach (var c in clientes)
                {
                    // Buscamos el préstamo asociado al cliente por su ObjectId
                    var prestamoAsociado = prestamos?.Find(p => p._id == c.idPrestamo);

                    // Si lo encontramos, mostramos el idPrestamo manual; si no, mostramos el ObjectId
                    string idPrestamoMostrar = prestamoAsociado != null
                        ? prestamoAsociado.idPrestamo.ToString()
                        : c.idPrestamo;

                    lista.Add(new
                    {
                        ID = c.idCliente,
                        Nombre = c.nombreCompleto,
                        Cedula = c.cedula,
                        Ingresos = c.ingresosMensuales.ToString("N2"),
                        FechaNac = c.fechaNacimiento,
                        ID_Prestamo = idPrestamoMostrar, // <-- ID manual o ObjectId
                        Estado = c.estado ? "ACTIVO" : "INACTIVO"
                    });
                }

                dgvClientes.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message);
            }
        }

        private void GUIListarTodosClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorEventos.ClienteCambiado -= CargarDatos;
        }
    }
}