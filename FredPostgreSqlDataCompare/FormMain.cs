using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FredPostgreSqlDataCompare.DAL;
using FredPostgreSqlDataCompare.Properties;
using Tools;

namespace FredPostgreSqlDataCompare
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private bool bothAuthenticationAreOk = false;
    private bool sourceAuthenticationIsOk = false;
    private bool targetAuthenticationIsOk = false;

    /// <summary>
    /// Key to be used to encrypt source parameters.
    /// </summary>
    private const string SourceKeyFilename = "SourceKey.pidb";
    private const string SourceSaltFilename = "SourceSalt.pidb";

    /// <summary>
    /// All the values encrypted for source parameters.
    /// </summary>
    private const string SourceValue1Filename = "SourceValue1.pidb";
    private const string SourceValue2Filename = "SourceValue2.pidb";
    private const string SourceValue3Filename = "SourceValue3.pidb";
    private const string SourceValue4Filename = "SourceValue4.pidb";
    private const string SourceValue5Filename = "SourceValue5.pidb";

    /// <summary>
    /// Key to be used to encrypt target parameters.
    /// </summary>
    private const string TargetKeyFilename = "TargetKey.pidb";
    private const string TargetSaltFilename = "TargetSalt.pidb";

    /// <summary>
    /// All the values encrypted for source parameters.
    /// </summary>
    private const string TargetValue1Filename = "TargetValue1.pidb";
    private const string TargetValue2Filename = "TargetValue2.pidb";
    private const string TargetValue3Filename = "TargetValue3.pidb";
    private const string TargetValue4Filename = "TargetValue4.pidb";
    private const string TargetValue5Filename = "TargetValue5.pidb";

    private void FormMain_Load(object sender, EventArgs e)
    {
      LoadComboboxes();
      LoadAuthentificationParameters();
      GetWindowValue();
      DisplayTitle();
      DisableNotImplementedMenuItems();
    }

    private bool AllFilesExist(bool source = true)
    {
      if (source)
      {
        return File.Exists(SourceKeyFilename) && File.Exists(SourceSaltFilename) && File.Exists(SourceValue1Filename) && File.Exists(SourceValue2Filename) && File.Exists(SourceValue3Filename) && File.Exists(SourceValue4Filename) && File.Exists(SourceValue5Filename);
      }
      else
      {
        return File.Exists(TargetKeyFilename) && File.Exists(TargetSaltFilename) && File.Exists(TargetValue1Filename) && File.Exists(TargetValue2Filename) && File.Exists(TargetValue3Filename) && File.Exists(TargetValue4Filename) && File.Exists(TargetValue5Filename);
      }
    }

    private void LoadAuthentificationParameters()
    {
      // source parameters
      if (checkBoxSourceRememberCredentials.Checked)
      {
        if (AllFilesExist())
        {
          var encryptionKey = Helper.ReadFile(SourceKeyFilename);
          if (!encryptionKey[Helper.FirstElement].StartsWith(Helper.OK))
          {
            MessageBox.Show("There was an error while trying to read the encryption key", "Error while reading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          var encryptionSalt = Helper.ReadFile(SourceSaltFilename);

          encryptionKey = encryptionKey.Skip(Helper.One).ToArray();
          var values = Helper.ReadFile(SourceValue1Filename);
          if (!values[Helper.FirstElement].StartsWith(Helper.OK))
          {
            MessageBox.Show("There was an error while trying to read the values file", "Error while reading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          values = values.Skip(Helper.One).ToArray();
          var sourceServerName = Helper.DecodeToStringWithAes(values[Helper.FirstElement], encryptionKey[Helper.FirstElement], encryptionKey[Helper.SecondElement]); 
          var sourcePortNumber = Helper.DecodeToStringWithAes(values[Helper.SecondElement], encryptionKey[Helper.FirstElement], encryptionKey[Helper.SecondElement]);
          var sourceUserName = Helper.DecodeToStringWithAes(values[Helper.ThirdElement], encryptionKey[Helper.FirstElement], encryptionKey[Helper.SecondElement]);
          var sourcePassword = Helper.DecodeToStringWithAes(values[Helper.FourthElement], encryptionKey[Helper.FirstElement], encryptionKey[Helper.SecondElement]);
          var sourceDatabaseName = Helper.DecodeToStringWithAes(values[Helper.FithElement], encryptionKey[Helper.FirstElement], encryptionKey[Helper.SecondElement]);

          textBoxSourceServer.Text = sourceServerName;
          textBoxSourcePort.Text = sourcePortNumber;
          textBoxSourceName.Text = sourceUserName;
          textBoxSourcePassword.Text = sourcePassword;
          textBoxDatabaseNameSource.Text = sourceDatabaseName;
        }
      }

      // target parameters
      if (checkBoxSourceRememberCredentials.Checked)
      {
        if (AllFilesExist(false))
        {
          var targetServerName = "to be decrypted";
          var targetPortNumber = "to be decrypted";
          var targetUserName = "to be decrypted";
          var targetUserPassword = "to be decrypted";
          var targetDatabaseName = "to be decrypted";

          textBoxTargetServer.Text = targetServerName;
          textBoxTargetPort.Text = targetPortNumber;
          textBoxTargetName.Text = targetUserName;
          textBoxTargetPassword.Text = targetUserPassword;
          textBoxDatabaseNameTarget.Text = targetDatabaseName;
        }
      }
    }

    private void SaveAuthentificationParameters()
    {
      // source parameters
      if (checkBoxSourceRememberCredentials.Checked)
      {
        if (!string.IsNullOrEmpty(textBoxSourceName.Text) && !string.IsNullOrEmpty(textBoxSourcePassword.Text) && !string.IsNullOrEmpty(textBoxSourcePort.Text) && !string.IsNullOrEmpty(textBoxSourceServer.Text))
        {
          if (File.Exists(SourceKeyFilename) && File.Exists(SourceSaltFilename))
          {
            // if files exist then we read the key already generated

          }
          else
          {
            // create a key file
            var keys = Helper.CreateAesCryptoService();
            var result = Helper.WriteToFile(keys[Helper.FirstElement], SourceKeyFilename);
            var errorMessage = $"Error while trying to write a file on the disk, the error is: {result[Helper.SecondElement]}";
            if (result[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }

            result = Helper.WriteToFile(keys[Helper.SecondElement], SourceSaltFilename);
            if (result[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }

            var sourceServerName = textBoxSourceServer.Text;
            var sourcePortNumber = textBoxSourcePort.Text;
            var sourceUserName = textBoxSourceName.Text;
            var sourceUserPassword = textBoxSourcePassword.Text;
            var sourceDatabaseName = textBoxDatabaseNameSource.Text;
            // encryption
            var sourceServerNameEncrypted = Helper.EncryptStringToBytesWithAes(sourceServerName, keys[Helper.FirstElement], keys[Helper.SecondElement]);
            var sourcePortNumberEncrypted = Helper.EncryptStringToBytesWithAes(sourcePortNumber, keys[Helper.FirstElement], keys[Helper.SecondElement]);
            var sourceUserNameEncrypted = Helper.EncryptStringToBytesWithAes(sourceUserName, keys[Helper.FirstElement], keys[Helper.SecondElement]);
            var sourcePasswordEncrypted = Helper.EncryptStringToBytesWithAes(sourceUserPassword, keys[Helper.FirstElement], keys[Helper.SecondElement]);
            var sourceDatabaseNameEncrypted = Helper.EncryptStringToBytesWithAes(sourceDatabaseName, keys[Helper.FirstElement], keys[Helper.SecondElement]);

            var resultWritingToFile = Helper.WriteToFile(sourceServerNameEncrypted, SourceValue1Filename);
            if (resultWritingToFile[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }

            resultWritingToFile = Helper.WriteToFile(sourcePortNumberEncrypted, SourceValue2Filename);
            if (resultWritingToFile[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }

            resultWritingToFile = Helper.WriteToFile(sourceUserNameEncrypted, SourceValue3Filename);
            if (resultWritingToFile[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }

            resultWritingToFile = Helper.WriteToFile(sourcePasswordEncrypted, SourceValue4Filename);
            if (resultWritingToFile[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }

            resultWritingToFile = Helper.WriteToFile(sourceDatabaseNameEncrypted, SourceValue5Filename);
            if (resultWritingToFile[Helper.FirstElement] == "ko")
            {
              MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              return;
            }
          }
        }
      }
    }

    private void DisableNotImplementedMenuItems()
    {
      // enable them whenever code is created
      nouveauToolStripMenuItem.Visible = false;
      ouvrirToolStripMenuItem.Visible = false;
      toolStripSeparator.Visible = false;
      enregistrerToolStripMenuItem.Visible = false;
      enregistrersousToolStripMenuItem.Visible = false;
      toolStripSeparator1.Visible = false;
      imprimerToolStripMenuItem.Visible = false;
      aperçuavantimpressionToolStripMenuItem.Visible = false;
      toolStripSeparator2.Visible = false;

      annulerToolStripMenuItem.Visible = true;

      outilsToolStripMenuItem.Visible = false;

      aideToolStripMenuItem.Visible = true;
      sommaireToolStripMenuItem.Visible = false;
      indexToolStripMenuItem.Visible = false;
      rechercherToolStripMenuItem.Visible = false;
    }

    private void LoadComboboxes()
    {
      textBoxSourceServer.Text = Settings.Default.comboBoxServerSourceItems;
      textBoxTargetServer.Text = Settings.Default.comboBoxServerTargetItems;
      checkBoxSourceRememberCredentials.Checked = Settings.Default.CheckBoxSourceRememberCredentials;
      checkBoxTargetRememberCredentials.Checked = Settings.Default.CheckBoxTargetRememberCredentials;

      comboBoxSourceSchema.Items.Clear();
      string previousSchemaSource = Settings.Default.comboBoxSourceSchemaItems;
      if (string.IsNullOrEmpty(previousSchemaSource))
      {
        comboBoxSourceSchema.Items.Add("public");
      }
      else
      {
        var previousSchemasSourceArray = previousSchemaSource.Split(Punctuation.SemiColon);
        comboBoxSourceSchema.Items.AddRange(previousSchemasSourceArray);
      }

      comboBoxTargetSchema.Items.Clear();
      string previousSchemaTarget = Settings.Default.comboBoxTargetSchemaItems;
      if (string.IsNullOrEmpty(previousSchemaTarget))
      {
        comboBoxTargetSchema.Items.Add("public");
      }
      else
      {
        var previousSchemasTargetArray = previousSchemaTarget.Split(Punctuation.SemiColon);
        comboBoxTargetSchema.Items.AddRange(previousSchemasTargetArray);
      }

      comboBoxSourceSchema.SelectedIndex = Settings.Default.comboBoxSourceSchemaIndex;
      comboBoxTargetSchema.SelectedIndex = Settings.Default.comboBoxTargetSchemaIndex;

      checkBoxSourceRememberCredentials.Checked = Settings.Default.CheckBoxSourceRememberCredentials;
      checkBoxTargetRememberCredentials.Checked = Settings.Default.CheckBoxTargetRememberCredentials;

      textBoxTargetName.Text = Settings.Default.textBoxTargetName;
      textBoxSourceName.Text = Settings.Default.textBoxSourceName;

      comboBoxSourceDatabase.Items.Clear();
      foreach (string item in Settings.Default.comboBoxSourceDatabase.Split(Punctuation.SemiColon))
      {
        comboBoxSourceDatabase.Items.Add(item);
      }

      comboBoxTargetDatabase.Items.Clear();
      foreach (string item in Settings.Default.comboBoxTargetDatabase.Split(Punctuation.SemiColon))
      {
        comboBoxTargetDatabase.Items.Add(item);
      }
    }

    private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (bothAuthenticationAreOk)
      {
        SaveAuthentificationParameters();
      }

      SaveWindowValue();
      Application.Exit();
    }

    private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      SaveWindowValue();
    }

    private void SaveWindowValue()
    {
      Settings.Default.WindowHeight = Height;
      Settings.Default.WindowWidth = Width;
      Settings.Default.WindowLeft = Left;
      Settings.Default.WindowTop = Top;
      Settings.Default.comboBoxServerSourceItems = textBoxSourceServer.Text;
      Settings.Default.comboBoxServerTargetItems = textBoxTargetServer.Text;
      Settings.Default.CheckBoxSourceRememberCredentials = checkBoxSourceRememberCredentials.Checked;
      Settings.Default.CheckBoxTargetRememberCredentials = checkBoxTargetRememberCredentials.Checked;
      Settings.Default.Save();
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
      textBoxSourcePort.Text = Settings.Default.TextBoxSourcePort;
      textBoxTargetPort.Text = Settings.Default.TextBoxTargetPort;

      Settings.Default.Save();
    }

    private string DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      return $"-V{fvi.FileMajorPart}.{fvi.FileMinorPart}.{fvi.FileBuildPart}";
    }

    public static string GetFrameworkDescription()
    {
      var version = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
      return version;
    }

    private void ButtonCopyServerName_Click(object sender, EventArgs e)
    {
      textBoxTargetServer.Text = textBoxSourceServer.Text;
    }

    private void ButtonCompareCompareNow_Click(object sender, EventArgs e)
    {
      //tabPageDataSources.SendToBack();
    }

    private void ButtonSourceRefresh_Click(object sender, EventArgs e)
    {
      // refresh the list of source database combobox
      DatabaseAuthentication dbConnexion = new DatabaseAuthentication
      {
        UserName = textBoxSourceName.Text,
        UserPassword = textBoxSourcePassword.Text,
        ServerName = textBoxSourceServer.Text,
        Port = int.Parse(textBoxSourcePort.Text)
        //DatabaseName = "master"
      };

      RecordParameters();
      string sqlQuery = ConnectionSqlServer.GetAllDatabaseNamesRequest();
      //string sqlQuery = "select name from sys.databases";
      if (!DALHelper.VerifyDatabaseConnexion(sqlQuery, dbConnexion.DatabaseName, dbConnexion.ServerName))
      {
        MessageBox.Show($"Cannot connect to the database: {dbConnexion.DatabaseName} on the server: {dbConnexion.ServerName}");
        return;
      }

      List<string> listOfDatabaseName = DALHelper.ExecuteSqlQueryToListOfStrings(sqlQuery, "master", Dns.GetHostName());

      comboBoxSourceDatabase.Items.Clear();
      foreach (string name in listOfDatabaseName)
      {
        comboBoxSourceDatabase.Items.Add(name);
      }
    }

    private void RecordParameters()
    {
      // recording controls states
      Settings.Default.CheckBoxSourceRememberCredentials = checkBoxSourceRememberCredentials.Checked;
      Settings.Default.CheckBoxTargetRememberCredentials = checkBoxTargetRememberCredentials.Checked;

      Settings.Default.Save();

      //if (comboBoxSourceAuthentication.SelectedIndex != -1 && comboBoxSourceAuthentication.SelectedItem.ToString().ToLower().Replace(" ", "") == AuthenticationTypes.AuthenticationSQLServer.ToString().ToLower() && string.IsNullOrEmpty(textBoxSourcePassword.Text))
      //{
      //  MessageBox.Show("The password cannot be empty if SQL authentication is choosen");
      //  return;
      //}

      //if (comboBoxSourceAuthentication.SelectedIndex != -1 && comboBoxSourceAuthentication.SelectedItem.ToString().ToLower().Replace(" ", "") == AuthenticationTypes.AuthenticationSQLServer.ToString().ToLower() && string.IsNullOrEmpty(textBoxSourceName.Text))
      //{
      //  MessageBox.Show("The user name cannot be empty if SQL authentication is choosen");
      //  return;
      //}

      Settings.Default.textBoxSourceServer = textBoxSourceServer.Text;
      Settings.Default.textBoxTargetServer = textBoxTargetServer.Text;

      //saving controls state
      //Settings.Default.ComboBoxSourceAuthenticationIndex = comboBoxSourceAuthentication.SelectedIndex;
      //Settings.Default.ComboBoxTargetAuthenticationIndex = comboBoxTargetAuthentication.SelectedIndex;
      Settings.Default.CheckBoxSourceRememberCredentials = checkBoxSourceRememberCredentials.Checked;
      Settings.Default.CheckBoxTargetRememberCredentials = checkBoxTargetRememberCredentials.Checked;

      Settings.Default.textBoxTargetName = textBoxTargetName.Text;
      Settings.Default.textBoxSourceName = textBoxSourceName.Text;

      //Settings.Default.comboBoxSourceDatabaseSource = comboBoxSourceDatabaseSource.SelectedIndex;
      //Settings.Default.comboBoxTargetDatabaseTarget = comboBoxTargetDatabaseTarget.SelectedIndex;

      //comboBoxTargetDatabase
      string oneString = string.Empty;
      if (comboBoxTargetDatabase.Items.Count > 0)
      {
        foreach (var item in comboBoxTargetDatabase.Items)
        {
          oneString += $"{item};";
        }

        oneString = oneString.TrimEnd(';');
      }

      Settings.Default.comboBoxTargetDatabase = oneString;

      //comboBoxTargetDatabase
      oneString = string.Empty;
      if (comboBoxSourceDatabase.Items.Count > 0)
      {
        foreach (var item in comboBoxSourceDatabase.Items)
        {
          oneString += $"{item};";
        }

        oneString = oneString.TrimEnd(';');
      }

      Settings.Default.comboBoxSourceDatabase = oneString;
      Settings.Default.Save();
    }

    private void ButtonTestConnection_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(textBoxSourceServer.Text))
      {
        MessageBox.Show("You have to choose a source server", "No server selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        sourceAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxSourcePort.Text))
      {
        MessageBox.Show("You have to choose a source port number", "No port number", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        sourceAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxSourceName.Text))
      {
        MessageBox.Show("You have to choose a source username", "No username", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        sourceAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxSourcePassword.Text))
      {
        MessageBox.Show("You have to choose a source password", "No password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        sourceAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxDatabaseNameSource.Text))
      {
        MessageBox.Show("You have to choose a database to conenct to", "No database", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        sourceAuthenticationIsOk = false;
        return;
      }

      DatabaseAuthentication dbConnexion = new DatabaseAuthentication
      {
        UserName = textBoxSourceName.Text,
        UserPassword = textBoxSourcePassword.Text,
        ServerName = textBoxSourceServer.Text,
        Port = int.Parse(textBoxSourcePort.Text),
        DatabaseName = textBoxDatabaseNameSource.Text
      };

      string sqlQuery = ConnectionSqlServer.TestRequest();
      if (DALHelper.TestConnection(dbConnexion.ToString()))
      {
        MessageBox.Show("Connection OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        sourceAuthenticationIsOk = true;
      }
      else
      {
        MessageBox.Show($"Cannot connect to the database: {dbConnexion.DatabaseName} on the server: {dbConnexion.ServerName}", "Connection KO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        sourceAuthenticationIsOk = false;
      }

      CheckBothAuthentication();
    }

    private void CheckBothAuthentication()
    {
      bothAuthenticationAreOk = sourceAuthenticationIsOk && targetAuthenticationIsOk;
    }

    private void ButtonTestconnectionTarget_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(textBoxTargetServer.Text))
      {
        MessageBox.Show("You have to choose a target server", "No server selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        targetAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxTargetPort.Text))
      {
        MessageBox.Show("You have to choose a target port number", "No port number", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        targetAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxTargetName.Text))
      {
        MessageBox.Show("You have to choose a target username", "No username", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        targetAuthenticationIsOk = false;
        return;
      }

      if (string.IsNullOrEmpty(textBoxTargetPassword.Text))
      {
        MessageBox.Show("You have to choose a source password", "No password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        targetAuthenticationIsOk = false;
        return;
      }

      DatabaseAuthentication dbConnexion = new DatabaseAuthentication
      {
        UserName = textBoxTargetName.Text,
        UserPassword = textBoxTargetPassword.Text,
        ServerName = textBoxTargetServer.Text,
        Port = int.Parse(textBoxTargetPort.Text),
        DatabaseName = "postgres"
      };

      string sqlQuery = ConnectionSqlServer.TestRequest();
      if (DALHelper.TestConnection(dbConnexion.ToString()))
      {
        MessageBox.Show("Connection OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        targetAuthenticationIsOk = true;
      }
      else
      {
        MessageBox.Show($"Cannot connect to the database: {dbConnexion.DatabaseName} on the server: {dbConnexion.ServerName}", "Connection KO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        targetAuthenticationIsOk = false;
      }

      CheckBothAuthentication();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBoxApplication aboutBox1 = new AboutBoxApplication();
      aboutBox1.ShowDialog();
    }

    private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tabControlMain.SelectedIndex == 1 && !bothAuthenticationAreOk)
      {
        MessageBox.Show("Both connections source and target have not been tested successfully\nYou need to test them both before entering Table tab", "Both connections not tested", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        tabControlMain.SelectedIndex = 0;
      }
    }

    private void ButtonCopyUserName_Click(object sender, EventArgs e)
    {
      textBoxTargetName.Text = textBoxSourceName.Text;
    }

    private void ButtonCopyDatabaseName_Click(object sender, EventArgs e)
    {
      textBoxDatabaseNameTarget.Text = textBoxDatabaseNameSource.Text;
    }
  }
}
