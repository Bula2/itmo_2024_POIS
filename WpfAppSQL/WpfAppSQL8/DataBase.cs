using LinqToDB;
using LinqToDB.Data;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using WpfAppSQL8.Models;

namespace WpfAppSQL8
{
    public class DataBase
    {
        private readonly ConnectionStringSettings? connectionStringSettings;

        public DataBase()
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings["DBConnect.Northwind"];
        }


        public async Task<object?> ExecuteScalarMethodAsync(string commandText)
        {
            using var connection = new SqlConnection(connectionStringSettings?.ConnectionString);
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = commandText
            };
            await connection.OpenAsync();

            return await command.ExecuteScalarAsync();
        }

        public async Task<ObservableCollection<T>> ExecuteReaderMethodAsync<T>(string commandText, Dictionary<string, object>? commandParams = null) where T : class
        {
            using var connection = new SqlConnection(connectionStringSettings?.ConnectionString);

            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = commandText
            };

            foreach (var parameter in commandParams ?? [])
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();

            ObservableCollection<T> result = [];

            if (reader.HasRows)
            {
                List<string> columns = new();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    columns.Add(reader.GetName(i));
                }

                while (reader.Read())
                {
                    var dataObject = Activator.CreateInstance<T>();
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (columns.Contains(property.Name))
                        {
                            property.SetValue(dataObject, reader[property.Name] is DBNull ? null : reader[property.Name]);
                        }
                    }
                    result.Add(dataObject);
                }

                return result;
            }

            return [];
        }

        public async Task ExecuteCommandAsync(string commandText, bool isRollbackNeeded)
        {
            using SqlConnection connection = new(connectionStringSettings?.ConnectionString);
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            {
                command.CommandText = commandText;
                command.Transaction = transaction;
            }

            command.ExecuteNonQuery();


            if (!isRollbackNeeded)
            {
                await transaction.CommitAsync();
            }
            else
            {
                await transaction.RollbackAsync();
                MessageBox.Show("Был роллбэк");
            }

        }

        public async Task<ObservableCollection<T>> ExecuteProcAsync<T>(string procedureName, Dictionary<string, object>? commandParams = null) where T : class
        {
            using SqlConnection connection = new(connectionStringSettings?.ConnectionString);
            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = procedureName,
            };

            foreach (var parameter in commandParams ?? [])
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();

            ObservableCollection<T> result = [];

            if (reader.HasRows)
            {
                List<string> columns = new();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    columns.Add(reader.GetName(i));
                }

                while (reader.Read())
                {
                    var dataObject = Activator.CreateInstance<T>();
                    foreach (var property in typeof(T).GetProperties())
                    {

                        if (columns.Contains(property.Name))
                        {
                            property.SetValue(dataObject, reader[property.Name] is DBNull ? null : reader[property.Name]);
                        }
                    }
                    result.Add(dataObject);
                }

                return result;
            }

            return [];
        }

        public DataSet ExecuteCommandWithAdapterAsync(string command, string tableName)
        {
            using SqlConnection connection = new(connectionStringSettings?.ConnectionString);
            using var sqlDataAdapter = new SqlDataAdapter(command, connection);

            DataSet northWindDataset = new("Northwind");
            using var commands = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Fill(northWindDataset, tableName);
            return northWindDataset;

        }

        public ITable<T> GetTable<T>() where T : class
        {
            using var db = new DataConnection(connectionStringSettings?.ConnectionString);

            return db.GetTable<T>();
        }
    }
}
