using System.Configuration;

namespace IMS.Database
{
    static class Connection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["IMS_DatabaseConnectionString"].ConnectionString;
    }
}
