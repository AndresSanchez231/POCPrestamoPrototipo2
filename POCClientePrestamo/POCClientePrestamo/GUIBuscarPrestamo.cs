using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo
{
    public partial class GUIBuscarPrestamo : Form
    {
        public GUIBuscarPrestamo()
        {
            InitializeComponent();
        }

        private void GUIBuscarPrestamo_Load(object sender, EventArgs e)
        {
            // Vacío por ahora
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await buscarPrestamoPorId();
        }

        private async Task buscarPrestamoPorId()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdBuscar.Text))
                {
                    MessageBox.Show("Por favor, ingrese un ID para buscar.");
                    return;
                }

                var client = new GraphQLHttpClient(
                    "http://localhost:8080/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        query buscarPrestamoPorId ($id: Int!) {
                            prestamoPorId(idPrestamo: $id) {
                                idPrestamo
                                monto
                                tasaIntereses
                                fechaRegistro
                                tipo
                                estado
                            }
                        }
                    ",
                    Variables = new { id = int.Parse(txtIdBuscar.Text) }
                };

                var response = await client.SendQueryAsync<ResponsePrestamo>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                    return;
                }

                if (response.Data.prestamo == null)
                {
                    txtResultado.Text = "No se encontró un préstamo con ese ID.";
                    return;
                }

                var p = response.Data.prestamo;
                string estadoTexto = p.estado ? "ACTIVO" : "INACTIVO";

                txtResultado.Text =
                    $"ID: {p.idPrestamo}\r\n" +
                    $"Monto: {p.monto}\r\n" +
                    $"Tasa Intereses: {p.tasaIntereses}\r\n" +
                    $"Fecha Registro: {p.fechaRegistro}\r\n" +
                    $"Tipo: {p.tipo}\r\n" +
                    $"Estado: {estadoTexto}";
            }
            catch (FormatException)
            {
                MessageBox.Show("El ID debe ser un número entero.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}