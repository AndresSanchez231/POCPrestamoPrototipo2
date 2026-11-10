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
            txtMontoRes = new TextBox();
            txtTasaRes = new TextBox();
            txtFechaRes = new TextBox();
            txtTipoRes = new TextBox();
            txtEstadoRes = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
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
            lblResultado.Size = new Size(56, 20);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "Monto:";
            // 
            // txtMontoRes
            // 
            txtMontoRes.Enabled = false;
            txtMontoRes.Location = new Point(160, 97);
            txtMontoRes.Name = "txtMontoRes";
            txtMontoRes.Size = new Size(125, 27);
            txtMontoRes.TabIndex = 4;
            // 
            // txtTasaRes
            // 
            txtTasaRes.Enabled = false;
            txtTasaRes.Location = new Point(160, 143);
            txtTasaRes.Name = "txtTasaRes";
            txtTasaRes.Size = new Size(125, 27);
            txtTasaRes.TabIndex = 5;
            // 
            // txtFechaRes
            // 
            txtFechaRes.Enabled = false;
            txtFechaRes.Location = new Point(160, 193);
            txtFechaRes.Name = "txtFechaRes";
            txtFechaRes.Size = new Size(125, 27);
            txtFechaRes.TabIndex = 6;
            // 
            // txtTipoRes
            // 
            txtTipoRes.Enabled = false;
            txtTipoRes.Location = new Point(160, 252);
            txtTipoRes.Name = "txtTipoRes";
            txtTipoRes.Size = new Size(125, 27);
            txtTipoRes.TabIndex = 7;
            // 
            // txtEstadoRes
            // 
            txtEstadoRes.Enabled = false;
            txtEstadoRes.Location = new Point(160, 308);
            txtEstadoRes.Name = "txtEstadoRes";
            txtEstadoRes.Size = new Size(125, 27);
            txtEstadoRes.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 311);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 9;
            label1.Text = "Estado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 259);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 10;
            label2.Text = "Tipo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 200);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 11;
            label3.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 146);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 12;
            label4.Text = "Tasa:";
            // 
            // GUIBuscarPrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEstadoRes);
            Controls.Add(txtTipoRes);
            Controls.Add(txtFechaRes);
            Controls.Add(txtTasaRes);
            Controls.Add(txtMontoRes);
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
        private TextBox txtMontoRes;
        private TextBox txtTasaRes;
        private TextBox txtFechaRes;
        private TextBox txtTipoRes;
        private TextBox txtEstadoRes;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}