namespace POCClientePrestamo
{
    partial class GUIEliminarCliente
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
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNombreRes = new System.Windows.Forms.Label();
            this.txtNombreRes = new System.Windows.Forms.TextBox();
            this.lblCedulaRes = new System.Windows.Forms.Label();
            this.txtCedulaRes = new System.Windows.Forms.TextBox();
            this.lblIngresosRes = new System.Windows.Forms.Label();
            this.txtIngresosRes = new System.Windows.Forms.TextBox();
            this.lblFechaRes = new System.Windows.Forms.Label();
            this.txtFechaRes = new System.Windows.Forms.TextBox();
            this.lblIdPrestamoRes = new System.Windows.Forms.Label();
            this.txtIdPrestamoRes = new System.Windows.Forms.TextBox();
            this.lblEstadoRes = new System.Windows.Forms.Label();
            this.txtEstadoRes = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(40, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(75, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID Cliente:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(170, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 27);
            this.txtId.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(340, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click); // <-- CONEXIÓN CLAVE
            // 
            // lblNombreRes
            // 
            this.lblNombreRes.AutoSize = true;
            this.lblNombreRes.Location = new System.Drawing.Point(40, 80);
            this.lblNombreRes.Name = "lblNombreRes";
            this.lblNombreRes.Size = new System.Drawing.Size(67, 20);
            this.lblNombreRes.TabIndex = 3;
            this.lblNombreRes.Text = "Nombre:";
            // 
            // txtNombreRes
            // 
            this.txtNombreRes.Location = new System.Drawing.Point(170, 77);
            this.txtNombreRes.Name = "txtNombreRes";
            this.txtNombreRes.ReadOnly = true;
            this.txtNombreRes.Size = new System.Drawing.Size(270, 27);
            this.txtNombreRes.TabIndex = 4;
            // 
            // lblCedulaRes
            // 
            this.lblCedulaRes.AutoSize = true;
            this.lblCedulaRes.Location = new System.Drawing.Point(40, 120);
            this.lblCedulaRes.Name = "lblCedulaRes";
            this.lblCedulaRes.Size = new System.Drawing.Size(58, 20);
            this.lblCedulaRes.TabIndex = 5;
            this.lblCedulaRes.Text = "Cédula:";
            // 
            // txtCedulaRes
            // 
            this.txtCedulaRes.Location = new System.Drawing.Point(170, 117);
            this.txtCedulaRes.Name = "txtCedulaRes";
            this.txtCedulaRes.ReadOnly = true;
            this.txtCedulaRes.Size = new System.Drawing.Size(270, 27);
            this.txtCedulaRes.TabIndex = 6;
            // 
            // lblIngresosRes
            // 
            this.lblIngresosRes.AutoSize = true;
            this.lblIngresosRes.Location = new System.Drawing.Point(40, 160);
            this.lblIngresosRes.Name = "lblIngresosRes";
            this.lblIngresosRes.Size = new System.Drawing.Size(70, 20);
            this.lblIngresosRes.TabIndex = 7;
            this.lblIngresosRes.Text = "Ingresos:";
            // 
            // txtIngresosRes
            // 
            this.txtIngresosRes.Location = new System.Drawing.Point(170, 157);
            this.txtIngresosRes.Name = "txtIngresosRes";
            this.txtIngresosRes.ReadOnly = true;
            this.txtIngresosRes.Size = new System.Drawing.Size(270, 27);
            this.txtIngresosRes.TabIndex = 8;
            // 
            // lblFechaRes
            // 
            this.lblFechaRes.AutoSize = true;
            this.lblFechaRes.Location = new System.Drawing.Point(40, 200);
            this.lblFechaRes.Name = "lblFechaRes";
            this.lblFechaRes.Size = new System.Drawing.Size(120, 20);
            this.lblFechaRes.TabIndex = 9;
            this.lblFechaRes.Text = "Fecha Nacimiento:";
            // 
            // txtFechaRes
            // 
            this.txtFechaRes.Location = new System.Drawing.Point(170, 197);
            this.txtFechaRes.Name = "txtFechaRes";
            this.txtFechaRes.ReadOnly = true;
            this.txtFechaRes.Size = new System.Drawing.Size(270, 27);
            this.txtFechaRes.TabIndex = 10;
            // 
            // lblIdPrestamoRes
            // 
            this.lblIdPrestamoRes.AutoSize = true;
            this.lblIdPrestamoRes.Location = new System.Drawing.Point(40, 240);
            this.lblIdPrestamoRes.Name = "lblIdPrestamoRes";
            this.lblIdPrestamoRes.Size = new System.Drawing.Size(90, 20);
            this.lblIdPrestamoRes.TabIndex = 11;
            this.lblIdPrestamoRes.Text = "ID Préstamo:";
            // 
            // txtIdPrestamoRes
            // 
            this.txtIdPrestamoRes.Location = new System.Drawing.Point(170, 237);
            this.txtIdPrestamoRes.Name = "txtIdPrestamoRes";
            this.txtIdPrestamoRes.ReadOnly = true;
            this.txtIdPrestamoRes.Size = new System.Drawing.Size(270, 27);
            this.txtIdPrestamoRes.TabIndex = 12;
            // 
            // lblEstadoRes
            // 
            this.lblEstadoRes.AutoSize = true;
            this.lblEstadoRes.Location = new System.Drawing.Point(40, 280);
            this.lblEstadoRes.Name = "lblEstadoRes";
            this.lblEstadoRes.Size = new System.Drawing.Size(55, 20);
            this.lblEstadoRes.TabIndex = 13;
            this.lblEstadoRes.Text = "Estado:";
            // 
            // txtEstadoRes
            // 
            this.txtEstadoRes.Location = new System.Drawing.Point(170, 277);
            this.txtEstadoRes.Name = "txtEstadoRes";
            this.txtEstadoRes.ReadOnly = true;
            this.txtEstadoRes.Size = new System.Drawing.Size(270, 27);
            this.txtEstadoRes.TabIndex = 14;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(340, 330);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 35);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click); // <-- CONEXIÓN CLAVE
            // 
            // GUIEliminarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtEstadoRes);
            this.Controls.Add(this.lblEstadoRes);
            this.Controls.Add(this.txtIdPrestamoRes);
            this.Controls.Add(this.lblIdPrestamoRes);
            this.Controls.Add(this.txtFechaRes);
            this.Controls.Add(this.lblFechaRes);
            this.Controls.Add(this.txtIngresosRes);
            this.Controls.Add(this.lblIngresosRes);
            this.Controls.Add(this.txtCedulaRes);
            this.Controls.Add(this.lblCedulaRes);
            this.Controls.Add(this.txtNombreRes);
            this.Controls.Add(this.lblNombreRes);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Name = "GUIEliminarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Cliente";
            this.Load += new System.EventHandler(this.GUIEliminarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNombreRes;
        private System.Windows.Forms.TextBox txtNombreRes;
        private System.Windows.Forms.Label lblCedulaRes;
        private System.Windows.Forms.TextBox txtCedulaRes;
        private System.Windows.Forms.Label lblIngresosRes;
        private System.Windows.Forms.TextBox txtIngresosRes;
        private System.Windows.Forms.Label lblFechaRes;
        private System.Windows.Forms.TextBox txtFechaRes;
        private System.Windows.Forms.Label lblIdPrestamoRes;
        private System.Windows.Forms.TextBox txtIdPrestamoRes;
        private System.Windows.Forms.Label lblEstadoRes;
        private System.Windows.Forms.TextBox txtEstadoRes;
        private System.Windows.Forms.Button btnEliminar;
    }
}