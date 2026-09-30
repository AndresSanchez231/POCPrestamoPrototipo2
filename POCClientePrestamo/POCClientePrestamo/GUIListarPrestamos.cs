using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCClientePrestamo.model;

namespace POCClientePrestamo
{
    public partial class GUIListarPrestamos : Form
    {
        public GUIListarPrestamos()
        {
            InitializeComponent();
        }

        private async void GUIListarPrestamos_Load(object sender, EventArgs e)
        {
            await listarPrestamos();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            await listarPrestamos();
        }

        private async Task listarPrestamos()
        {
            try
            {
                var client = new GraphQLHttpClient(
                    "http://localhost:8080/graphql",
                    new SystemTextJsonSerializer());

                var request = new GraphQLRequest
                {
                    Query = @"
                        query {
                            prestamos {
                                idPrestamo
                                monto
                                tasaIntereses
                                fechaRegistro
                                tipo
                                estado
                            }
                        }
                    "
                };

                var response = await client.SendQueryAsync<ResponseListaPrestamos>(request);

                if (response.Errors != null && response.Errors.Length > 0)
                {
                    MessageBox.Show("Error: " + response.Errors[0].Message);
                    return;
                }

                dgvPrestamos.DataSource = null;

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

                dgvPrestamos.DataSource = listaParaMostrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}