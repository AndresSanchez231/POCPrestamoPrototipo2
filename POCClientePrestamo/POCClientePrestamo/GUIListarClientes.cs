using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIListarClientes : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIListarClientes()
        {
            InitializeComponent();
            GestorEventos.ClienteCambiado += CargarDatosFiltro;
        }

        private void GUIListarClientes_Load(object sender, EventArgs e) { }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            await CargarDatosFiltroAsync();
        }

        private async void CargarDatosFiltro()
        {
            if (this.IsDisposed) return;
            await CargarDatosFiltroAsync();
        }

        private async Task CargarDatosFiltroAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdPrestamo.Text))
                {
                    MessageBox.Show("Ingrese el ID del préstamo.");
                    return;
                }

                // 1. Buscar el préstamo por su ID manual para obtener su ObjectId
                var prestamos = await _prestamoService.ListarPrestamosAsync();
                var prestamoSeleccionado = prestamos?.Find(p => p.idPrestamo == int.Parse(txtIdPrestamo.Text));

                if (prestamoSeleccionado == null)
                {
                    MessageBox.Show("No se encontró un préstamo con ese ID.");
                    return;
                }

                // 2. Usar el ObjectId del préstamo para buscar los clientes
                var clientes = await _clienteService.ListarClientesPorPrestamoAsync(prestamoSeleccionado._id);

                dgvClientes.DataSource = null;
                dgvClientes.Columns.Clear();
                dgvClientes.AutoGenerateColumns = true;

                if (clientes == null || clientes.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes para este préstamo.");
                    return;
                }

                var lista = new List<object>();
                foreach (var c in clientes)
                {
                    lista.Add(new
                    {
                        ID = c.idCliente,
                        Nombre = c.nombreCompleto,
                        Cedula = c.cedula,
                        Ingresos = c.ingresosMensuales.ToString("N2"),
                        FechaNac = c.fechaNacimiento,
                        // MOSTRAMOS EL ID MANUAL DEL PRÉSTAMO, NO EL OBJECTID
                        ID_Prestamo = prestamoSeleccionado.idPrestamo,
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

        private void GUIListarClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorEventos.ClienteCambiado -= CargarDatosFiltro;
        }
    }
}