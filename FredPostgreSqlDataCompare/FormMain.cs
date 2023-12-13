using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
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

          string encryptionKeyFinal = encryptionKey[Helper.SecondElement];

          var encryptionSalt = Helper.ReadFile(SourceSaltFilename);
          if (!encryptionSalt[Helper.FirstElement].StartsWith(Helper.OK))
          {
            MessageBox.Show("There was an error while trying to read the encryption vector", "Error while reading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          string encryptionSaltFinal = encryptionSalt[Helper.SecondElement];

          ReadAndDecode(SourceValue1Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxSourceServer);
          ReadAndDecode(SourceValue2Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxSourcePort);
          ReadAndDecode(SourceValue3Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxSourceName);
          ReadAndDecode(SourceValue4Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxSourcePassword);
          ReadAndDecode(SourceValue5Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxDatabaseNameSource);
        }
      }

      // target parameters
      if (checkBoxSourceRememberCredentials.Checked)
      {
        if (AllFilesExist(false))
        {
          var encryptionKey = Helper.ReadFile(TargetKeyFilename);
          if (!encryptionKey[Helper.FirstElement].StartsWith(Helper.OK))
          {
            MessageBox.Show("There was an error while trying to read the encryption key", "Error while reading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          string encryptionKeyFinal = encryptionKey[Helper.SecondElement];

          var encryptionSalt = Helper.ReadFile(TargetSaltFilename);
          if (!encryptionSalt[Helper.FirstElement].StartsWith(Helper.OK))
          {
            MessageBox.Show("There was an error while trying to read the encryption vector", "Error while reading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          string encryptionSaltFinal = encryptionSalt[Helper.SecondElement];

          ReadAndDecode(TargetValue1Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxTargetServer);
          ReadAndDecode(TargetValue2Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxTargetPort);
          ReadAndDecode(TargetValue3Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxTargetName);
          ReadAndDecode(TargetValue4Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxTargetPassword);
          ReadAndDecode(TargetValue5Filename, encryptionKeyFinal, encryptionSaltFinal, textBoxDatabaseNameTarget);
        }
      }
    }

    private void ReadAndDecode(string sourceFilename, string encryptionKey, string encryptionSalt, TextBox textBox)
    {
      var values = Helper.ReadFile(sourceFilename);
      if (!values[Helper.FirstElement].StartsWith(Helper.OK))
      {
        MessageBox.Show("There was an error while trying to read the values file", "Error while reading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      string valuesFinal = values[Helper.SecondElement];
      var plainText = Helper.DecodeWithAES(valuesFinal, encryptionKey, encryptionSalt);
      textBox.Text = plainText;
    }

    private void SaveAuthentificationParameters()
    {
      // source parameters
      if (checkBoxSourceRememberCredentials.Checked)
      {
        if (!string.IsNullOrEmpty(textBoxSourceName.Text) && !string.IsNullOrEmpty(textBoxSourcePassword.Text) && !string.IsNullOrEmpty(textBoxSourcePort.Text) && !string.IsNullOrEmpty(textBoxSourceServer.Text))
        {
          //if (File.Exists(SourceKeyFilename) && File.Exists(SourceSaltFilename))
          //{
          //  // if files already exist then we read the keys already generated

          //}
          //else
          //{
          // create a key file
          var encryptionKey = Helper.GenerateRandomcharacters(32);
          var vector = Helper.GenerateRandomcharacters(16);
          var result = Helper.WriteToFile(encryptionKey, SourceKeyFilename);

          var errorMessage = $"Error while trying to write a file on the disk, the error is: {result[Helper.SecondElement]}";
          if (result[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          result = Helper.WriteToFile(vector, SourceSaltFilename);
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
          var sourceServerNameEncrypted = Helper.EncryptWithAES(sourceServerName, encryptionKey, vector);
          var sourcePortNumberEncrypted = Helper.EncryptWithAES(sourcePortNumber, encryptionKey, vector);
          var sourceUserNameEncrypted = Helper.EncryptWithAES(sourceUserName, encryptionKey, vector);
          var sourcePasswordEncrypted = Helper.EncryptWithAES(sourceUserPassword, encryptionKey, vector);
          var sourceDatabaseNameEncrypted = Helper.EncryptWithAES(sourceDatabaseName, encryptionKey, vector);

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

      if (checkBoxTargetRememberCredentials.Checked)
      {
        if (!string.IsNullOrEmpty(textBoxTargetName.Text) && !string.IsNullOrEmpty(textBoxTargetPassword.Text) && !string.IsNullOrEmpty(textBoxTargetPort.Text) && !string.IsNullOrEmpty(textBoxTargetServer.Text))
        {
          //if (File.Exists(TargetKeyFilename) && File.Exists(TargetSaltFilename))
          //{
          //  // if files already exist then we read the keys already generated

          //}
          //else
          //{
          // create a key file
          var encryptionKey = Helper.GenerateRandomcharacters(32);
          var vector = Helper.GenerateRandomcharacters(16);
          var result = Helper.WriteToFile(encryptionKey, TargetKeyFilename);

          var errorMessage = $"Error while trying to write a file on the disk, the error is: {result[Helper.SecondElement]}";
          if (result[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          result = Helper.WriteToFile(vector, TargetSaltFilename);
          if (result[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          var targetServerName = textBoxTargetServer.Text;
          var targetPortNumber = textBoxTargetPort.Text;
          var targetUserName = textBoxTargetName.Text;
          var targetUserPassword = textBoxTargetPassword.Text;
          var targetDatabaseName = textBoxDatabaseNameTarget.Text;
          // encryption
          var targetServerNameEncrypted = Helper.EncryptWithAES(targetServerName, encryptionKey, vector);
          var targetPortNumberEncrypted = Helper.EncryptWithAES(targetPortNumber, encryptionKey, vector);
          var targetUserNameEncrypted = Helper.EncryptWithAES(targetUserName, encryptionKey, vector);
          var targetPasswordEncrypted = Helper.EncryptWithAES(targetUserPassword, encryptionKey, vector);
          var targetDatabaseNameEncrypted = Helper.EncryptWithAES(targetDatabaseName, encryptionKey, vector);

          var resultWritingToFile = Helper.WriteToFile(targetServerNameEncrypted, TargetValue1Filename);
          if (resultWritingToFile[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          resultWritingToFile = Helper.WriteToFile(targetPortNumberEncrypted, TargetValue2Filename);
          if (resultWritingToFile[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          resultWritingToFile = Helper.WriteToFile(targetUserNameEncrypted, TargetValue3Filename);
          if (resultWritingToFile[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          resultWritingToFile = Helper.WriteToFile(targetPasswordEncrypted, TargetValue4Filename);
          if (resultWritingToFile[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          resultWritingToFile = Helper.WriteToFile(targetDatabaseNameEncrypted, TargetValue5Filename);
          if (resultWritingToFile[Helper.FirstElement] == "ko")
          {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
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
      if (sourceAuthenticationIsOk || targetAuthenticationIsOk)
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
      };

      string sqlQuery = ConnectionSqlServer.GetAllDatabaseNamesRequest();
      if (!sourceAuthenticationIsOk)
      {
        MessageBox.Show("You have to verify the connection to the database first");
        return;
      }

      List<string> listOfDatabaseName = DALHelper.ExecuteSqlQueryToListOfStrings(dbConnexion.ToString(), sqlQuery);

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

    private void ButtonTargetRefresh_Click(object sender, EventArgs e)
    {
      if (targetAuthenticationIsOk)
      {
        var sqlRequest = ConnectionSqlServer.GetAllDatabaseNamesRequest();

      }
    }
  }
}
