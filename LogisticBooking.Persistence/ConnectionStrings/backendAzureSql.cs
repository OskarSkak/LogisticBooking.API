namespace LogisticBooking.Persistence.ConnectionStrings
{
    public class backendAzureSql : ISqlBackendConnectionString
    {
        public string ConnectionString { get; set; } = "Server=tcp:logistictechnologies.database.windows.net,1433;Initial Catalog=BackendDatabase;Persist Security Info=False;User ID=LG_admin;Password=Hjallesevej50;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}