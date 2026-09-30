using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo
{
    public partial class GUIListarPorFiltro : Form
    {
        public GUIListarPorFiltro()
        {
            InitializeComponent();
        }

        private void GUIListarPorFiltro_Load(object sender, EventArgs e)
        {
            // Vacío por ahora. El usuario debe seleccionar un tipo.
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await filtrarPrestamos();
        }

        private async Task filtrarPrestamos()
        {
            try
            {
                // Validar que se haya seleccionado un tipo
                if (string.IsNullOrWhiteSpace(cmbTipoInmueble.Text))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de inmueble para filtrar.");
                    return;
                }

                var client = new GraphQLHttpClient(
                    "http://localhost:8080/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        query filtrarPorTipo ($tipoInmueble: String!) {
                            prestamosPorTipoInmueble(tipoInmueble: $tipoInmueble) {
                                idPrestamo
                                monto
                                tasaIntereses
                                fechaRegistro
                                tipo
                                estado
                            }
                        }
                    ",
                    Variables = new { tipoInmueble = cmbTipoInmueble.Text }
                };

                var response = await client.SendQueryAsync<ResponseListaPorTipo>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                    return;
                }

                dgvFiltro.DataSource = null;

                var listaParaMostrar = new System.Collections.Generic.List<object>();
                foreach (var p in response.Data.prestamos)
                {
                    listaParaMostrar.Add(new
                    {
                        ID = p.idPrestamo,
                        Monto = p.monto,
                        Tasa = p.tasaIntereses,
                        Fecha = p.fechaRegistro,
                        TipoInmueble = p.tipo,
                        Estado = p.estado ? "ACTIVO" : "INACTIVO"
                    });
                }

                if (listaParaMostrar.Count == 0)
                {
                    MessageBox.Show("No se encontraron préstamos con ese tipo de inmueble.");
                }

                dgvFiltro.DataSource = listaParaMostrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}