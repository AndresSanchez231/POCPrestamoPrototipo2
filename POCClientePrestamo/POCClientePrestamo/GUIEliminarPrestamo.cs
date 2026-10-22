using System;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIEliminarPrestamo : Form
    {
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIEliminarPrestamo()
        {
            InitializeComponent();
        }

        private void GUIEliminarPrestamo_Load(object sender, EventArgs e) { }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                var p = await _prestamoService.BuscarPrestamoPorIdAsync(int.Parse(txtId.Text));

                if (p == null)
                {
                    MessageBox.Show("No existe el préstamo.");
                    btnEliminar.Enabled = false;
                    LimpiarCampos();
                    return;
                }

                // Asignamos cada atributo a su casilla correspondiente
                txtMonto.Text = p.monto.ToString();
                txtTasa.Text = p.tasaIntereses.ToString();
                txtFecha.Text = p.fechaRegistro;
                txtTipo.Text = p.tipo;
                txtEstado.Text = p.estado ? "ACTIVO" : "INACTIVO";

                btnEliminar.Enabled = true;

                if (!p.estado)
                {
                    MessageBox.Show("Este préstamo ya se encuentra INACTIVO.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro de eliminar este préstamo? (Pasará a estado INACTIVO)",
                                          "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool eliminado = await _prestamoService.EliminarPrestamoAsync(int.Parse(txtId.Text));

                if (eliminado)
                {
                    MessageBox.Show("Préstamo eliminado correctamente (estado = INACTIVO).");
                    GestorEventos.NotificarPrestamo(); // <-- Notificación al Observer
                    txtId.Clear();
                    LimpiarCampos();
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

        private void LimpiarCampos()
        {
            txtMonto.Clear();
            txtTasa.Clear();
            txtFecha.Clear();
            txtTipo.Clear();
            txtEstado.Clear();
        }
    }
}