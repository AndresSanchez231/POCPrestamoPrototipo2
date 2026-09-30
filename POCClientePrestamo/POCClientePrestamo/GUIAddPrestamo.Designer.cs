namespace POCClientePrestamo
{
    partial class GUIAddPrestamo
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
            lblId = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtId = new TextBox();
            txtTasa = new TextBox();
            txtMonto = new TextBox();
            cmbTipo = new ComboBox();
            btnGuardar = new Button();
            dtpFecha = new DateTimePicker();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(52, 21);
            lblId.Name = "lblId";
            lblId.Size = new Size(93, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID Préstamo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 232);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Tipo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 180);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 128);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 3;
            label4.Text = "Tasa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 74);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 4;
            label5.Text = "Monto:";
            // 
            // txtId
            // 
            txtId.Location = new Point(195, 21);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 5;
            // 
            // txtTasa
            // 
            txtTasa.Location = new Point(195, 128);
            txtTasa.Name = "txtTasa";
            txtTasa.Size = new Size(125, 27);
            txtTasa.TabIndex = 9;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(195, 74);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(125, 27);
            txtMonto.TabIndex = 10;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "CASA", "APARTAMENTO", "LOCAL COMERCIAL" });
            cmbTipo.Location = new Point(195, 232);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(151, 28);
            cmbTipo.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(511, 266);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(195, 180);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 13;
            // 
            // GUIAddPrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpFecha);
            Controls.Add(btnGuardar);
            Controls.Add(cmbTipo);
            Controls.Add(txtMonto);
            Controls.Add(txtTasa);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblId);
            Name = "GUIAddPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insertar Préstamo";
            Load += GUIAddPrestamo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtId;
        private TextBox txtTasa;
        private TextBox txtMonto;
        private ComboBox cmbTipo;
        private Button btnGuardar;
        private DateTimePicker dtpFecha;
    }
}