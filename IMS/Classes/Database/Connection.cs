using System.Configuration;

namespace IMS.Database
{
    //this class is just used to hold our main connection string.
    //since there are so many places connection strings are used, it seemed simpler to supply one central one
    //so if it changed in the future it only had to be changed once.
    static class Connection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["IMS_DatabaseConnectionString"].ConnectionString;
    }
}
