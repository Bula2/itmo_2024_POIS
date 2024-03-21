using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace WpfAppSQL2
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

        public async Task<ObservableCollection<T>> ExecuteReaderMethodAsync<T>(string commandText) where T: class
        {
            using var connection = new SqlConnection(connectionStringSettings?.ConnectionString);

            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = commandText
            };
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
                            property.SetValue(dataObject, reader[property.Name]);
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
                MessageBox.Show("Строки записаны в базу данных");
            }
            else
            {
                await transaction.RollbackAsync();
                MessageBox.Show("Строки не записаны в базу данных");
            }

        }

    }
}
