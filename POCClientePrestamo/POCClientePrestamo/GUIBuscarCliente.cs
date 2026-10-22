using System;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIBuscarCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();

        public GUIBuscarCliente()
        {
            InitializeComponent();
        }

        private void GUIBuscarCliente_Load(object sender, EventArgs e) { }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdBuscar.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                var c = await _clienteService.BuscarClientePorIdAsync(int.Parse(txtIdBuscar.Text));

                if (c == null)
                {
                    MessageBox.Show("No se encontró el cliente.");
                    LimpiarCampos();
                    return;
                }

                txtNombreRes.Text = c.nombreCompleto;
                txtCedulaRes.Text = c.cedula;
                txtIngresosRes.Text = c.ingresosMensuales.ToString();
                txtFechaRes.Text = c.fechaNacimiento;
                txtIdPrestamoRes.Text = c.idPrestamo.ToString();

                // NUEVO: Mostrar el estado
                txtEstadoRes.Text = c.estado ? "ACTIVO" : "INACTIVO";
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