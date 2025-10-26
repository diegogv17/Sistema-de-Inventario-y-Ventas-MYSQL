using InventoryApp.Domain;

namespace InventoryApp.Repositories
{
    public interface ISaleRepository
    {
        Task<int> InsertSaleAsync(MySql.Data.MySqlClient.MySqlConnection con,
                                  MySql.Data.MySqlClient.MySqlTransaction tx,
                                  Sale sale);
        Task InsertSaleDetailAsync(MySql.Data.MySqlClient.MySqlConnection con,
                                   MySql.Data.MySqlClient.MySqlTransaction tx,
                                   SaleDetail detail);

        Task<List<maestro_detalle>> GetSaleListAsync(DateTime? from = null, DateTime? to = null, int? clientId = null);
        Task<List<maestro_detalle_secundario>> GetSaleDetailsAsync(int saleId);
    }
}
