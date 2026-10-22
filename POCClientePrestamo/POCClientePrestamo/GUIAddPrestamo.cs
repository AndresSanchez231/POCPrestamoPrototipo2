using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.builders;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIAddPrestamo : Form
    {
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIAddPrestamo()
        {
            InitializeComponent();
        }

        private void GUIAddPrestamo_Load(object sender, EventArgs e) { }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtMonto.Text) ||
                    string.IsNullOrWhiteSpace(txtTasa.Text) ||
                    string.IsNullOrWhiteSpace(cmbTipo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var input = new PrestamoInputBuilder()
                    .ConId(int.Parse(txtId.Text))
                    .ConMonto(double.Parse(txtMonto.Text))
                    .ConTasa(double.Parse(txtTasa.Text))
                    .ConFecha(dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"))
                    .ConTipo(cmbTipo.Text)
                    .Build();

                var resultado = await _prestamoService.InsertarPrestamoAsync(input);

                if (resultado == null)
                {
                    MessageBox.Show("No se pudo insertar el préstamo. Verifique que el ID no exista.");
                    return;
                }

                MessageBox.Show("Préstamo insertado correctamente.");
                GestorEventos.NotificarPrestamo();
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique el formato de los datos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtMonto.Clear();
            txtTasa.Clear();
            cmbTipo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
        }
    }
}