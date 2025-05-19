using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaEmpeño.Model;

namespace CasaEmpeño.Repositories
{
    public class ClienteRepository : RepositoryBase, IClienteRepository
    {
        public bool Add(ClienteModel cliente)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Clientes (Nombre, Paterno, Materno, Edad) VALUES (@Nombre, @Paterno, @Materno, @Edad)";
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Paterno", cliente.Paterno);
                command.Parameters.AddWithValue("@Materno", cliente.Materno);
                command.Parameters.AddWithValue("@Edad", cliente.Edad);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Edit(ClienteModel cliente)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Clientes SET 
                                      Nombre = @Nombre, 
                                      Paterno = @Paterno, 
                                      Materno = @Materno, 
                                      Edad = @Edad 
                                      WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Paterno", cliente.Paterno);
                command.Parameters.AddWithValue("@Materno", cliente.Materno);
                command.Parameters.AddWithValue("@Edad", cliente.Edad);

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
                command.CommandText = "DELETE FROM Clientes WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }
        //seleccionar la tabla de clientes 
        public IEnumerable<ClienteModel> GetAll()
        {
            var clientes = new List<ClienteModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Clientes ORDER BY Paterno, Materno, Nombre";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new ClienteModel
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Paterno = reader.GetString(2),
                            Materno = reader.GetString(3),
                            Edad = reader.GetInt32(4)
                        });
                    }
                }
            }

            return clientes;
        }

        public ClienteModel GetById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Clientes WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClienteModel
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Paterno = reader.GetString(2),
                            Materno = reader.GetString(3),
                            Edad = reader.GetInt32(4)
                        };
                    }
                    return null;
                }
            }
        }
    }
}
