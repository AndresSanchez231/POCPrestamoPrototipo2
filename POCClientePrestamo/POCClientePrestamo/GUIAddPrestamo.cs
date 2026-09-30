using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo
{
    public partial class GUIAddPrestamo : Form
    {
        public GUIAddPrestamo()
        {
            InitializeComponent();
        }

        private void GUIAddPrestamo_Load(object sender, EventArgs e)
        {
            // Vacío por ahora
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await adicionarPrestamo();
        }

        private async Task adicionarPrestamo()
        {
            try
            {
                // Validar campos vacíos (ya no validamos fecha porque el DateTimePicker siempre tiene valor)
                if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtMonto.Text) ||
                    string.IsNullOrWhiteSpace(txtTasa.Text) ||
                    string.IsNullOrWhiteSpace(cmbTipo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                var client = new GraphQLHttpClient(
                    "http://localhost:8080/graphql",
                    new SystemTextJsonSerializer());

                var inputData = new PrestamoInput
                {
                    idPrestamo = int.Parse(txtId.Text),
                    monto = double.Parse(txtMonto.Text),
                    tasaIntereses = double.Parse(txtTasa.Text),
                    // Convertimos la fecha del DateTimePicker al formato ISO que pide GraphQL
                    fechaRegistro = dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    tipo = cmbTipo.Text,
                    estado = true
                };

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation addPrestamo ($input: PrestamoInput!) {
                            addPrestamo(input: $input) {
                                idPrestamo
                                monto
                                tasaIntereses
                                fechaRegistro
                                tipo
                                estado
                            }
                        }
                    ",
                    Variables = new { input = inputData }
                };

                var response = await client.SendMutationAsync<AddPrestamoResponse>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                }
                else if (response.Data.AddPrestamo == null)
                {
                    MessageBox.Show("No se pudo insertar el préstamo. Verifique que el ID no exista.");
                }
                else
                {
                    MessageBox.Show("Préstamo insertado correctamente.");
                    LimpiarCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique el formato de los datos (números).");
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
            dtpFecha.Value = DateTime.Now; // Resetear a la fecha actual
        }
    }
}