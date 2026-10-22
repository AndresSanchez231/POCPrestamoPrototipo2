namespace POCClientePrestamo
{
    partial class GUIBuscarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIdBuscar = new Label();
            lblIdPrestamoRes = new Label();
            lblFechaRes = new Label();
            lblIngresosRes = new Label();
            lblCedulaRes = new Label();
            lblNombreRes = new Label();
            txtIdBuscar = new TextBox();
            txtIdPrestamoRes = new TextBox();
            txtFechaRes = new TextBox();
            txtIngresosRes = new TextBox();
            txtCedulaRes = new TextBox();
            txtNombreRes = new TextBox();
            btnBuscar = new Button();
            lblEstadoRes = new Label();
            txtEstadoRes = new TextBox();
            SuspendLayout();
            // 
            // lblIdBuscar
            // 
            lblIdBuscar.AutoSize = true;
            lblIdBuscar.Location = new Point(61, 37);
            lblIdBuscar.Name = "lblIdBuscar";
            lblIdBuscar.Size = new Size(77, 20);
            lblIdBuscar.TabIndex = 0;
            lblIdBuscar.Text = "ID Cliente:";
            // 
            // lblIdPrestamoRes
            // 
            lblIdPrestamoRes.AutoSize = true;
            lblIdPrestamoRes.Location = new Point(61, 387);
            lblIdPrestamoRes.Name = "lblIdPrestamoRes";
            lblIdPrestamoRes.Size = new Size(93, 20);
            lblIdPrestamoRes.TabIndex = 1;
            lblIdPrestamoRes.Text = "ID Préstamo:";
            // 
            // lblFechaRes
            // 
            lblFechaRes.AutoSize = true;
            lblFechaRes.Location = new Point(61, 289);
            lblFechaRes.Name = "lblFechaRes";
            lblFechaRes.Size = new Size(131, 20);
            lblFechaRes.TabIndex = 2;
            lblFechaRes.Text = "Fecha Nacimiento:";
            // 
            // lblIngresosRes
            // 
            lblIngresosRes.AutoSize = true;
            lblIngresosRes.Location = new Point(61, 223);
            lblIngresosRes.Name = "lblIngresosRes";
            lblIngresosRes.Size = new Size(67, 20);
            lblIngresosRes.TabIndex = 3;
            lblIngresosRes.Text = "Ingresos:";
            // 
            // lblCedulaRes
            // 
            lblCedulaRes.AutoSize = true;
            lblCedulaRes.Location = new Point(61, 158);
            lblCedulaRes.Name = "lblCedulaRes";
            lblCedulaRes.Size = new Size(58, 20);
            lblCedulaRes.TabIndex = 4;
            lblCedulaRes.Text = "Cédula:";
            // 
            // lblNombreRes
            // 
            lblNombreRes.AutoSize = true;
            lblNombreRes.Location = new Point(61, 95);
            lblNombreRes.Name = "lblNombreRes";
            lblNombreRes.Size = new Size(67, 20);
            lblNombreRes.TabIndex = 5;
            lblNombreRes.Text = "Nombre:";
            // 
            // txtIdBuscar
            // 
            txtIdBuscar.Location = new Point(212, 29);
            txtIdBuscar.Name = "txtIdBuscar";
            txtIdBuscar.Size = new Size(125, 27);
            txtIdBuscar.TabIndex = 6;
            // 
            // txtIdPrestamoRes
            // 
            txtIdPrestamoRes.Location = new Point(212, 380);
            txtIdPrestamoRes.Name = "txtIdPrestamoRes";
            txtIdPrestamoRes.Size = new Size(125, 27);
            txtIdPrestamoRes.TabIndex = 8;
            // 
            // txtFechaRes
            // 
            txtFechaRes.Location = new Point(212, 282);
            txtFechaRes.Name = "txtFechaRes";
            txtFechaRes.Size = new Size(125, 27);
            txtFechaRes.TabIndex = 9;
            // 
            // txtIngresosRes
            // 
            txtIngresosRes.Location = new Point(212, 220);
            txtIngresosRes.Name = "txtIngresosRes";
            txtIngresosRes.Size = new Size(125, 27);
            txtIngresosRes.TabIndex = 10;
            // 
            // txtCedulaRes
            // 
            txtCedulaRes.Location = new Point(212, 155);
            txtCedulaRes.Name = "txtCedulaRes";
            txtCedulaRes.Size = new Size(125, 27);
            txtCedulaRes.TabIndex = 11;
            // 
            // txtNombreRes
            // 
            txtNombreRes.Location = new Point(212, 88);
            txtNombreRes.Name = "txtNombreRes";
            txtNombreRes.Size = new Size(125, 27);
            txtNombreRes.TabIndex = 12;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(597, 345);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 13;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblEstadoRes
            // 
            lblEstadoRes.AutoSize = true;
            lblEstadoRes.Location = new Point(73, 336);
            lblEstadoRes.Name = "lblEstadoRes";
            lblEstadoRes.Size = new Size(57, 20);
            lblEstadoRes.TabIndex = 14;
            lblEstadoRes.Text = "Estado:";
            // 
            // txtEstadoRes
            // 
            txtEstadoRes.Location = new Point(212, 329);
            txtEstadoRes.Name = "txtEstadoRes";
            txtEstadoRes.ReadOnly = true;
            txtEstadoRes.Size = new Size(125, 27);
            txtEstadoRes.TabIndex = 15;
            // 
            // GUIBuscarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEstadoRes);
            Controls.Add(lblEstadoRes);
            Controls.Add(btnBuscar);
            Controls.Add(txtNombreRes);
            Controls.Add(txtCedulaRes);
            Controls.Add(txtIngresosRes);
            Controls.Add(txtFechaRes);
            Controls.Add(txtIdPrestamoRes);
            Controls.Add(txtIdBuscar);
            Controls.Add(lblNombreRes);
            Controls.Add(lblCedulaRes);
            Controls.Add(lblIngresosRes);
            Controls.Add(lblFechaRes);
            Controls.Add(lblIdPrestamoRes);
            Controls.Add(lblIdBuscar);
            Name = "GUIBuscarCliente";
            Text = "GUIBuscarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdBuscar;
        private Label lblIdPrestamoRes;
        private Label lblFechaRes;
        private Label lblIngresosRes;
        private Label lblCedulaRes;
        private Label lblNombreRes;
        private TextBox txtIdBuscar;
        private TextBox txtIdPrestamoRes;
        private TextBox txtFechaRes;
        private TextBox txtIngresosRes;
        private TextBox txtCedulaRes;
        private TextBox txtNombreRes;
        private Button btnBuscar;
        private Label lblEstadoRes;
        private TextBox txtEstadoRes;
    }
}