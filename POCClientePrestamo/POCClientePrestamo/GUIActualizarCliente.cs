using System;
using System.Windows.Forms;
using POCClientePrestamo.builders;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIActualizarCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private bool estadoActual = true;

        public GUIActualizarCliente()
        {
            InitializeComponent();
        }

        private void GUIActualizarCliente_Load(object sender, EventArgs e) { }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Ingrese un ID.");
                    return;
                }

                var c = await _clienteService.BuscarClientePorIdAsync(int.Parse(txtId.Text));

                if (c == null)
                {
                    MessageBox.Show("No existe el cliente.");
                    HabilitarCampos(false);
                    return;
                }

                txtNombre.Text = c.nombreCompleto;
                txtCedula.Text = c.cedula;
                txtIngresos.Text = c.ingresosMensuales.ToString();
                dtpFechaNacimiento.Value = DateTime.Parse(c.fechaNacimiento);
                txtIdPrestamo.Text = c.idPrestamo.ToString();

                estadoActual = c.estado;

                HabilitarCampos(true);
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
                var input = new ClienteInputBuilder()
                    .ConId(int.Parse(txtId.Text))
                    .ConNombre(txtNombre.Text)
                    .ConCedula(txtCedula.Text)
                    .ConIngresos(double.Parse(txtIngresos.Text))
                    .ConFechaNacimiento(dtpFechaNacimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"))
                    .ConIdPrestamo(int.Parse(txtIdPrestamo.Text))
                    .Build();

                input.estado = estadoActual;

                var resultado = await _clienteService.ActualizarClienteAsync(int.Parse(txtId.Text), input);

                if (resultado == null)
                    MessageBox.Show("No se pudo actualizar.");
                else
                {
                    MessageBox.Show("Cliente actualizado correctamente.");
                    GestorEventos.NotificarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtCedula.Enabled = habilitar;
            txtIngresos.Enabled = habilitar;
            dtpFechaNacimiento.Enabled = habilitar;
            txtIdPrestamo.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
        }
    }
}