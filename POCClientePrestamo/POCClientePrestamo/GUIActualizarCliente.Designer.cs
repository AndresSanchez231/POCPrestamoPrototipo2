namespace POCClientePrestamo
{
    partial class GUIActualizarCliente
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCedula = new Label();
            txtCedula = new TextBox();
            lblIngresos = new Label();
            txtIngresos = new TextBox();
            lblFecha = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblIdPrestamo = new Label();
            lblEstado = new Label();
            txtEstado = new TextBox();
            btnActualizar = new Button();
            cmbPrestamo = new ComboBox();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(40, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(77, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID Cliente:";
            // 
            // txtId
            // 
            txtId.Location = new Point(180, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 27);
            txtId.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(350, 25);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 30);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(40, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(137, 20);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre Completo:";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(180, 77);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(270, 27);
            txtNombre.TabIndex = 4;
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(40, 120);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(58, 20);
            lblCedula.TabIndex = 5;
            lblCedula.Text = "Cédula:";
            // 
            // txtCedula
            // 
            txtCedula.Enabled = false;
            txtCedula.Location = new Point(180, 117);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(270, 27);
            txtCedula.TabIndex = 6;
            // 
            // lblIngresos
            // 
            lblIngresos.AutoSize = true;
            lblIngresos.Location = new Point(40, 160);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(67, 20);
            lblIngresos.TabIndex = 7;
            lblIngresos.Text = "Ingresos:";
            // 
            // txtIngresos
            // 
            txtIngresos.Enabled = false;
            txtIngresos.Location = new Point(180, 157);
            txtIngresos.Name = "txtIngresos";
            txtIngresos.Size = new Size(270, 27);
            txtIngresos.TabIndex = 8;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(40, 200);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(131, 20);
            lblFecha.TabIndex = 9;
            lblFecha.Text = "Fecha Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpFechaNacimiento.Enabled = false;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(180, 197);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(270, 27);
            dtpFechaNacimiento.TabIndex = 10;
            // 
            // lblIdPrestamo
            // 
            lblIdPrestamo.AutoSize = true;
            lblIdPrestamo.Location = new Point(40, 240);
            lblIdPrestamo.Name = "lblIdPrestamo";
            lblIdPrestamo.Size = new Size(93, 20);
            lblIdPrestamo.TabIndex = 11;
            lblIdPrestamo.Text = "ID Préstamo:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(40, 280);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 20);
            lblEstado.TabIndex = 13;
            lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Enabled = false;
            txtEstado.Location = new Point(180, 277);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(270, 27);
            txtEstado.TabIndex = 14;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(350, 330);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 35);
            btnActualizar.TabIndex = 15;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // cmbPrestamo
            // 
            cmbPrestamo.FormattingEnabled = true;
            cmbPrestamo.Location = new Point(180, 240);
            cmbPrestamo.Name = "cmbPrestamo";
            cmbPrestamo.Size = new Size(214, 28);
            cmbPrestamo.TabIndex = 16;
            // 
            // GUIActualizarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 400);
            Controls.Add(cmbPrestamo);
            Controls.Add(btnActualizar);
            Controls.Add(txtEstado);
            Controls.Add(lblEstado);
            Controls.Add(lblIdPrestamo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblFecha);
            Controls.Add(txtIngresos);
            Controls.Add(lblIngresos);
            Controls.Add(txtCedula);
            Controls.Add(lblCedula);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnBuscar);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Name = "GUIActualizarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar Cliente";
            Load += GUIActualizarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblIdPrestamo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnActualizar;
        private ComboBox cmbPrestamo;
    }
}