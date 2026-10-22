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

        public GUIListarClientes()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = true; // Forzar columnas automáticas
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

                var clientes = await _clienteService.ListarClientesPorPrestamoAsync(int.Parse(txtIdPrestamo.Text));

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
                        Cédula = c.cedula,
                        Ingresos = c.ingresosMensuales,
                        FechaNac = c.fechaNacimiento,
                        ID_Préstamo = c.idPrestamo,
                        Estado = c.estado ? "ACTIVO" : "INACTIVO"
                    });
                }

                dgvClientes.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GUIListarClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorEventos.ClienteCambiado -= CargarDatosFiltro;
        }
    }
}