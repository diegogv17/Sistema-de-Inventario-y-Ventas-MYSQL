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
    public partial class SaleviewsForm : Form
    {
        private readonly ISaleRepository _saleRepo;
        private readonly IClientRepository _clientRepo;

        public SaleviewsForm(ISaleRepository saleRepo, IClientRepository clientRepo)
        {
            InitializeComponent();

            _saleRepo = saleRepo;
            _clientRepo = clientRepo;
        }

        private async void SaleviewsForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarTablas();
                await CargarClientesAsync();
                await CargarVentasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarTablas()
        {
            // --- Tabla de ventas ---
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.AllowUserToAddRows = false;

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "VentaId",
                Width = 60
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                Width = 150,
                DefaultCellStyle = { Format = "g" }
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total (Q)",
                DataPropertyName = "Total",
                Width = 100,
                DefaultCellStyle = { Format = "N2" }
            });

            // --- Tabla de detalle ---
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;

            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Producto",
                DataPropertyName = "Producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnit",
                Width = 100,
                DefaultCellStyle = { Format = "N2" }
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                Width = 100,
                DefaultCellStyle = { Format = "N2" }
            });

            // Evento para cambiar detalle al seleccionar venta
            dgvVentas.SelectionChanged += async (s, e) => await CargarDetalleAsync();
        }
        private async Task CargarVentasAsync()
        {
            try
            {
                dgvDetalle.DataSource = null;

                int? clienteId = (cmbClientes.SelectedValue is int id && id > 0) ? id : null;
                DateTime? desde = chkFecha.Checked ? dtDesde.Value.Date : null;
                DateTime? hasta = chkFecha.Checked ? dtHasta.Value.Date.AddDays(1).AddTicks(-1) : null;

                var ventas = await _saleRepo.GetSaleListAsync(desde, hasta, clienteId);
                dgvVentas.DataSource = ventas;

                label1.Text = ventas.Any()
                    ? $"Mostrando {ventas.Count} venta(s)."
                    : "No se encontraron resultados con esos filtros.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clientRepo.GetAllAsync();
                clientes.Insert(0, new Client { Id = 0, Nombre = "[Todos los clientes]" });

                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task CargarDetalleAsync()
        {
            if (dgvVentas.CurrentRow?.DataBoundItem is not maestro_detalle ventaSeleccionada)
            {
                dgvDetalle.DataSource = null;
                return;
            }

            try
            {
                var detalles = await _saleRepo.GetSaleDetailsAsync(ventaSeleccionada.VentaId);
                dgvDetalle.DataSource = detalles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            await CargarVentasAsync();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await CargarVentasAsync();
        }

        private async void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            await CargarVentasAsync();
        }

        private async void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CargarVentasAsync();
        }

        private async void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtDesde.Enabled = chkFecha.Checked;
            dtHasta.Enabled = chkFecha.Checked;
            await CargarVentasAsync();
        }
    }
}
