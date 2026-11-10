using System;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIEliminarCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly PrestamoService _prestamoService = new PrestamoService();

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

                // Asignamos los atributos del cliente
                txtNombreRes.Text = c.nombreCompleto;
                txtCedulaRes.Text = c.cedula;
                txtIngresosRes.Text = c.ingresosMensuales.ToString("N2");
                txtFechaRes.Text = c.fechaNacimiento;
                txtEstadoRes.Text = c.estado ? "ACTIVO" : "INACTIVO";

                // CONVERSIÓN: Buscamos el préstamo para mostrar su ID manual
                if (!string.IsNullOrEmpty(c.idPrestamo))
                {
                    var prestamos = await _prestamoService.ListarPrestamosAsync();
                    var prestamoAsociado = prestamos?.Find(p => p._id == c.idPrestamo);

                    if (prestamoAsociado != null)
                    {
                        txtIdPrestamoRes.Text = prestamoAsociado.idPrestamo.ToString();
                    }
                    else
                    {
                        txtIdPrestamoRes.Text = "No encontrado";
                    }
                }
                else
                {
                    txtIdPrestamoRes.Text = "N/A";
                }

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
            var confirm = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                bool eliminado = await _clienteService.EliminarClienteAsync(int.Parse(txtId.Text));

                if (eliminado)
                {
                    MessageBox.Show("Cliente eliminado correctamente (estado = INACTIVO).");
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