namespace POCClientePrestamo
{
    partial class GUIListarPorFiltro
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTipoInmueble = new Label();
            cmbTipoInmueble = new ComboBox();
            btnFiltrar = new Button();
            dgvFiltro = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFiltro).BeginInit();
            SuspendLayout();
            // 
            // lblTipoInmueble
            // 
            lblTipoInmueble.AutoSize = true;
            lblTipoInmueble.Location = new Point(40, 40);
            lblTipoInmueble.Name = "lblTipoInmueble";
            lblTipoInmueble.Size = new Size(108, 20);
            lblTipoInmueble.TabIndex = 0;
            lblTipoInmueble.Text = "Tipo Inmueble:";
            // 
            // cmbTipoInmueble
            // 
            cmbTipoInmueble.FormattingEnabled = true;
            cmbTipoInmueble.Items.AddRange(new object[] { "CASA", "APARTAMENTO", "LOCAL COMERCIAL" });
            cmbTipoInmueble.Location = new Point(160, 37);
            cmbTipoInmueble.Name = "cmbTipoInmueble";
            cmbTipoInmueble.Size = new Size(200, 28);
            cmbTipoInmueble.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(380, 36);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(100, 30);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvFiltro
            // 
            dgvFiltro.AllowUserToAddRows = false;
            dgvFiltro.AllowUserToDeleteRows = false;
            dgvFiltro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFiltro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFiltro.Location = new Point(40, 90);
            dgvFiltro.Name = "dgvFiltro";
            dgvFiltro.ReadOnly = true;
            dgvFiltro.RowHeadersWidth = 51;
            dgvFiltro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFiltro.Size = new Size(900, 380);
            dgvFiltro.TabIndex = 3;
            // 
            // GUIListarPorFiltro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 500);
            Controls.Add(dgvFiltro);
            Controls.Add(btnFiltrar);
            Controls.Add(cmbTipoInmueble);
            Controls.Add(lblTipoInmueble);
            Name = "GUIListarPorFiltro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar por Filtro";
            Load += GUIListarPorFiltro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFiltro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoInmueble;
        private ComboBox cmbTipoInmueble;
        private Button btnFiltrar;
        private DataGridView dgvFiltro;
    }
}