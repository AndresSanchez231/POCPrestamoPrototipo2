using System;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIEliminarCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();

        public GUIEliminarCliente()
        {
            InitializeComponent();
        }

        private void GUIEliminarCliente_Load(object sender, EventArgs e) { }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                var c = await _clienteService.BuscarClientePorIdAsync(int.Parse(txtId.Text));

                if (c == null)
                {
                    MessageBox.Show("No existe el cliente.");
                    btnEliminar.Enabled = false;
                    LimpiarCampos();
                    return;
                }

                txtNombreRes.Text = c.nombreCompleto;
                txtCedulaRes.Text = c.cedula;
                txtIngresosRes.Text = c.ingresosMensuales.ToString();
                txtFechaRes.Text = c.fechaNacimiento;
                txtIdPrestamoRes.Text = c.idPrestamo.ToString();
                txtEstadoRes.Text = c.estado ? "ACTIVO" : "INACTIVO";

                btnEliminar.Enabled = true;

                if (!c.estado)
                {
                    MessageBox.Show("Este cliente ya se encuentra INACTIVO.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro de eliminar este cliente? (Pasará a estado INACTIVO)",
                                          "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool eliminado = await _clienteService.EliminarClienteAsync(int.Parse(txtId.Text));

                if (eliminado)
                {
                    MessageBox.Show("Cliente eliminado correctamente (estado = INACTIVO).");
                    GestorEventos.NotificarCliente();
                    txtId.Clear();
                    LimpiarCampos();
                    btnEliminar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombreRes.Clear();
            txtCedulaRes.Clear();
            txtIngresosRes.Clear();
            txtFechaRes.Clear();
            txtIdPrestamoRes.Clear();
            txtEstadoRes.Clear();
        }
    }
}