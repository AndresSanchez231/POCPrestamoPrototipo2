using System;
using System.Windows.Forms;

namespace POCClientePrestamo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        // ==========================================
        // PRÉSTAMOS
        // ==========================================
        private void insertarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIAddPrestamo().Show();
        }

        private void consultarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIBuscarPrestamo().Show();
        }

        private void eliminarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIEliminarPrestamo().Show();
        }

        private void actualizarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIActualizarPrestamo().Show();
        }

        private void listarPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIListarPrestamos().Show();
        }

        private void listarPorFiltroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIListarPorFiltro().Show();
        }

        // ==========================================
        // CLIENTES
        // ==========================================
        private void agregarClienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new GUIAddCliente().Show();
        }

        private void listarClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new GUIListarClientes().Show();
        }

        private void buscarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIBuscarCliente().Show();
        }

        private void actualizarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIActualizarCliente().Show();
        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIEliminarCliente().Show();
        }

        private void listarTodosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GUIListarTodosClientes().Show();
        }

        // ==========================================
        // AYUDA
        // ==========================================
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Aplicación: POC Cliente Préstamos\n" +
                "Versión: 1.0\n" +
                "Integrantes:\n" +
                "- Andres Felipe Sanchez\n" +
                "- Juan Pablo Valbuena\n",
                "Acerca de...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}