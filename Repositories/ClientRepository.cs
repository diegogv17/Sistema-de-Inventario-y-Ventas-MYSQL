using InventoryApp.Domain;
using InventoryApp.Infrastructure;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace InventoryApp.Repositories
{
    public class ClientRepository : IClientRepository
    {
        
        
            public async Task<List<Client>> GetAllAsync()
            {
                var list = new List<Client>();
                using var con = DbConnectionFactory.Instance.CreateOpen();
            using var cmd = new MySqlCommand("SELECT cliente_id, nombre, nit, correo, telefono, direccion FROM clientes ORDER BY nombre", con);
            using (var rd = await cmd.ExecuteReaderAsync())
            {

                while (await rd.ReadAsync())
                {
                    list.Add(new Client
                    {
                        Id = rd.GetInt32("cliente_id"),
                        Nombre = rd.GetString("nombre"),
                        Nit = rd.IsDBNull(rd.GetOrdinal("nit")) ? "" : rd.GetString("nit"),
                        Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString("correo"),
                        Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                        Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString("direccion")
                    });
                }
            }
                return list;
            }

            public async Task<Client?> GetByIdAsync(int id)
            {
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand("SELECT id, nombre, nit, correo, telefono, direccion FROM cliente WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using var rd = await cmd.ExecuteReaderAsync();
                if (await rd.ReadAsync())
                    return new Client
                    {
                        Id = rd.GetInt32("id"),
                        Nombre = rd.GetString("nombre"),
                        Nit = rd.IsDBNull(rd.GetOrdinal("nit")) ? "" : rd.GetString("nit"),
                        Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString("correo"),
                        Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                        Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString("direccion")
                    };
                return null;
            }

            public async Task<int> InsertAsync(Client c)
            {
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand(
                    "INSERT INTO cliente (nombre, nit, correo, telefono, direccion) VALUES (@n, @nit, @correo, @tel, @dir); SELECT LAST_INSERT_ID();", con);
                cmd.Parameters.AddWithValue("@n", c.Nombre);
                cmd.Parameters.AddWithValue("@nit", string.IsNullOrEmpty(c.Nit) ? (object)DBNull.Value : c.Nit);
                cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(c.Correo) ? (object)DBNull.Value : c.Correo);
                cmd.Parameters.AddWithValue("@tel", string.IsNullOrEmpty(c.Telefono) ? (object)DBNull.Value : c.Telefono);
                cmd.Parameters.AddWithValue("@dir", string.IsNullOrEmpty(c.Direccion) ? (object)DBNull.Value : c.Direccion);
                object? id = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(id);
            }

            public async Task<bool> UpdateAsync(Client c)
            {
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand("UPDATE cliente SET nombre=@n, nit=@nit, correo=@correo, telefono=@tel, direccion=@dir WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@n", c.Nombre);
                cmd.Parameters.AddWithValue("@nit", string.IsNullOrEmpty(c.Nit) ? (object)DBNull.Value : c.Nit);
                cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(c.Correo) ? (object)DBNull.Value : c.Correo);
                cmd.Parameters.AddWithValue("@tel", string.IsNullOrEmpty(c.Telefono) ? (object)DBNull.Value : c.Telefono);
                cmd.Parameters.AddWithValue("@dir", string.IsNullOrEmpty(c.Direccion) ? (object)DBNull.Value : c.Direccion);
                cmd.Parameters.AddWithValue("@id", c.Id);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand("DELETE FROM cliente WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }

            public async Task<Client?> GetByNitAsync(string nit)
            {
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand("SELECT id, nombre, nit, correo, telefono, direccion FROM cliente WHERE nit=@nit", con);
                cmd.Parameters.AddWithValue("@nit", nit);
                using var rd = await cmd.ExecuteReaderAsync();
                if (await rd.ReadAsync())
                    return new Client
                    {
                        Id = rd.GetInt32("id"),
                        Nombre = rd.GetString("nombre"),
                        Nit = rd.IsDBNull(rd.GetOrdinal("nit")) ? "" : rd.GetString("nit"),
                        Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString("correo"),
                        Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                        Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString("direccion")
                    };
                return null;
            }

            public async Task<Client?> GetByNameAsync(string nombre)
            {
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand("SELECT id, nombre, nit, correo, telefono, direccion FROM cliente WHERE nombre=@n LIMIT 1", con);
                cmd.Parameters.AddWithValue("@n", nombre);
                using var rd = await cmd.ExecuteReaderAsync();
                if (await rd.ReadAsync())
                    return new Client
                    {
                        Id = rd.GetInt32("id"),
                        Nombre = rd.GetString("nombre"),
                        Nit = rd.IsDBNull(rd.GetOrdinal("nit")) ? "" : rd.GetString("nit"),
                        Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString("correo"),
                        Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                        Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString("direccion")
                    };
                return null;
            }

            public async Task<List<Client?>> GetByEmailAsync(string email)
            {
                var list = new List<Client?>();
                using var con = DbConnectionFactory.Instance.CreateOpen();
                using var cmd = new MySqlCommand("SELECT id, nombre, nit, correo, telefono, direccion FROM cliente WHERE correo LIKE @q", con);
                cmd.Parameters.AddWithValue("@q", $"%{email}%");
                using var rd = await cmd.ExecuteReaderAsync();
                while (await rd.ReadAsync())
                {
                    list.Add(new Client
                    {
                        Id = rd.GetInt32("id"),
                        Nombre = rd.GetString("nombre"),
                        Nit = rd.IsDBNull(rd.GetOrdinal("nit")) ? "" : rd.GetString("nit"),
                        Correo = rd.IsDBNull(rd.GetOrdinal("correo")) ? "" : rd.GetString("correo"),
                        Telefono = rd.IsDBNull(rd.GetOrdinal("telefono")) ? "" : rd.GetString("telefono"),
                        Direccion = rd.IsDBNull(rd.GetOrdinal("direccion")) ? "" : rd.GetString("direccion")
                    });
                }
                return list;
            }
        
    }
}
