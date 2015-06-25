using System.Data;
using System.Data.SQLite;
using System.IO;

namespace WayneStudio.WordService.Core
{
    public static class SQLiteHelper
    {
        private static readonly object ConnectionStringLock = new object();

        public static string ConnectionString { get; private set; }

        private const string DefaultSchema = @"
            CREATE TABLE IF NOT EXISTS _Version (
                Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                Version TEXT NOT NULL UNIQUE
            )";

        public static void SetConnectionString(string connectionString)
        {
            lock (ConnectionStringLock)
            {
                ConnectionString = connectionString;
            }
        }

        public static void CreateDatabaseIfNotExist(string schema = "", string connectionString = "")
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = ConnectionString;

            var initializeSql = File.Exists(schema) ? File.ReadAllText(schema) : DefaultSchema;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = initializeSql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null, string connectionString = "")
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = ConnectionString;

            int affectedRows;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            return affectedRows;
        }

        public static DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters = null, string connectionString = "")
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = ConnectionString;

            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    var adapter = new SQLiteDataAdapter(command);
                    var data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }
    }
}