using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo
{
    public partial class GUIActualizarPrestamo : Form
    {
        private bool estadoActual = true;   // ← NUEVO: guarda el estado actual

        public GUIActualizarPrestamo()
        {
            InitializeComponent();
        }

        private void GUIActualizarPrestamo_Load(object sender, EventArgs e)
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
                    HabilitarCampos(false);
                    return;
                }

                var p = response.Data.prestamo;

                // Cargar los datos del préstamo en los controles
                txtMonto.Text = p.monto.ToString();
                txtTasa.Text = p.tasaIntereses.ToString();
                dtpFecha.Value = DateTime.Parse(p.fechaRegistro);
                cmbTipo.Text = p.tipo;

                // Guardar el estado actual para no cambiarlo en la actualización
                estadoActual = p.estado;

                // Habilitar los campos para que el usuario pueda editarlos
                HabilitarCampos(true);

                // Avisar al usuario si el préstamo está inactivo
                if (!p.estado)
                {
                    MessageBox.Show("Este préstamo está INACTIVO (eliminado). Los cambios no lo reactivarán.");
                }
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

        private void HabilitarCampos(bool habilitar)
        {
            txtMonto.Enabled = habilitar;
            txtTasa.Enabled = habilitar;
            dtpFecha.Enabled = habilitar;
            cmbTipo.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMonto.Text) ||
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
                    fechaRegistro = dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    tipo = cmbTipo.Text,
                    estado = estadoActual   // ← CAMBIO: se mantiene el estado actual
                };

                var request = new GraphQLRequest
                {
                    Query = @"
                        mutation actualizarPrestamo ($id: Int!, $input: PrestamoInput!) {
                            actualizarPrestamo(idPrestamo: $id, input: $input) {
                                idPrestamo
                                monto
                                tasaIntereses
                                fechaRegistro
                                tipo
                                estado
                            }
                        }
                    ",
                    Variables = new { id = int.Parse(txtId.Text), input = inputData }
                };

                var response = await client.SendMutationAsync<AddPrestamoResponse>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                }
                else if (response.Data.ActualizarPrestamo == null)
                {
                    MessageBox.Show("No se pudo actualizar el préstamo.");
                }
                else
                {
                    MessageBox.Show("Préstamo actualizado correctamente.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique el formato de los números.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}