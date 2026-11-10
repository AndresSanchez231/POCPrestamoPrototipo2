using System;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIBuscarCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly PrestamoService _prestamoService = new PrestamoService();

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

                // Asignamos los atributos del cliente
                txtNombreRes.Text = c.nombreCompleto;
                txtCedulaRes.Text = c.cedula;
                txtIngresosRes.Text = c.ingresosMensuales.ToString("N2");
                txtFechaRes.Text = c.fechaNacimiento;
                txtEstadoRes.Text = c.estado ? "ACTIVO" : "INACTIVO";

                // CONVERSIÓN: Buscamos el préstamo para mostrar su ID manual en lugar del ObjectId
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