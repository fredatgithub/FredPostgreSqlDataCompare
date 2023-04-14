namespace FredPostgreSqlDataCompare.DAL
{
  internal class DatabaseAuthentication
  {
    public string DatabaseName { get; set; }
    public string ServerName { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public int Port { get; set; }
    public string Schema { get; set; }

    public DatabaseAuthentication(string dbName, string serverName, string user, string pass, int port = 5432, string schema = "public")
    {
      DatabaseName = dbName;
      ServerName = serverName;
      UserName = user;
      UserPassword = pass;
      Port = port;
      Schema = schema;
    }

    public DatabaseAuthentication()
    {
      DatabaseName = "postgres";
      ServerName = string.Empty;
      UserName = "postgres";
      UserPassword = string.Empty;
      Port = 5432;
      Schema = "public";
    }

    public override string ToString()
    {
      //Server = 127.0.0.1; Port = 5432; Database = myDataBase; User Id = myUsername; Password = myPassword; CommandTimeout = 20;
      return $"Host={ServerName};Port={Port};Database={DatabaseName};User Id={UserName};CommandTimeout=0;Password={UserPassword}";
    }
  }
}
