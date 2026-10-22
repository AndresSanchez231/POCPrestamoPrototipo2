using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.builders;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIAddCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();

        public GUIAddCliente()
        {
            InitializeComponent();
        }

        private void GUIAddCliente_Load(object sender, EventArgs e) { }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCedula.Text) ||
                    string.IsNullOrWhiteSpace(txtIngresos.Text) ||
                    string.IsNullOrWhiteSpace(txtIdPrestamo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var input = new ClienteInputBuilder()
                    .ConId(int.Parse(txtId.Text))
                    .ConNombre(txtNombre.Text)
                    .ConCedula(txtCedula.Text)
                    .ConIngresos(double.Parse(txtIngresos.Text))
                    .ConFechaNacimiento(dtpFechaNacimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"))
                    .ConIdPrestamo(int.Parse(txtIdPrestamo.Text))
                    .Build();

                var resultado = await _clienteService.InsertarClienteAsync(input);

                if (resultado == null)
                {
                    MessageBox.Show("No se pudo insertar el cliente. Verifique que el ID no exista.");
                    return;
                }

                MessageBox.Show("Cliente insertado correctamente.");
                GestorEventos.NotificarCliente();
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
            txtNombre.Clear();
            txtCedula.Clear();
            txtIngresos.Clear();
            txtIdPrestamo.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
        }
    }
}