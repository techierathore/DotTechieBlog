using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace BlogEngine.DataAccess
{
    public class BaseDa
    {
        //protected static void SetIdentity<T>(IDbConnection connection, Action<T> setId)
        //{
        //    dynamic identity = connection.Query("SELECT @@IDENTITY AS Id").Single();
        //    T newId = (T)identity.Id;
        //    setId(newId);
        //}

        public static IDbConnection OpenConnection()
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
