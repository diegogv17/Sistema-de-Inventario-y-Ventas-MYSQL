using InventoryApp.Domain;
using InventoryApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinForms
{
    public partial class ClientsInlineform : Form
    {
        private readonly IClientRepository _clientRepo;

        private DataTable _table = new();
        private readonly BindingSource _bs = new();
        private bool _persisting = false;

        public ClientsInlineform(IClientRepository clientRepo)
        {
            InitializeComponent();
            _clientRepo = clientRepo;

        }

        private async void ClientsInlineform_Load(object sender, EventArgs e)
        {
            await LoadTableAsync();
            SetupGrid();

        }
        private async System.Threading.Tasks.Task LoadTableAsync()
        {
            _table = BuildSchema();

            var clients = await _clientRepo.GetAllAsync();
            foreach (var c in clients)
            {
                var r = _table.NewRow();
                r["Id"] = c.Id;
                r["Nombre"] = c.Nombre;
                r["Correo"] = c.Correo;
                r["Telefono"] = c.Telefono;
                r["Direccion"] = c.Direccion;
                _table.Rows.Add(r);
            }

            _table.AcceptChanges();
            _bs.DataSource = _table;
            dataGridClients.DataSource = _bs;
        }

        private static DataTable BuildSchema()
        {
            var t = new DataTable("cliente");
            t.Columns.Add("Id", typeof(int));
            t.Columns.Add("Nombre", typeof(string));
            t.Columns.Add("Correo", typeof(string));
            t.Columns.Add("Telefono", typeof(string));
            t.Columns.Add("Direccion", typeof(string));
            return t;
        }
        private void DataGridClients_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var colName = dataGridClients.Columns[e.ColumnIndex].Name;
            var value = e.FormattedValue?.ToString() ?? "";

            if (colName == "Nombre" && string.IsNullOrWhiteSpace(value))
            {
                e.Cancel = true;
                dataGridClients.Rows[e.RowIndex].ErrorText = "El nombre es requerido.";
            }
            else dataGridClients.Rows[e.RowIndex].ErrorText = string.Empty;

            if (colName == "Correo" && !string.IsNullOrWhiteSpace(value))
            {
                if (!value.Contains("@") || !value.Contains("."))
                {
                    e.Cancel = true;
                    dataGridClients.Rows[e.RowIndex].ErrorText = "Correo inválido.";
                }
            }
        }
        private async void DataGridClients_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row?.DataBoundItem is not DataRowView drv) return;

            var resp = MessageBox.Show("¿Eliminar este cliente?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) { e.Cancel = true; return; }

            var r = drv.Row;
            if (r["Id"] == DBNull.Value || Convert.ToInt32(r["Id"]) == 0) return;

            var ok = await _clientRepo.DeleteAsync(Convert.ToInt32(r["Id"]));
            if (!ok) e.Cancel = true;
        }
        // ================================
        // Configuración del DataGrid
        // ================================
        private void SetupGrid()
        {
            dataGridClients.AutoGenerateColumns = true;
            dataGridClients.AllowUserToAddRows = true;
            dataGridClients.AllowUserToDeleteRows = true;
            dataGridClients.MultiSelect = false;
            dataGridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dataGridClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridClients.CellValidating += DataGridClients_CellValidating;
            dataGridClients.CellValidated += DataGridClients_CellValidated;
            dataGridClients.UserDeletingRow += DataGridClients_UserDeletingRow;


        }

        private async void DataGridClients_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_persisting) return;
            if (e.RowIndex < 0) return;

            var row = dataGridClients.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            dataGridClients.EndEdit();
            _bs.EndEdit();

            if (row.DataBoundItem is not DataRowView drv) return;
            var r = drv.Row;

            try
            {
                _persisting = true;

                // INSERT
                if ((r.RowState == DataRowState.Added || r["Id"] == DBNull.Value || Convert.ToInt32(r["Id"]) == 0))
                {
                    var c = new Client
                    {
                        Nombre = r["Nombre"]?.ToString() ?? "",
                        Correo = r["Correo"]?.ToString() ?? "",
                        Telefono = r["Telefono"]?.ToString() ?? "",
                        Direccion = r["Direccion"]?.ToString() ?? ""
                    };
                    int newId = await _clientRepo.InsertAsync(c);
                    r["Id"] = newId;
                    r.AcceptChanges();
                }

                // UPDATE
                else if (r.RowState == DataRowState.Modified)
                {
                    var c = new Client
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Nombre = r["Nombre"]?.ToString() ?? "",
                        Correo = r["Correo"]?.ToString() ?? "",
                        Telefono = r["Telefono"]?.ToString() ?? "",
                        Direccion = r["Direccion"]?.ToString() ?? ""
                    };
                    var ok = await _clientRepo.UpdateAsync(c);
                    if (ok) r.AcceptChanges();
                    else r.RowError = "No se pudo actualizar.";
                }
            }
            catch (Exception ex)
            {
                r.RowError = ex.Message;
            }
            finally
            {
                _persisting = false;
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridClients.CurrentRow?.DataBoundItem is not DataRowView drv) return;

            var resp = MessageBox.Show("¿Eliminar este cliente?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            var r = drv.Row;
            if (r["Id"] != DBNull.Value && Convert.ToInt32(r["Id"]) > 0)
            {
                var ok = await _clientRepo.DeleteAsync(Convert.ToInt32(r["Id"]));
                if (ok) _table.Rows.Remove(r);
                else MessageBox.Show("No se pudo eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _table.Rows.Remove(r); // si nunca se guardó en BD
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridClients.CurrentRow == null) return;
            dataGridClients.BeginEdit(true);
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            dataGridClients.EndEdit();
            _bs.EndEdit();

            foreach (DataRow r in _table.Rows)
            {
                if (r.RowState == DataRowState.Added)
                {
                    var c = new Client
                    {
                        Nombre = r["Nombre"]?.ToString() ?? "",
                        Correo = r["Correo"]?.ToString() ?? "",
                        Telefono = r["Telefono"]?.ToString() ?? "",
                        Direccion = r["Direccion"]?.ToString() ?? ""
                    };
                    int newId = await _clientRepo.InsertAsync(c);
                    r["Id"] = newId;
                    r.AcceptChanges();
                }
                else if (r.RowState == DataRowState.Modified)
                {
                    var c = new Client
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Nombre = r["Nombre"]?.ToString() ?? "",
                        Correo = r["Correo"]?.ToString() ?? "",
                        Telefono = r["Telefono"]?.ToString() ?? "",
                        Direccion = r["Direccion"]?.ToString() ?? ""
                    };
                    await _clientRepo.UpdateAsync(c);
                    r.AcceptChanges();
                }
            }

            MessageBox.Show("Cambios guardados correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
