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
            btnFiltrar.Location = new Point(280, 131);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(198, 46);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "aplicar filtros";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dtDesde
            // 
            dtDesde.Location = new Point(242, 97);
            dtDesde.Name = "dtDesde";
            dtDesde.Size = new Size(109, 23);
            dtDesde.TabIndex = 3;
            dtDesde.ValueChanged += dtpTo_ValueChanged;
            // 
            // dtHasta
            // 
            dtHasta.Location = new Point(475, 97);
            dtHasta.Name = "dtHasta";
            dtHasta.Size = new Size(115, 23);
            dtHasta.TabIndex = 4;
            dtHasta.ValueChanged += dtHasta_ValueChanged;
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(170, 40);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(564, 23);
            cmbClientes.TabIndex = 5;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(621, 213);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // chkFecha
            // 
            chkFecha.AutoSize = true;
            chkFecha.Location = new Point(170, 146);
            chkFecha.Name = "chkFecha";
            chkFecha.Size = new Size(82, 19);
            chkFecha.TabIndex = 7;
            chkFecha.Text = "checkBox1";
            chkFecha.UseVisualStyleBackColor = true;
            chkFecha.CheckedChanged += chkFecha_CheckedChanged;
            // 
            // SaleviewsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 641);
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
    }
}