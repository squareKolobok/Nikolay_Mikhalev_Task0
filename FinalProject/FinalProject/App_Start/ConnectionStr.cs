using System.Configuration;

namespace FinalProject.App_Start
{
    public static class ConnectionStr
    {
        public static string String = ConfigurationManager.ConnectionStrings["TestConection"].ConnectionString;
    }
}