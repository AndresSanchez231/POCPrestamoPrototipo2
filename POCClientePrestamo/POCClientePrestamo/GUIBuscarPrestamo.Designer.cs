namespace POCClientePrestamo
{
    partial class GUIBuscarPrestamo
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
            txtIdBuscar = new TextBox();
            btnBuscar = new Button();
            lblResultado = new Label();
            txtResultado = new TextBox();
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
            // txtIdBuscar
            // 
            txtIdBuscar.Location = new Point(160, 37);
            txtIdBuscar.Name = "txtIdBuscar";
            txtIdBuscar.Size = new Size(150, 27);
            txtIdBuscar.TabIndex = 1;
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
            lblResultado.Size = new Size(78, 20);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "Resultado:";
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(50, 130);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.ScrollBars = ScrollBars.Vertical;
            txtResultado.Size = new Size(500, 250);
            txtResultado.TabIndex = 4;
            // 
            // GUIBuscarPrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(txtResultado);
            Controls.Add(lblResultado);
            Controls.Add(btnBuscar);
            Controls.Add(txtIdBuscar);
            Controls.Add(lblIdBuscar);
            Name = "GUIBuscarPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Préstamo";
            Load += GUIBuscarPrestamo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdBuscar;
        private TextBox txtIdBuscar;
        private Button btnBuscar;
        private Label lblResultado;
        private TextBox txtResultado;
    }
}