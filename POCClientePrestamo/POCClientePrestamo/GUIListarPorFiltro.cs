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

        // Método que faltaba
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

                var prestamos = await _prestamoService.ListarPorTipoInmuebleAsync(cmbTipoInmueble.Text);
                dgvFiltro.DataSource = null;

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
                        Monto = p.monto,
                        Tasa = p.tasaIntereses,
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