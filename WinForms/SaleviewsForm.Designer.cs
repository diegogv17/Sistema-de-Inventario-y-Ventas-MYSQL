namespace InventoryApp.WinForms
{
    partial class SaleviewsForm
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
            dgvDetalle = new DataGridView();
            dgvVentas = new DataGridView();
            btnFiltrar = new Button();
            dtDesde = new DateTimePicker();
            dtHasta = new DateTimePicker();
            cmbClientes = new ComboBox();
            label1 = new Label();
            chkFecha = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(15, 523);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(773, 91);
            dgvDetalle.TabIndex = 0;
            dgvDetalle.CellContentClick += dgvDetalle_CellContentClick;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(15, 243);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(773, 268);
            dgvVentas.TabIndex = 1;
            dgvVentas.CellContentClick += dgvVentas_CellContentClick;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(292, 161);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(198, 46);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "aplicar filtros";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dtDesde
            // 
            dtDesde.Location = new Point(254, 127);
            dtDesde.Name = "dtDesde";
            dtDesde.Size = new Size(109, 23);
            dtDesde.TabIndex = 3;
            dtDesde.ValueChanged += dtpTo_ValueChanged;
            // 
            // dtHasta
            // 
            dtHasta.Location = new Point(487, 127);
            dtHasta.Name = "dtHasta";
            dtHasta.Size = new Size(115, 23);
            dtHasta.TabIndex = 4;
            dtHasta.ValueChanged += dtHasta_ValueChanged;
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(239, 70);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(504, 23);
            cmbClientes.TabIndex = 5;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(653, 225);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // chkFecha
            // 
            chkFecha.AutoSize = true;
            chkFecha.Location = new Point(143, 176);
            chkFecha.Name = "chkFecha";
            chkFecha.Size = new Size(143, 19);
            chkFecha.TabIndex = 7;
            chkFecha.Text = "habilitar o deshabilitar";
            chkFecha.UseVisualStyleBackColor = true;
            chkFecha.CheckedChanged += chkFecha_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 68);
            label2.Name = "label2";
            label2.Size = new Size(209, 25);
            label2.TabIndex = 8;
            label2.Text = "Seleccione el cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(174, 127);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 9;
            label3.Text = "Desde:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold);
            label4.Location = new Point(412, 127);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 10;
            label4.Text = "Hasta:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Small", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(174, 9);
            label5.Name = "label5";
            label5.Size = new Size(414, 32);
            label5.TabIndex = 11;
            label5.Text = "Interfaz de Visualización de Ventas";
            // 
            // SaleviewsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 641);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(chkFecha);
            Controls.Add(label1);
            Controls.Add(cmbClientes);
            Controls.Add(dtHasta);
            Controls.Add(dtDesde);
            Controls.Add(btnFiltrar);
            Controls.Add(dgvVentas);
            Controls.Add(dgvDetalle);
            Name = "SaleviewsForm";
            Text = "SaleviewsForm";
            Load += SaleviewsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetalle;
        private DataGridView dgvVentas;
        private Button btnFiltrar;
        private DateTimePicker dtDesde;
        private DateTimePicker dtHasta;
        private ComboBox cmbClientes;
        private Label label1;
        private CheckBox chkFecha;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}