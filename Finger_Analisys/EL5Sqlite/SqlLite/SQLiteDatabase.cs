using System;
using System.Data.SQLite;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using EntLibContrib.Data.SQLite.Configuration;
using System.Text.RegularExpressions;

namespace EntLibContrib.Data.SQLite
{
    /// <summary>
    /// Sqlite Connection Provider
    /// </summary>
    /// <author>Manuel Soler (ModMa) 2013</author>
    /// <remarks>Based in a old source of EntLibContrib. This Sqlite 3.x has specials functions like Enviorement variables support
    /// <br />This version is not official! Designed for EL5</remarks>
    [ConfigurationElementType(typeof(SQLiteDatabaseData))]
    public class SQLiteDatabase : Database
    {
        /// <summary>
        /// Initializes a new instance of the SQLiteDatabase class.
        /// </summary>
        public SQLiteDatabase(string connectionString) : base(connectionString, SQLiteFactory.Instance)
        {
        }

        /// <summary>
        /// Creates a connection for this database.
        /// </summary>
        /// <returns>
        /// The <see cref="DbConnection"/> for this database.
        /// </returns>
        /// <seealso cref="DbConnection"/>
        /// <remarks>This system use custom variables</remarks>
        public override System.Data.Common.DbConnection CreateConnection()
        {
            //return new System.Data.SQLite.SQLiteConnection(connectionString);
            var newConnection = this.DbProviderFactory.CreateConnection();
            newConnection.ConnectionString = Regex.Replace(this.ConnectionString, @"\|CurrentDate\|",
                DateTime.Now.ToString("yyyy-MM-dd"), RegexOptions.IgnoreCase); //like |DataDirectory|

            return newConnection;
        }

        ///// <summary>
        ///// Gets the SQL string command.
        ///// </summary>
        ///// <param name="p">The p.</param>
        ///// <returns></returns>
        //public System.Data.Common.DbCommand GetSqlStringCommand(string p)
        //{
        //    return new System.Data.SQLite.SQLiteCommand(p);
        //}

        /// <summary>
        /// Retrieves parameter information from the stored procedure specified in the <see cref="SQLiteCommand"/> and populates the Parameters collection of the specified <see cref="SQLiteCommand"/> object.
        /// </summary>
        /// <param name="discoveryCommand">The <see cref="SQLiteCommand"/> to do the discovery.</param>
        protected override void DeriveParameters(System.Data.Common.DbCommand discoveryCommand)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
