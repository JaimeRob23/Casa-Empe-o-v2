using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaEmpeño.Model;

namespace CasaEmpeño.Repositories
{
    public class ProductoRepository : RepositoryBase, IProductoRepository
    {
        public bool Add(ProductoModel producto)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Productos 
                                       (Nombre, Categoria, Estado, Precio) 
                                       VALUES (@Nombre, @Categoria, @Estado, @Precio)";
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Categoria", producto.Categoria);
                command.Parameters.AddWithValue("@Estado", producto.Estado);
                command.Parameters.AddWithValue("@Precio", producto.Precio);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Edit(ProductoModel producto)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Productos SET 
                                       Nombre = @Nombre, 
                                       Categoria = @Categoria, 
                                       Estado = @Estado, 
                                       Precio = @Precio 
                                       WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", producto.Id);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Categoria", producto.Categoria);
                command.Parameters.AddWithValue("@Estado", producto.Estado);
                command.Parameters.AddWithValue("@Precio", producto.Precio);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Productos WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            var productos = new List<ProductoModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Productos ORDER BY Nombre";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new ProductoModel
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Categoria = reader.GetString(2),
                            Estado = reader.GetString(3),
                            Precio = reader.GetDecimal(4)
                        });
                    }
                }
            }

            return productos;
        }

        public ProductoModel GetById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Productos WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ProductoModel
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Categoria = reader.GetString(2),
                            Estado = reader.GetString(3),
                            Precio = reader.GetDecimal(4)
                        };
                    }
                    return null;
                }
            }
        }
    }
}
