using System;
using System.Windows.Forms;
using POCClientePrestamo.model;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIActualizarCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly PrestamoService _prestamoService = new PrestamoService();
        private bool estadoActual = true;

        public GUIActualizarCliente()
        {
            InitializeComponent();
        }

        private async void GUIActualizarCliente_Load(object sender, EventArgs e)
        {
            await CargarPrestamos();
        }

        private async System.Threading.Tasks.Task CargarPrestamos()
        {
            try
            {
                var prestamos = await _prestamoService.ListarPrestamosAsync();

                if (prestamos != null && prestamos.Count > 0)
                {
                    cmbPrestamo.DataSource = prestamos;
                    cmbPrestamo.DisplayMember = "idPrestamo";
                    cmbPrestamo.ValueMember = "_id";
                    cmbPrestamo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos: " + ex.Message);
            }
        }

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

                // Buscar el índice del préstamo en el ComboBox comparando el ObjectId
                bool encontrado = false;
                for (int i = 0; i < cmbPrestamo.Items.Count; i++)
                {
                    var item = cmbPrestamo.Items[i] as PrestamoData;
                    if (item != null && item._id == c.idPrestamo)
                    {
                        cmbPrestamo.SelectedIndex = i;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("Advertencia: El préstamo asociado a este cliente ya no existe en la base de datos.");
                }

                estadoActual = c.estado;
                HabilitarCampos(true);

                if (!c.estado)
                {
                    MessageBox.Show("Este cliente está INACTIVO. No se puede actualizar.");
                    btnActualizar.Enabled = false;
                }
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
                var prestamoSeleccionado = cmbPrestamo.SelectedItem as PrestamoData;

                if (prestamoSeleccionado == null || string.IsNullOrEmpty(prestamoSeleccionado._id))
                {
                    MessageBox.Show("Debe seleccionar un préstamo válido.");
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"\d"))
                {
                    MessageBox.Show("El nombre no puede contener números.");
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtCedula.Text, @"^\d+$"))
                {
                    MessageBox.Show("La cédula debe contener solo números.");
                    return;
                }

                var input = new ClienteInput
                {
                    idCliente = int.Parse(txtId.Text),
                    nombreCompleto = txtNombre.Text,
                    cedula = txtCedula.Text,
                    ingresosMensuales = double.Parse(txtIngresos.Text),
                    fechaNacimiento = dtpFechaNacimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                    idPrestamo = prestamoSeleccionado._id, // <-- ObjectId
                    estado = estadoActual
                };

                var resultado = await _clienteService.ActualizarClienteAsync(int.Parse(txtId.Text), input);

                if (resultado == null)
                    MessageBox.Show("No se pudo actualizar.");
                else
                    MessageBox.Show("Cliente actualizado correctamente.");
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
            cmbPrestamo.Enabled = habilitar;
            btnActualizar.Enabled = habilitar;
        }
    }
}