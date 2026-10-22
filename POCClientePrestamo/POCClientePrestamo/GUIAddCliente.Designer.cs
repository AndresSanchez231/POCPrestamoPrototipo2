namespace POCClientePrestamo
{
    partial class GUIAddCliente
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCedula = new Label();
            txtCedula = new TextBox();
            lblIngresos = new Label();
            txtIngresos = new TextBox();
            lblFecha = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblIdPrestamo = new Label();
            txtIdPrestamo = new TextBox();
            btnGuardar = new Button();
            lblEstadoRes = new Label();
            txtEstadoRes = new TextBox();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(50, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(77, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID Cliente:";
            // 
            // txtId
            // 
            txtId.Location = new Point(200, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 27);
            txtId.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(50, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(137, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre Completo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(200, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 3;
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(50, 110);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(58, 20);
            lblCedula.TabIndex = 4;
            lblCedula.Text = "Cédula:";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(200, 107);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(150, 27);
            txtCedula.TabIndex = 5;
            // 
            // lblIngresos
            // 
            lblIngresos.AutoSize = true;
            lblIngresos.Location = new Point(50, 150);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(140, 20);
            lblIngresos.TabIndex = 6;
            lblIngresos.Text = "Ingresos Mensuales:";
            // 
            // txtIngresos
            // 
            txtIngresos.Location = new Point(200, 147);
            txtIngresos.Name = "txtIngresos";
            txtIngresos.Size = new Size(150, 27);
            txtIngresos.TabIndex = 7;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(50, 190);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(131, 20);
            lblFecha.TabIndex = 8;
            lblFecha.Text = "Fecha Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(200, 187);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(250, 27);
            dtpFechaNacimiento.TabIndex = 9;
            // 
            // lblIdPrestamo
            // 
            lblIdPrestamo.AutoSize = true;
            lblIdPrestamo.Location = new Point(50, 280);
            lblIdPrestamo.Name = "lblIdPrestamo";
            lblIdPrestamo.Size = new Size(93, 20);
            lblIdPrestamo.TabIndex = 10;
            lblIdPrestamo.Text = "ID Préstamo:";
            // 
            // txtIdPrestamo
            // 
            txtIdPrestamo.Location = new Point(200, 280);
            txtIdPrestamo.Name = "txtIdPrestamo";
            txtIdPrestamo.Size = new Size(150, 27);
            txtIdPrestamo.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(388, 280);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblEstadoRes
            // 
            lblEstadoRes.AutoSize = true;
            lblEstadoRes.Location = new Point(58, 238);
            lblEstadoRes.Name = "lblEstadoRes";
            lblEstadoRes.Size = new Size(57, 20);
            lblEstadoRes.TabIndex = 13;
            lblEstadoRes.Text = "Estado:";
            // 
            // txtEstadoRes
            // 
            txtEstadoRes.Location = new Point(200, 235);
            txtEstadoRes.Name = "txtEstadoRes";
            txtEstadoRes.Size = new Size(125, 27);
            txtEstadoRes.TabIndex = 14;
            // 
            // GUIAddCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 350);
            Controls.Add(txtEstadoRes);
            Controls.Add(lblEstadoRes);
            Controls.Add(btnGuardar);
            Controls.Add(txtIdPrestamo);
            Controls.Add(lblIdPrestamo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblFecha);
            Controls.Add(txtIngresos);
            Controls.Add(lblIngresos);
            Controls.Add(txtCedula);
            Controls.Add(lblCedula);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Name = "GUIAddCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Cliente";
            Load += GUIAddCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCedula;
        private TextBox txtCedula;
        private Label lblIngresos;
        private TextBox txtIngresos;
        private Label lblFecha;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblIdPrestamo;
        private TextBox txtIdPrestamo;
        private Button btnGuardar;
        private Label lblEstadoRes;
        private TextBox txtEstadoRes;
    }
}