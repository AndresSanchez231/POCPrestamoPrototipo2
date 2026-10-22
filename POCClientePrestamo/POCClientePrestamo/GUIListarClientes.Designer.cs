namespace POCClientePrestamo
{
    partial class GUIListarClientes
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
            btnListar = new Button();
            lblIdPrestamo = new Label();
            txtIdPrestamo = new TextBox();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // btnListar
            // 
            btnListar.Location = new Point(694, 409);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(94, 29);
            btnListar.TabIndex = 0;
            btnListar.Text = "Listar Clientes";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // lblIdPrestamo
            // 
            lblIdPrestamo.AutoSize = true;
            lblIdPrestamo.Location = new Point(53, 57);
            lblIdPrestamo.Name = "lblIdPrestamo";
            lblIdPrestamo.Size = new Size(93, 20);
            lblIdPrestamo.TabIndex = 1;
            lblIdPrestamo.Text = "ID Préstamo:";
            // 
            // txtIdPrestamo
            // 
            txtIdPrestamo.Location = new Point(186, 55);
            txtIdPrestamo.Name = "txtIdPrestamo";
            txtIdPrestamo.Size = new Size(125, 27);
            txtIdPrestamo.TabIndex = 2;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(53, 121);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(721, 260);
            dgvClientes.TabIndex = 3;
            // 
            // GUIListarClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvClientes);
            Controls.Add(txtIdPrestamo);
            Controls.Add(lblIdPrestamo);
            Controls.Add(btnListar);
            Name = "GUIListarClientes";
            Text = "GUIListarClientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListar;
        private Label lblIdPrestamo;
        private TextBox txtIdPrestamo;
        private DataGridView dgvClientes;
    }
}