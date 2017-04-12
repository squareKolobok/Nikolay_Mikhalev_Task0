namespace Mikhalev_Nikolay_Task1.App_Start
{
    using System.Configuration;

    public static class StringDAL
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConection"].ConnectionString;
    }
}