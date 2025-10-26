using InventoryApp.Domain;
using InventoryApp.Infrastructure;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace InventoryApp.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public async Task<int> InsertSaleAsync(MySqlConnection con, MySqlTransaction tx, Sale sale)
        {
            using var cmd = new MySqlCommand(
                "INSERT INTO venta (cliente_id, fecha, total) VALUES (@c, @f, @t); SELECT LAST_INSERT_ID();",
                con, tx);
            cmd.Parameters.AddWithValue("@c", sale.ClienteId);
            cmd.Parameters.AddWithValue("@f", sale.Fecha);
            cmd.Parameters.AddWithValue("@t", sale.Total);
            return Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        public async Task InsertSaleDetailAsync(MySqlConnection con, MySqlTransaction tx, SaleDetail d)
        {
            using var cmd = new MySqlCommand(
                @"INSERT INTO detalle_venta (venta_id, producto_id, cantidad, precio_unit, subtotal)
              VALUES (@v, @p, @c, @pu, @s)", con, tx);
            cmd.Parameters.AddWithValue("@v", d.VentaId);
            cmd.Parameters.AddWithValue("@p", d.ProductoId);
            cmd.Parameters.AddWithValue("@c", d.Cantidad);
            cmd.Parameters.AddWithValue("@pu", d.PrecioUnit);
            cmd.Parameters.AddWithValue("@s", d.Subtotal);
            await cmd.ExecuteNonQueryAsync();
        }
    
    public async Task<List<maestro_detalle>> GetSaleListAsync(DateTime? from = null, DateTime? to = null, int? clientId = null)
        {
            var list = new List<maestro_detalle>();
            using var con = DbConnectionFactory.Instance.CreateOpen();
            var sb = new StringBuilder();
            sb.Append(@"SELECT v.id as ventaId, v.fecha, c.nombre as cliente, v.total
                        FROM venta v
                        JOIN cliente c ON v.cliente_id = c.id
                        WHERE 1=1 ");
            if (from.HasValue) sb.Append(" AND v.fecha >= @from ");
            if (to.HasValue) sb.Append(" AND v.fecha <= @to ");
            if (clientId.HasValue) sb.Append(" AND v.cliente_id = @cid ");
            sb.Append(" ORDER BY v.fecha DESC ");

            using var cmd = new MySqlCommand(sb.ToString(), con);
            if (from.HasValue) cmd.Parameters.AddWithValue("@from", from.Value.Date);
            if (to.HasValue) cmd.Parameters.AddWithValue("@to", to.Value.Date.AddDays(1).AddTicks(-1));
            if (clientId.HasValue) cmd.Parameters.AddWithValue("@cid", clientId.Value);

            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new maestro_detalle
                {
                    VentaId = rd.GetInt32("ventaId"),
                    Fecha = rd.GetDateTime("fecha"),
                    Cliente = rd.GetString("cliente"),
                    Total = rd.GetDecimal("total")
                });
            }
            return list;
        }

        public async Task<List<maestro_detalle_secundario>> GetSaleDetailsAsync(int saleId)
        {
            var list = new List<maestro_detalle_secundario>();
            using var con = DbConnectionFactory.Instance.CreateOpen();
            using var cmd = new MySqlCommand(
                @"SELECT d.producto_id as ProductoId, p.nombre as Producto, d.cantidad as Cantidad, d.precio_unit as PrecioUnit, d.subtotal as Subtotal
                  FROM detalle_venta d
                  JOIN producto p ON d.producto_id = p.id
                  WHERE d.venta_id = @vid", con);
            cmd.Parameters.AddWithValue("@vid", saleId);
            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new maestro_detalle_secundario
                {
                    ProductoId = rd.GetInt32("ProductoId"),
                    Producto = rd.GetString("Producto"),
                    Cantidad = rd.GetInt32("Cantidad"),
                    PrecioUnit = rd.GetDecimal("PrecioUnit"),
                    Subtotal = rd.GetDecimal("Subtotal")
                });
            }
            return list;
        }
    }
}
