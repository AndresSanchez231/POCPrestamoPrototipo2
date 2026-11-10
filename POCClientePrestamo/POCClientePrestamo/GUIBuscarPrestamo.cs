using System;
using System.Globalization;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIBuscarPrestamo : Form
    {
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIBuscarPrestamo()
        {
            InitializeComponent();
        }

        private void GUIBuscarPrestamo_Load(object sender, EventArgs e) { }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdBuscar.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                // Ahora enviamos el ID como String (sin int.Parse)
                var p = await _prestamoService.BuscarPrestamoPorIdAsync(txtIdBuscar.Text);

                if (p == null)
                {
                    MessageBox.Show("No se encontró el préstamo.");
                    LimpiarCampos();
                    return;
                }

                var cultura = new CultureInfo("en-US");

                // Asignamos cada atributo a su casilla
                // txtIdPrestamoRes.Text = p.idPrestamo.ToString(); // <-- COMENTADO: Esta casilla no existe
                txtMontoRes.Text = p.monto.ToString("N2", cultura);
                txtTasaRes.Text = p.tasaIntereses.ToString("N2", cultura);
                txtFechaRes.Text = p.fechaRegistro;
                txtTipoRes.Text = p.tipo;
                txtEstadoRes.Text = p.estado ? "ACTIVO" : "INACTIVO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtIdBuscar.Clear();
            // txtIdPrestamoRes.Clear(); // <-- COMENTADO: Esta casilla no existe
            txtMontoRes.Clear();
            txtTasaRes.Clear();
            txtFechaRes.Clear();
            txtTipoRes.Clear();
            txtEstadoRes.Clear();
        }
    }
}