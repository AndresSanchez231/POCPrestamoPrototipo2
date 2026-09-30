namespace POCClientePrestamo
{
    partial class GUIActualizarPrestamo
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
            lblIdBuscar = new Label();
            txtId = new TextBox();
            btnBuscar = new Button();
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblTasa = new Label();
            txtTasa = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            btnActualizar = new Button();
            SuspendLayout();
            // 
            // lblIdBuscar
            // 
            lblIdBuscar.AutoSize = true;
            lblIdBuscar.Location = new Point(50, 40);
            lblIdBuscar.Name = "lblIdBuscar";
            lblIdBuscar.Size = new Size(93, 20);
            lblIdBuscar.TabIndex = 0;
            lblIdBuscar.Text = "ID Préstamo:";
            // 
            // txtId
            // 
            txtId.Location = new Point(180, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 27);
            txtId.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(360, 35);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(50, 100);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(56, 20);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            txtMonto.Enabled = false;
            txtMonto.Location = new Point(180, 97);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(200, 27);
            txtMonto.TabIndex = 4;
            // 
            // lblTasa
            // 
            lblTasa.AutoSize = true;
            lblTasa.Location = new Point(50, 150);
            lblTasa.Name = "lblTasa";
            lblTasa.Size = new Size(102, 20);
            lblTasa.TabIndex = 5;
            lblTasa.Text = "Tasa Intereses:";
            // 
            // txtTasa
            // 
            txtTasa.Enabled = false;
            txtTasa.Location = new Point(180, 147);
            txtTasa.Name = "txtTasa";
            txtTasa.Size = new Size(200, 27);
            txtTasa.TabIndex = 6;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(50, 200);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(109, 20);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha Registro:";
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(180, 197);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 8;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(50, 250);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(42, 20);
            lblTipo.TabIndex = 9;
            lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            cmbTipo.Enabled = false;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "CASA", "APARTAMENTO", "LOCAL COMERCIAL" });
            cmbTipo.Location = new Point(180, 247);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 28);
            cmbTipo.TabIndex = 10;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(420, 320);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(130, 35);
            btnActualizar.TabIndex = 11;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // GUIActualizarPrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 400);
            Controls.Add(btnActualizar);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtTasa);
            Controls.Add(lblTasa);
            Controls.Add(txtMonto);
            Controls.Add(lblMonto);
            Controls.Add(btnBuscar);
            Controls.Add(txtId);
            Controls.Add(lblIdBuscar);
            Name = "GUIActualizarPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar Préstamo";
            Load += GUIActualizarPrestamo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdBuscar;
        private TextBox txtId;
        private Button btnBuscar;
        private Label lblMonto;
        private TextBox txtMonto;
        private Label lblTasa;
        private TextBox txtTasa;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Button btnActualizar;
    }
}