using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIListarClientesConPrestamo : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();

        public GUIListarClientesConPrestamo()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = true;
            GestorEventos.ClienteCambiado += CargarDatos;
        }

        private void GUIListarClientesConPrestamo_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private async void CargarDatos()
        {
            if (this.IsDisposed) return;
            try
            {
                var lista = await _clienteService.ListarClientesConDatosPrestamoAsync();

                dgvClientes.DataSource = null;
                dgvClientes.Columns.Clear(); // Limpiamos columnas viejas
                dgvClientes.AutoGenerateColumns = true; // Forzamos generación automática

                dgvClientes.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Desuscripción al cerrar la ventana (para evitar errores)
        private void GUIListarClientesConPrestamo_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorEventos.ClienteCambiado -= CargarDatos;
        }
    }
}