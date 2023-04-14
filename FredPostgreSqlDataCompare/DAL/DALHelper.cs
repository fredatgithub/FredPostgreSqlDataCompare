using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace FredPostgreSqlDataCompare.DAL
{
  public static class DALHelper
  {
    public static string GetConnexionString(string databaseName = "postgres", string sqlServerName = ".")
    {
      return "SELECT datname FROM pg_database WHERE datistemplate = false;";
      //return $"Data Source={sqlServerName};Initial Catalog={databaseName};Integrated Security=True";
    }

    public static string CreateConnectionString(string host, string username, string password, string databaseName = "postgres", int port = 5432)
    {
      // connectionString="Host=servername;Port=5432;Username=pp_inter_ref;Database=dediref;CommandTimeout=0;" name="DEV_pp"

      return $"Host={host};Port={port};Username={username};Database={databaseName};CommandTimeout=0";
    }

    public static bool VerifyDatabaseConnexion(string sqlQuery, string databaseName, string sqlServerName)
    {
      bool result = false;
      string connectionString = GetConnexionString(databaseName, sqlServerName);
      // query = "SELECT TOP(1) Date FROM tableName order by date DESC";
      string query = sqlQuery;

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
          connection.Open();
          var queryResult = command.ExecuteScalar();
          if (queryResult == null)
          {
            result = true; // if no result then connexion is ok
          }
          else
          {
            result = true;
          }
        }
        catch (Exception)
        {
          result = false;
        }
        finally
        {
          connection.Close();
        }
      }

      return result;
    }

    public static string ExecuteSqlQueryOneResult(string sqlQuery, string databaseName, string sqlServerName)
    {
      string result = string.Empty;
      string connectionString = GetConnexionString(databaseName, sqlServerName);
      // query = "SELECT TOP(1) Date FROM tableName order by date DESC";
      string query = sqlQuery;

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
          connection.Open();
          var queryResult = command.ExecuteScalar();
          if (queryResult == null)
          {
            result = string.Empty;
          }
          else
          {
            result = queryResult.ToString();
          }
        }
        catch (Exception exception)
        {
          Console.WriteLine(exception.Message);
        }
        finally
        {
          connection.Close();
        }
      }

      if (result == null)
      {
        result = string.Empty;
      }

      return result;
    }

    /// <summary>
    /// Execute an SQL query.
    /// </summary>
    /// <param name="sqlQuery">The SQL query to be run.</param>
    /// <param name="databaseName">The name of the database.</param>
    /// <param name="sqlServerName">The name of the SQL server.</param>
    /// <returns>An SQL data reader type.</returns>
    public static SqlDataReader ExecuteSqlQueryManyResults(string sqlQuery, string databaseName, string sqlServerName)
    {
      SqlDataReader result = null;
      string connectionString = GetConnexionString(databaseName, sqlServerName);
      // query = "SELECT * FROM tableName";
      string query = sqlQuery;

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
          connection.Open();
          SqlDataReader queryResult = command.ExecuteReader();
          if (queryResult == null)
          {
            result = null;
          }
          else
          {
            result = queryResult;
          }
        }
        catch (Exception)
        {
          //MessageBox.show(exception.Message);
        }
        finally
        {
          connection.Close();
        }
      }

      return result;
    }

    /// <summary>
    /// Execute an SQL query.
    /// </summary>
    /// <param name="sqlQuery">The SQL query to be run.</param>
    /// <param name="databaseName">The name of the database.</param>
    /// <param name="sqlServerName">The name of the SQL server.</param>
    /// <returns>An SQL data reader type.</returns>
    public static List<string> ExecuteSqlQueryToListOfStrings(string sqlQuery, string databaseName, string sqlServerName)
    {
      List<string> result = new List<string>();
      string connectionString = GetConnexionString(databaseName, sqlServerName);
      // query = "SELECT * FROM tableName";
      string query = sqlQuery;

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
          connection.Open();
          SqlDataReader queryResult = command.ExecuteReader();
          if (queryResult == null)
          {
            result = new List<string>();
          }
          else
          {
            if (queryResult.HasRows)
            {
              while (queryResult.Read())
              {
                result.Add($"{queryResult.GetString(0)}");
              }
            }
          }
        }
        catch (Exception)
        {
          result = new List<string>();
        }
        finally
        {
          connection.Close();
        }
      }

      return result;
    }

    public static bool WriteToDatabase(string sqlQuery, DateTime requestDate, double euro, double dollar)
    {
      bool result = false;
      using (SqlConnection connection = new SqlConnection(GetConnexionString()))
      {
        //string query = "INSERT INTO [dbo].[BitCoin] ([Date], [RateEuros], [RateDollar]) VALUES(@theDate, @rateEuro, @ratedollar)";
        string query = sqlQuery;

        using (SqlCommand command = new SqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@theDate", requestDate);
          command.Parameters.AddWithValue("@rateEuro", euro);
          command.Parameters.AddWithValue("@ratedollar", dollar);

          connection.Open();
          var QueryResult = command.ExecuteNonQuery();

          // Check Error
          if (QueryResult < 0)
          {
            result = false;
          }
          else
          {
            result = true;
          }
        }
      }

      return result;
    }

    public static List<T> DataReaderMapToList<T>(IDataReader dr)
    {
      List<T> list = new List<T>();
      T obj = default(T);
      while (dr.Read())
      {
        obj = Activator.CreateInstance<T>();
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
          if (!object.Equals(dr[prop.Name], DBNull.Value))
          {
            prop.SetValue(obj, dr[prop.Name], null);
          }
        }

        list.Add(obj);
      }

      return list;
    }

    public static IEnumerable<string> GetData(string filter, Func<IDataRecord, string> factory, string databaseName, string sqlServerName, string sqlQuery)
    {
      //string sql = "SELECT * FROM [SomeTable] WHERE SomeColumn= @Filter";

      using (SqlConnection cn = new SqlConnection(GetConnexionString(databaseName, sqlServerName)))
      using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
      {
        cmd.Parameters.Add("@Filter", SqlDbType.NVarChar, 255).Value = filter;
        cn.Open();

        using (IDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            yield return factory(reader);
          }

          reader.Close();
        }
      }
    }

    public static long ExecuteQueryToLong(string connexionString, string sqlRequest)
    {
      long result = -10;
      var connexion = new NpgsqlConnection(connexionString);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          result = reader.GetInt64(0);
        }
      }
      catch (Exception)
      {
        result = -10;
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

    public static int ExecuteNonQuery(string connexionString, string sqlRequest)
    {
      var result = -10;
      string connectionStringWithPassword = connexionString;
      //if (!connexionString.Contains(Password))
      //{
      //  connectionStringWithPassword = AddPassword(connexionString);
      //}

      var connexion = new NpgsqlConnection(connectionStringWithPassword);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        command.CommandType = CommandType.Text;
        int returnRows = command.ExecuteNonQuery();
        result = returnRows;
      }
      catch (Exception)
      {
        result = -10;
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

    public static string ExecuteQueryToString(string connexionString, string sqlRequest)
    {
      var result = string.Empty;
      //if (!connexionString.Contains("Password"))
      //{
      //  connexionString += AddPassword(connexionString, false);
      //}

      var connexion = new NpgsqlConnection(connexionString);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          result = reader.GetString(0);
        }
      }
      catch (Exception exception)
      {
        result = $"erreur-{exception.Message}";
        //LOGGER.Error("Il y a eu une erreur lors de la tentative d'exécution d'une requête SQL");
        //LOGGER.Error($"La requête SQL est : {sqlRequest}");
        //LOGGER.Error($"L'erreur est : {exception.Message}");
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

    public static int ExecuteNonQueryStoredProcedureWithParameters(string connectionString, string sqlRequest, string parameterName, string parameterValue)
    {
      var result = -10;
      //if (!connectionString.Contains("Password"))
      //{
      //  connectionString += AddPassword(connectionString, false);
      //}

      var connexion = new NpgsqlConnection(connectionString);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = sqlRequest;
        command.Parameters.Add(parameterName, NpgsqlDbType.Text).Value = parameterValue;
        int returnRows = command.ExecuteNonQuery();
        result = returnRows;
      }
      catch (Exception)
      {
        result = -10;
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

    public static int ExecuteNonQueryStoredProcedureWithParameters(string connectionString, string sqlRequest, string parameterName, int parameterValue)
    {
      var result = -10;
      //if (!connectionString.Contains("Password"))
      //{
      //  connectionString += AddPassword(connectionString, false);
      //}
      
      var connexion = new NpgsqlConnection(connectionString);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = sqlRequest;
        command.Parameters.Add(parameterName, NpgsqlDbType.Integer).Value = parameterValue;
        int returnRows = command.ExecuteNonQuery();
        result = returnRows;
      }
      catch (Exception)
      {
        result = -10;
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

    public static int ExecuteNonQueryStoredProcedureWithoutParameters(string connectionString, string sqlRequest)
    {
      var result = -10;
      string connectionStringWithPassword = connectionString;
      //if (!connectionString.Contains(Password))
      //{
      //  connectionStringWithPassword = AddPassword(connectionString);
      //}

      var connexion = new NpgsqlConnection(connectionStringWithPassword);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = sqlRequest;
        // mass_synchro_mass_synchro takes 9 minutes
        // command.CommandTimeout = int.MaxValue; //1247483646;
        // timeout in connection string and not in command
        int returnRows = command.ExecuteNonQuery();
        result = returnRows;
      }
      catch (Exception)
      {
        result = -10;
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

    public static string[,] ExecuteQueryToArray(string connexionString, string sqlRequest, int numberOfColumn = 3, int numberOfRow = 4)
    {
      var result = new string[numberOfColumn, numberOfRow];
      var column = 0;
      int row = 0;
      var connexion = new NpgsqlConnection(connexionString);
      try
      {
        connexion.Open();
        var command = new NpgsqlCommand(sqlRequest, connexion);
        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          result[column, row] = (string)reader[0];
          column++;
          result[column, row] = (string)reader[1];
          column++;
          result[column, row] = (string)reader[2];
          row++;
          column = 0;
        }
      }
      catch (Exception)
      {
        result[0, 0] = "error";
      }
      finally
      {
        connexion.Close();
      }

      return result;
    }

  }
}
