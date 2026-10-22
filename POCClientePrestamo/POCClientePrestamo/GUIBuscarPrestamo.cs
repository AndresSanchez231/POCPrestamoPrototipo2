using System;
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

        // Método que faltaba
        private void GUIBuscarPrestamo_Load(object sender, EventArgs e)
        {
            // Vacío por ahora
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdBuscar.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                var p = await _prestamoService.BuscarPrestamoPorIdAsync(int.Parse(txtIdBuscar.Text));

                if (p == null)
                {
                    txtResultado.Text = "No se encontró un préstamo con ese ID.";
                    return;
                }

                txtResultado.Text =
                    $"ID: {p.idPrestamo}\r\n" +
                    $"Monto: {p.monto}\r\n" +
                    $"Tasa Intereses: {p.tasaIntereses}\r\n" +
                    $"Fecha Registro: {p.fechaRegistro}\r\n" +
                    $"Tipo: {p.tipo}\r\n" +
                    $"Estado: {(p.estado ? "ACTIVO" : "INACTIVO")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}