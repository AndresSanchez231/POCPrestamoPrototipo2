using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.model;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIAddCliente : Form
    {
        private readonly ClienteService _clienteService = new ClienteService();
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIAddCliente()
        {
            InitializeComponent();
        }

        private async void GUIAddCliente_Load(object sender, EventArgs e)
        {
            await CargarPrestamos();
        }

        private async Task CargarPrestamos()
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
                else
                {
                    MessageBox.Show("No hay préstamos disponibles. Cree un préstamo primero.");
                    btnGuardar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos: " + ex.Message);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCedula.Text) ||
                    string.IsNullOrWhiteSpace(txtIngresos.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                if (cmbPrestamo.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un préstamo.");
                    return;
                }

                var prestamoSeleccionado = cmbPrestamo.SelectedItem as PrestamoData;
                if (prestamoSeleccionado == null || string.IsNullOrEmpty(prestamoSeleccionado._id))
                {
                    MessageBox.Show("Error: El préstamo seleccionado no tiene un ObjectId válido.");
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
                    idPrestamo = prestamoSeleccionado._id,
                    estado = true
                };

                var resultado = await _clienteService.InsertarClienteAsync(input);

                if (resultado == null)
                {
                    MessageBox.Show("No se pudo insertar el cliente.");
                    return;
                }

                MessageBox.Show("Cliente insertado correctamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Manejo del error sin GraphQLExceptionHandler
                string errorMsg = ex.Message;

                if (errorMsg.Contains("INTERNAL_ERROR"))
                {
                    MessageBox.Show("El préstamo seleccionado está INACTIVO. No se pueden agregar clientes.");
                }
                else if (errorMsg.Contains("no existe"))
                {
                    MessageBox.Show("El préstamo seleccionado no existe.");
                }
                else if (errorMsg.Contains("ya existe"))
                {
                    MessageBox.Show("El ID del cliente ya existe. Use otro.");
                }
                else
                {
                    MessageBox.Show("Error: " + errorMsg);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtIngresos.Clear();
            cmbPrestamo.SelectedIndex = 0;
            dtpFechaNacimiento.Value = DateTime.Now;
        }
    }
}