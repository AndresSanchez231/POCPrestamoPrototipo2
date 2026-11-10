namespace POCClientePrestamo
{
    partial class GUIEliminarPrestamo
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
            lblId = new Label();
            txtId = new TextBox();
            btnBuscar = new Button();
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblTasa = new Label();
            txtTasa = new TextBox();
            lblFecha = new Label();
            txtFecha = new TextBox();
            lblTipo = new Label();
            txtTipo = new TextBox();
            lblEstado = new Label();
            txtEstado = new TextBox();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(40, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(93, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID Préstamo:";
            // 
            // txtId
            // 
            txtId.Location = new Point(160, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 27);
            txtId.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(330, 25);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 30);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(40, 80);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(56, 20);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(160, 77);
            txtMonto.Name = "txtMonto";
            txtMonto.ReadOnly = true;
            txtMonto.Size = new Size(270, 27);
            txtMonto.TabIndex = 4;
            // 
            // lblTasa
            // 
            lblTasa.AutoSize = true;
            lblTasa.Location = new Point(40, 120);
            lblTasa.Name = "lblTasa";
            lblTasa.Size = new Size(102, 20);
            lblTasa.TabIndex = 5;
            lblTasa.Text = "Tasa Intereses:";
            // 
            // txtTasa
            // 
            txtTasa.Location = new Point(160, 117);
            txtTasa.Name = "txtTasa";
            txtTasa.ReadOnly = true;
            txtTasa.Size = new Size(270, 27);
            txtTasa.TabIndex = 6;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(40, 160);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(109, 20);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha Registro:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(160, 157);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(270, 27);
            txtFecha.TabIndex = 8;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(40, 200);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(108, 20);
            lblTipo.TabIndex = 9;
            lblTipo.Text = "Tipo Inmueble:";
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(160, 197);
            txtTipo.Name = "txtTipo";
            txtTipo.ReadOnly = true;
            txtTipo.Size = new Size(270, 27);
            txtTipo.TabIndex = 10;
            txtTipo.TextChanged += txtTipo_TextChanged;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(40, 240);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 20);
            lblEstado.TabIndex = 11;
            lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(160, 237);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(270, 27);
            txtEstado.TabIndex = 12;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(330, 290);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // GUIEliminarPrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 360);
            Controls.Add(btnEliminar);
            Controls.Add(txtEstado);
            Controls.Add(lblEstado);
            Controls.Add(txtTipo);
            Controls.Add(lblTipo);
            Controls.Add(txtFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtTasa);
            Controls.Add(lblTasa);
            Controls.Add(txtMonto);
            Controls.Add(lblMonto);
            Controls.Add(btnBuscar);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Name = "GUIEliminarPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar Préstamo";
            Load += GUIEliminarPrestamo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblTasa;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnEliminar;
    }
}