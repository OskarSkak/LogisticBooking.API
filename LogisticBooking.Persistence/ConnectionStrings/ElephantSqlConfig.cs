namespace LogisticBooking.Persistence.ConnectionStrings
{
    public class ElephantSqlConfig : IConnectionString
    {
        public string ConnectionString { get; set; }

        public ElephantSqlConfig()
        {
            var db = "jgrkfgtz";
            var user = "jgrkfgtz";
            var passwd = "93zqL-uKm4En6FL8lwhukNr00v8OmJw_";
            var port =  5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                "dumbo.db.elephantsql.com", db, user, passwd, port);
            ConnectionString = connStr;
        }
    }
}