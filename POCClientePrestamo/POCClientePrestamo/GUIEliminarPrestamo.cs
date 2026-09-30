using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo
{
    public partial class GUIEliminarPrestamo : Form
    {
        public GUIEliminarPrestamo()
        {
            InitializeComponent();
        }

        private void GUIEliminarPrestamo_Load(object sender, EventArgs e)
        {
            // Vacío por ahora
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await buscarPrestamo();
        }

        private async Task buscarPrestamo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
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
                    Variables = new { id = int.Parse(txtId.Text) }
                };

                var response = await client.SendQueryAsync<ResponsePrestamo>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                    return;
                }

                if (response.Data.prestamo == null)
                {
                    MessageBox.Show("No existe un préstamo con ese ID.");
                    btnEliminar.Enabled = false;
                    txtResultado.Clear();
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

                // Habilitar el botón Eliminar solo si se encontró el préstamo
                btnEliminar.Enabled = true;
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro de eliminar este préstamo?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var client = new GraphQLHttpClient(
                    "http://localhost:8080/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation eliminarPrestamo ($id: Int!) {
                            eliminarPrestamo(idPrestamo: $id)
                        }
                    ",
                    Variables = new { id = int.Parse(txtId.Text) }
                };

                var response = await client.SendMutationAsync<DeletePrestamoResponse>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                }
                else if (response.Data.EliminarPrestamo)
                {
                    MessageBox.Show("Préstamo eliminado correctamente (estado = INACTIVO).");
                    txtId.Clear();
                    txtResultado.Clear();
                    btnEliminar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el préstamo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}