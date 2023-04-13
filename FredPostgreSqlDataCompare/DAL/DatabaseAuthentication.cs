namespace FredPostgreSqlDataCompare.DAL
{
  internal class DatabaseAuthentication
  {
    public string DatabaseName { get; set; }
    public string ServerName { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }

    public DatabaseAuthentication(string dbName, string serverName, string user, string pass)
    {
      DatabaseName = dbName;
      ServerName = serverName;
      UserName = user;
      UserPassword = pass;
    }

    public DatabaseAuthentication()
    {
      DatabaseName = string.Empty;
      ServerName = string.Empty;
      UserName = string.Empty;
      UserPassword = string.Empty;
    }

    public override string ToString()
    {
      return $"Data Source = {ServerName}; Initial Catalog = {DatabaseName}; Persist Security Info = True; User ID = {UserName}; Password = {UserPassword}";
    }
  }
}
