namespace FredPostgreSqlDataCompare.DAL
{
  public static class ConnectionSqlServer
  {
    public static string GetGeneralConnexionString()
    {
      return "Data Source = {serverName}; Initial Catalog = {databaseName}; Persist Security Info = True; User ID = {userName}; Password = {password}";
    }

    public static string GetAllTableNamesRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'U'";
    }

    public static string GetAllDefaultConstraintsRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'D'";
    }

    public static string GetAllForeignKeysRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'F'";
    }

    public static string GetAllFunctionsRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'FN'";
    }

    public static string GetAllDatabaseNamesRequest()
    {
      return "use master  select name from sys.databases where name NOT IN ('master', 'model', 'msdb', 'tempdb');";
    }

    public static string GetAllStoredProcedureRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'P'";
    }

    public static string GetAllPrimaryKeyRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'PK'";
    }

    public static string GetAllServiceQueueRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'SQ'";
    }

    public static string GetAllTriggerRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'TR'";
    }

    public static string GetAllViewRequest()
    {
      return "SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'V'";
    }

    public static string GetAllColumnFromATableRequest(string tableName)
    {
      //SELECT table_catalog, table_schema, table_name, column_name, data_type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'facture'
      return $"SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{tableName}'";
    }
  }
}
