using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace TaskDB
{
    public static class DatabaseConnection
    {
        private const string MasterConn =
            @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["TaskDB"].ConnectionString; }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public static void EnsureDatabase()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);

            string mdf = Path.Combine(dataDir, "TaskDB.mdf");
            string ldf = Path.Combine(dataDir, "TaskDB_log.ldf");

            if (!File.Exists(mdf))
            {
                string tmp = "TaskDB_" + Guid.NewGuid().ToString("N");
                using (var cn = new SqlConnection(MasterConn))
                {
                    cn.Open();
                    string create = string.Format(
                        "CREATE DATABASE [{0}] ON (NAME = N'TaskDB', FILENAME = N'{1}') " +
                        "LOG ON (NAME = N'TaskDB_log', FILENAME = N'{2}')", tmp, mdf, ldf);
                    using (var cmd = new SqlCommand(create, cn)) cmd.ExecuteNonQuery();

                    using (var cmd = new SqlCommand(
                        "ALTER DATABASE [" + tmp + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                        "EXEC sp_detach_db @dbname = N'" + tmp + "', @skipchecks = 'true';", cn))
                        cmd.ExecuteNonQuery();
                }
            }

            const string sql =
                "IF OBJECT_ID(N'dbo.Tareas', N'U') IS NULL " +
                "CREATE TABLE dbo.Tareas (" +
                " Id INT IDENTITY(1,1) PRIMARY KEY," +
                " Titulo NVARCHAR(100) NOT NULL," +
                " Descripcion NVARCHAR(500) NULL," +
                " Estado NVARCHAR(20) NOT NULL DEFAULT 'Pendiente'," +
                " FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()," +
                " CONSTRAINT CK_Tareas_Estado CHECK (Estado IN ('Pendiente','Completada')))";

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
