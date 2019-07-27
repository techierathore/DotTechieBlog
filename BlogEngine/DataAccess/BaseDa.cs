using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Linq;

namespace BlogEngine.DataAccess
{
    public abstract class BaseDa
    {
        protected static void SetIdentity<T>(IDbConnection connection, Action<T> setId)
        {
            dynamic identity = connection.Query("SELECT @@IDENTITY AS Id").Single();
            var newId = (T)identity.Id;
            setId(newId);
        }

        protected static IDbConnection OpenConnection()
        {
            var vConString = ConfigurationManager.ConnectionStrings["BlogDbUrl"].ConnectionString;
            //var vDecryptedConString = AstroEncrypt.AstroLyfeDecrypt(vConString);
            //IDbConnection connection = new MySqlConnection(vDecryptedConString);
            IDbConnection connection = new MySqlConnection(vConString);
            connection.Open();
            return connection;
        }
    }
}
