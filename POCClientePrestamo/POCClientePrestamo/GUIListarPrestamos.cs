using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIListarPrestamos : Form
    {
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIListarPrestamos()
        {
            InitializeComponent();
            dgvPrestamos.AutoGenerateColumns = true;
            // Suscribirse al evento para formatear las celdas
            dgvPrestamos.CellFormatting += dgvPrestamos_CellFormatting;
        }

        private void GUIListarPrestamos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private async void CargarDatos()
        {
            if (this.IsDisposed) return;
            try
            {
                var prestamos = await _prestamoService.ListarPrestamosAsync();
                dgvPrestamos.DataSource = null;
                if (prestamos == null) return;

                var lista = new List<object>();
                foreach (var p in prestamos)
                {
                    lista.Add(new
                    {
                        ID = p.idPrestamo,
                        Monto = p.monto,
                        Tasa = p.tasaIntereses,
                        Fecha = p.fechaRegistro,
                        TipoInmueble = p.tipo,
                        Estado = p.estado ? "ACTIVO" : "INACTIVO"
                    });
                }
                dgvPrestamos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // EVENTO PARA FORMATEAR LAS CELDAS
        private void dgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificamos si la columna es "Monto" o "Tasa"
            if (dgvPrestamos.Columns[e.ColumnIndex].Name == "Monto" ||
                dgvPrestamos.Columns[e.ColumnIndex].Name == "Tasa")
            {
                if (e.Value != null)
                {
                    // Convertimos a double y formateamos con 2 decimales
                    double valor = Convert.ToDouble(e.Value);
                    e.Value = valor.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }

        // Desuscribirse al cerrar para evitar errores
        private void GUIListarPrestamos_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvPrestamos.CellFormatting -= dgvPrestamos_CellFormatting;
        }
    }
}