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

        public GUIListarTodosClientes()
        {
            InitializeComponent();
            GestorEventos.ClienteCambiado += CargarDatos;
        }

        private void GUIListarTodosClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private async void CargarDatos()
        {
            if (this.IsDisposed) return;
            try
            {
                var clientes = await _clienteService.ListarTodosClientesAsync();
                dgvClientes.DataSource = null;
                if (clientes == null) return;

                var lista = new List<object>();
                foreach (var c in clientes)
                {
                    lista.Add(new
                    {
                        ID = c.idCliente,
                        Nombre = c.nombreCompleto,
                        Cedula = c.cedula,
                        Ingresos = c.ingresosMensuales,
                        FechaNac = c.fechaNacimiento,
                        ID_Prestamo = c.idPrestamo,
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void GUIListarTodosClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorEventos.ClienteCambiado -= CargarDatos;
        }
    }
}