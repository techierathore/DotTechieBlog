using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Web.Configuration;

namespace TechieBlog.DataAccess
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
            var vConString = WebConfigurationManager.ConnectionStrings["BlogDbUrl"].ConnectionString;
            //var vDecryptedConString = AstroEncrypt.AstroLyfeDecrypt(vConString);
            //IDbConnection connection = new MySqlConnection(vDecryptedConString);
            IDbConnection connection = new MySqlConnection(vConString);
            connection.Open();
            return connection;
        }
    }
}
