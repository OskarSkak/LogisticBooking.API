namespace LogisticBooking.Persistence.ConnectionStrings
{
    public interface ISqlBackendConnectionString
    {
        string ConnectionString { get; set; }
    }
}