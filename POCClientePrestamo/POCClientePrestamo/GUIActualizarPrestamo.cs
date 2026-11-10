using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.builders;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIActualizarPrestamo : Form
    {
        private readonly PrestamoService _prestamoService = new PrestamoService();
        private bool estadoActual = true;

        public GUIActualizarPrestamo()
        {
            InitializeComponent();
        }

        private void GUIActualizarPrestamo_Load(object sender, EventArgs e) { }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                // CORRECCIÓN: Pasamos el texto directo (String), no int.Parse
                var p = await _prestamoService.BuscarPrestamoPorIdAsync(txtId.Text);

                if (p == null)
                {
                    MessageBox.Show("No existe un préstamo con ese ID.");
                    HabilitarCampos(false);
                    return;
                }

                txtMonto.Text = p.monto.ToString();
                txtTasa.Text = p.tasaIntereses.ToString();
                dtpFecha.Value = DateTime.Parse(p.fechaRegistro);
                cmbTipo.Text = p.tipo;
                estadoActual = p.estado;

                HabilitarCampos(true);

                if (!p.estado)
                    MessageBox.Show("Este préstamo está INACTIVO. Los cambios no lo reactivarán.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var input = new PrestamoInputBuilder()
                    .ConId(int.Parse(txtId.Text)) // OJO: Si tu builder pide int aquí, está bien (es el ID manual), pero si falla, avísame.
                    .ConMonto(double.Parse(txtMonto.Text))
                    .ConTasa(double.Parse(txtTasa.Text))
                    .ConFecha(dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"))
                    .ConTipo(cmbTipo.Text)
                    .Build();

                input.estado = estadoActual;

                // CORRECCIÓN: Pasamos el texto directo (String) para el ObjectId
                var resultado = await _prestamoService.ActualizarPrestamoAsync(txtId.Text, input);

                if (resultado == null)
                    MessageBox.Show("No se pudo actualizar el préstamo.");
                else
                {
                    MessageBox.Show("Préstamo actualizado correctamente.");
                    GestorEventos.NotificarPrestamo();
                }
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
    }
}