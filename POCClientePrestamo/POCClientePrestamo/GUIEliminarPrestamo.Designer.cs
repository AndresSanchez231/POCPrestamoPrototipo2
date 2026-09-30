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
            lblIdBuscar = new Label();
            txtId = new TextBox();
            btnBuscar = new Button();
            lblResultado = new Label();
            txtResultado = new TextBox();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lblIdBuscar
            // 
            lblIdBuscar.AutoSize = true;
            lblIdBuscar.Location = new Point(50, 40);
            lblIdBuscar.Name = "lblIdBuscar";
            lblIdBuscar.Size = new Size(90, 20);
            lblIdBuscar.TabIndex = 0;
            lblIdBuscar.Text = "ID Préstamo:";
            // 
            // txtId
            // 
            txtId.Location = new Point(160, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 27);
            txtId.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(340, 35);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(50, 100);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(173, 20);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "Información del Préstamo:";
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(50, 130);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.ScrollBars = ScrollBars.Vertical;
            txtResultado.Size = new Size(500, 200);
            txtResultado.TabIndex = 4;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(456, 350);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // GUIEliminarPrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(btnEliminar);
            Controls.Add(txtResultado);
            Controls.Add(lblResultado);
            Controls.Add(btnBuscar);
            Controls.Add(txtId);
            Controls.Add(lblIdBuscar);
            Name = "GUIEliminarPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar Préstamo";
            Load += GUIEliminarPrestamo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdBuscar;
        private TextBox txtId;
        private Button btnBuscar;
        private Label lblResultado;
        private TextBox txtResultado;
        private Button btnEliminar;
    }
}