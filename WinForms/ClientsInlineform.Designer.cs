namespace InventoryApp.WinForms
{
    partial class ClientsInlineform
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
            dataGridClients = new DataGridView();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnConfirmar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridClients).BeginInit();
            SuspendLayout();
            // 
            // dataGridClients
            // 
            dataGridClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClients.Location = new Point(36, 123);
            dataGridClients.Name = "dataGridClients";
            dataGridClients.Size = new Size(721, 345);
            dataGridClients.TabIndex = 0;
            dataGridClients.CellContentClick += dataGridClients_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(61, 70);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(216, 34);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(284, 73);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(244, 32);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(543, 73);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(211, 32);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar cambios";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // ClientsInlineform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 511);
            Controls.Add(btnConfirmar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridClients);
            Name = "ClientsInlineform";
            Text = "ClientsInlineform";
            Load += ClientsInlineform_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridClients;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnConfirmar;
    }
}