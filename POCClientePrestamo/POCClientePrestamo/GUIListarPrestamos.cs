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
            // Suscribirse al Observer
            GestorEventos.PrestamoCambiado += CargarDatos;
        }

        private void GUIListarPrestamos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // ESTE ES EL MÉTODO QUE FALTABA
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

        private void GUIListarPrestamos_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Desuscribirse del Observer
            GestorEventos.PrestamoCambiado -= CargarDatos;
        }
    }
}