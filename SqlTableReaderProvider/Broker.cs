using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableReaderProvider
{
    public class Broker
    {
        SqlConnection con;
        DataTable serversNameTable;
        DataTable databasesNameTable;
        DataTable tablesNameTable;

        public Broker()
        {
            serversNameTable = SqlDataSourceEnumerator.Instance.GetDataSources();
            con = new SqlConnection();
            con.ConnectionString = establishSqlConnectionString(0, 0);
        }

        /// <summary>
        /// Reads current sql server instances.
        /// </summary>
        /// <returns>Returns a list of instances or NULL if a sql server is not accessed </returns>
        /// 
        public List<string> SelectSqlServersNames()
        {
            List<string> listWithReadValues = null;
            if (serversNameTable != null)
            {
                listWithReadValues = new List<string>();
                foreach (DataRow servRow in serversNameTable.Rows)
                {
                    if (!string.IsNullOrEmpty(servRow["ServerName"].ToString()))
                    {
                        if (checkIfSqlServerIsRunning(servRow))
                        {
                            listWithReadValues.Add(string.Format("{0}\\{1}", servRow["ServerName"].ToString(), servRow["InstanceName"].ToString()));
                        }
                    }
                    else
                    {
                        listWithReadValues.Add(servRow["InstanceName"].ToString());
                    }
                }
            }
            return listWithReadValues;
            //return new DataView(serversNameTable).ToTable("ServerName");
        }

        /// <summary>
        /// Reads current sql databases names
        /// </summary>
        /// <param name="sqlServerIndex">Path of sqlserver from which databases names are taken</param>
        /// <returns>Returns a list of databases names</returns>
        public List<string> SelectSqlDatabasesNames(int sqlServerIndex, int sqlDatabaseIndex)
        {
            con.ConnectionString = establishSqlConnectionString(sqlServerIndex, sqlDatabaseIndex);
            if (checkIfSqlServerIsRunning(serversNameTable.Rows[sqlServerIndex]))
            {
                databasesNameTable = executeQuery("SELECT name FROM sys.databases");
                List<string> databaseNames = new List<string>();
                if (databasesNameTable != null && databasesNameTable.Rows.Count != 0)
                    foreach (DataRow row in databasesNameTable.Rows)
                    {
                        databaseNames.Add(row[0].ToString());
                    }
                return databaseNames;
            }
            return null;
        }

        /// <summary>
        /// Reads current sql table names
        /// </summary>
        /// <param name="sqlDatabaseIndex">Name of database where table names are read</param>
        /// <returns>Returns list of table names</returns>
        public List<string> SelectSqlTablesNames(int sqlServerIndex, int sqlDatabaseIndex)
        {
            if (sqlDatabaseIndex < databasesNameTable.Rows.Count && checkIfSqlServerIsRunning(serversNameTable.Rows[sqlServerIndex]))
            {
                string cmdText = string.Format(@"SELECT TABLE_NAME, TABLE_SCHEMA FROM {0}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", databasesNameTable.Rows[sqlDatabaseIndex].ItemArray[0].ToString());
                tablesNameTable = executeQuery(cmdText);

                List<string> tableNames = new List<string>();
                if (tablesNameTable != null)
                {
                    foreach (DataRow row in tablesNameTable.Rows)
                    {
                        if (row[0].ToString()[0] != '_')
                        {
                            tableNames.Add(row[1].ToString() + "." + row[0].ToString());
                        }
                    }
                }
                return tableNames;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Reads content from chosen table
        /// </summary>
        /// <param name="databaseName">The database where chosen table is store</param>
        /// <param name="tableName">The table which content will be read</param>
        /// <returns></returns>
        public DataTable ReadSqlTableContent(int databaseNameIndex, int tableNameIndex)
        {
            string cmdText = string.Format("SELECT * FROM {0}.{1}.{2}", databasesNameTable.Rows[databaseNameIndex].ItemArray[0].ToString(), tablesNameTable.Rows[tableNameIndex].ItemArray[1].ToString(), tablesNameTable.Rows[tableNameIndex].ItemArray[0].ToString());
            return executeQuery(cmdText);
        }

        /// <summary>
        /// Sets ConnectionString to current Broker instance of SqlConnection using integrated secutity option sets to 'true'. 
        /// </summary>
        /// <param name="sqlServerIndex">Index of row in DataTable instance with server names.</param>
        private string establishSqlConnectionString(int sqlServerIndex, int sqlDatabaseIndex)
        {
            string connectionString = null;
            if (serversNameTable.IsInitialized && sqlServerIndex <= serversNameTable.Rows.Count)
            {
                string initialCatalog;
                string serverPath = string.Format
                        (@"{0}\{1}", serversNameTable.Rows[sqlServerIndex].ItemArray[0].ToString(), serversNameTable.Rows[sqlServerIndex].ItemArray[1].ToString());
                if (databasesNameTable != null && sqlDatabaseIndex <= databasesNameTable.Rows.Count)
                {
                    initialCatalog = string.Format("{0}", databasesNameTable.Rows[sqlDatabaseIndex].ItemArray[0].ToString());
                }
                else
                {
                    initialCatalog = "master";
                }
                connectionString = string.Format($@"Data Source = {serverPath};Initial catalog = {initialCatalog}; Integrated security = true");
            }

            return connectionString;
        }

        /// <summary>
        /// Executes query on chosen database 
        /// </summary>
        /// <param name="query">Query to execute on a server</param>
        /// <returns>Returns a table with a result of query</returns>
        private DataTable executeQuery(string query)
        {
            DataTable tableWithContent = null;
            if (con.ConnectionString != null)
            {
                SqlCommand cmd = new SqlCommand(query, con);
                tableWithContent = new DataTable();
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    tableWithContent.Load(reader);
                }
                catch
                {
                    return null;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
            return tableWithContent;
        }

        private bool checkIfSqlServerIsRunning(DataRow sqlServerData)
        {
            ServiceController sqlServerInstanceControler = new ServiceController($"MSSQL${sqlServerData["InstanceName"].ToString()}");
            if (sqlServerInstanceControler.Status == ServiceControllerStatus.Running)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
