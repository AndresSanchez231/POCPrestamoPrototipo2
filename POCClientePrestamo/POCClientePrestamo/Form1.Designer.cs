namespace POCClientePrestamo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            insertarPrestamoToolStripMenuItem = new ToolStripMenuItem();
            consultarPrestamoToolStripMenuItem = new ToolStripMenuItem();
            eliminarPrestamoToolStripMenuItem = new ToolStripMenuItem();
            actualizarPrestamoToolStripMenuItem = new ToolStripMenuItem();
            listarPrestamosToolStripMenuItem = new ToolStripMenuItem();
            listarPorFiltroToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { operacionesToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem
            // 
            operacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { insertarPrestamoToolStripMenuItem, consultarPrestamoToolStripMenuItem, eliminarPrestamoToolStripMenuItem, actualizarPrestamoToolStripMenuItem, listarPrestamosToolStripMenuItem, listarPorFiltroToolStripMenuItem });
            operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            operacionesToolStripMenuItem.Size = new Size(106, 24);
            operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // insertarPrestamoToolStripMenuItem
            // 
            insertarPrestamoToolStripMenuItem.Name = "insertarPrestamoToolStripMenuItem";
            insertarPrestamoToolStripMenuItem.Size = new Size(224, 26);
            insertarPrestamoToolStripMenuItem.Text = "Insertar Préstamo";
            insertarPrestamoToolStripMenuItem.Click += insertarPrestamoToolStripMenuItem_Click;
            // 
            // consultarPrestamoToolStripMenuItem
            // 
            consultarPrestamoToolStripMenuItem.Name = "consultarPrestamoToolStripMenuItem";
            consultarPrestamoToolStripMenuItem.Size = new Size(224, 26);
            consultarPrestamoToolStripMenuItem.Text = "Consultar Préstamo";
            consultarPrestamoToolStripMenuItem.Click += consultarPrestamoToolStripMenuItem_Click;
            // 
            // eliminarPrestamoToolStripMenuItem
            // 
            eliminarPrestamoToolStripMenuItem.Name = "eliminarPrestamoToolStripMenuItem";
            eliminarPrestamoToolStripMenuItem.Size = new Size(224, 26);
            eliminarPrestamoToolStripMenuItem.Text = "Eliminar Préstamo";
            eliminarPrestamoToolStripMenuItem.Click += eliminarPrestamoToolStripMenuItem_Click;
            // 
            // actualizarPrestamoToolStripMenuItem
            // 
            actualizarPrestamoToolStripMenuItem.Name = "actualizarPrestamoToolStripMenuItem";
            actualizarPrestamoToolStripMenuItem.Size = new Size(224, 26);
            actualizarPrestamoToolStripMenuItem.Text = "Actualizar Préstamo";
            actualizarPrestamoToolStripMenuItem.Click += actualizarPrestamoToolStripMenuItem_Click;
            // 
            // listarPrestamosToolStripMenuItem
            // 
            listarPrestamosToolStripMenuItem.Name = "listarPrestamosToolStripMenuItem";
            listarPrestamosToolStripMenuItem.Size = new Size(224, 26);
            listarPrestamosToolStripMenuItem.Text = "Listar Préstamos";
            listarPrestamosToolStripMenuItem.Click += listarPrestamosToolStripMenuItem_Click;
            // 
            // listarPorFiltroToolStripMenuItem
            // 
            listarPorFiltroToolStripMenuItem.Name = "listarPorFiltroToolStripMenuItem";
            listarPorFiltroToolStripMenuItem.Size = new Size(224, 26);
            listarPorFiltroToolStripMenuItem.Text = "Listar por Filtro";
            listarPorFiltroToolStripMenuItem.Click += listarPorFiltroToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(224, 26);
            acercaDeToolStripMenuItem.Text = "Acerca de...";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal - Préstamos";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem insertarPrestamoToolStripMenuItem;
        private ToolStripMenuItem consultarPrestamoToolStripMenuItem;
        private ToolStripMenuItem eliminarPrestamoToolStripMenuItem;
        private ToolStripMenuItem actualizarPrestamoToolStripMenuItem;
        private ToolStripMenuItem listarPrestamosToolStripMenuItem;
        private ToolStripMenuItem listarPorFiltroToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}