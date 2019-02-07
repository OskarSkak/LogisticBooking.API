namespace LogisticBooking.Persistence.ConnectionStrings
{
    public class SqlConnectionString : ISqlConnectionString
    {
        public string ConnectionString { get; set; } =
            "Server=tcp:logisticsolutions.database.windows.net,1433;Initial Catalog=LogisticSolution.Identity;Persist Security Info=False;User ID=caspha17;Password=Hansen93!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
    }
}