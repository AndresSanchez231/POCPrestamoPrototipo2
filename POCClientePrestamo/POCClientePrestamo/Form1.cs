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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Vacío por ahora
        }

        private void insertarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIAddPrestamo gui = new GUIAddPrestamo();
            gui.Show();
        }

        private void consultarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIBuscarPrestamo gui = new GUIBuscarPrestamo();
            gui.Show();
        }

        private void eliminarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIEliminarPrestamo gui = new GUIEliminarPrestamo();
            gui.Show();
        }

        private void actualizarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIActualizarPrestamo gui = new GUIActualizarPrestamo();
            gui.Show();
        }

        private void listarPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarPrestamos gui = new GUIListarPrestamos();
            gui.Show();
        }

        private void listarPorFiltroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIListarPorFiltro gui = new GUIListarPorFiltro();
            gui.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Aplicación: POC Cliente Préstamos\n" +
                "Versión: 1.0\n" +
                "Integrantes:\n" +
                "- Andres Felipe Sanchez\n" +
                "- Juan Pablo Valbuena\n" 
               ,
                "Acerca de...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}