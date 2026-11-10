using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POCClientePrestamo.services;

namespace POCClientePrestamo
{
    public partial class GUIListarPorFiltro : Form
    {
        private readonly PrestamoService _prestamoService = new PrestamoService();

        public GUIListarPorFiltro()
        {
            InitializeComponent();
        }

        private void GUIListarPorFiltro_Load(object sender, EventArgs e)
        {
            // Vacío por ahora
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbTipoInmueble.Text))
                {
                    MessageBox.Show("Seleccione un tipo de inmueble.");
                    return;
                }

                // NORMALIZACIÓN: Convertimos el texto a "Casa", "Apartamento" o "Local Comercial"
                string tipoSeleccionado = cmbTipoInmueble.Text.Trim();
                if (tipoSeleccionado.ToUpper() == "CASA")
                    tipoSeleccionado = "Casa";
                else if (tipoSeleccionado.ToUpper() == "APARTAMENTO")
                    tipoSeleccionado = "Apartamento";
                else if (tipoSeleccionado.ToUpper() == "LOCAL COMERCIAL")
                    tipoSeleccionado = "Local Comercial";

                var prestamos = await _prestamoService.ListarPorTipoInmuebleAsync(tipoSeleccionado);

                dgvFiltro.DataSource = null;
                dgvFiltro.Columns.Clear();
                dgvFiltro.AutoGenerateColumns = true;

                if (prestamos == null || prestamos.Count == 0)
                {
                    MessageBox.Show("No se encontraron préstamos con ese tipo.");
                    return;
                }

                var lista = new List<object>();
                foreach (var p in prestamos)
                {
                    lista.Add(new
                    {
                        ID = p.idPrestamo,
                        Monto = p.monto.ToString("N2"), // Formato decimal
                        Tasa = p.tasaIntereses.ToString("N2"), // Formato decimal
                        Fecha = p.fechaRegistro,
                        TipoInmueble = p.tipo,
                        Estado = p.estado ? "ACTIVO" : "INACTIVO"
                    });
                }

                dgvFiltro.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}