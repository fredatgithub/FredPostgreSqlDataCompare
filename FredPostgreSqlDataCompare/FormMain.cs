using FredPostgreSqlDataCompare.DAL;
using FredPostgreSqlDataCompare.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Tools;

namespace FredPostgreSqlDataCompare
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private bool authenticationIsOk = false;

    private void FormMain_Load(object sender, EventArgs e)
    {
      LoadComboboxes();
      GetWindowValue();
      DisplayTitle();
      DisableNotImplementedMenuItems();
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
      comboBoxServerSource.Items.Clear();
      comboBoxServerSource.Items.Add($"{Dns.GetHostName()}");
      comboBoxServerSource.Items.Add("localhost");
      comboBoxServerTarget.Items.Clear();
      comboBoxServerTarget.Items.Add($"{Dns.GetHostName()}");
      comboBoxServerTarget.Items.Add("localhost");

      comboBoxSourceSchema.Items.Clear();
      comboBoxSourceSchema.Items.Add("public");

      comboBoxTargetSchema.Items.Clear();
      comboBoxTargetSchema.Items.Add("public");

      comboBoxSourceSchema.SelectedIndex = Settings.Default.ComboBoxSourceAuthenticationIndex;
      comboBoxTargetSchema.SelectedIndex = Settings.Default.ComboBoxTargetAuthenticationIndex;
      checkBoxSourceRememberCredentials.Checked = Settings.Default.CheckBoxSourceRememberCredentials;
      checkBoxTargetRememberCredentials.Checked = Settings.Default.CheckBoxTargetRememberCredentials;
      textBoxTargetName.Text = Settings.Default.textBoxTargetName;
      textBoxSourceName.Text = Settings.Default.textBoxSourceName;
      if (Settings.Default.comboBoxServerSourceIndex > comboBoxServerSource.Items.Count - 1)
      {
        comboBoxServerSource.SelectedIndex = -1;
      }
      else
      {
        comboBoxServerSource.SelectedIndex = Settings.Default.comboBoxServerSourceIndex;
      }

      if (Settings.Default.comboBoxServerSourceIndex > comboBoxServerSource.Items.Count - 1)
      {
        comboBoxServerTarget.SelectedIndex = -1;
      }
      else
      {
        comboBoxServerTarget.SelectedIndex = Settings.Default.comboBoxServerTargetIndex;
      }

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
      Settings.Default.comboBoxServerSourceIndex = comboBoxServerSource.SelectedIndex;
      Settings.Default.comboBoxServerTargetIndex = comboBoxServerTarget.SelectedIndex;
      var listOfServers = string.Empty;
      foreach (var item in comboBoxServerSource.Items)
      {
        listOfServers += item.ToString();
      }
      
      Settings.Default.comboBoxServerSourceItems = listOfServers;
      listOfServers = string.Empty;
      foreach (var item in comboBoxServerTarget.Items)
      {
        listOfServers += item.ToString();
      }

      Settings.Default.comboBoxServerTargetItems = listOfServers;
      Settings.Default.Save();
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
      //comboBoxServerSource.SelectedIndex = Settings.Default.comboBoxServerSourceIndex;
      //comboBoxServerTarget.SelectedIndex = Settings.Default.comboBoxServerTargetIndex;
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
      comboBoxServerTarget.SelectedIndex = comboBoxServerSource.SelectedIndex;
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
        ServerName = comboBoxServerSource.SelectedItem.ToString(),
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

      // comboBoxServerSource
      if (comboBoxServerSource.SelectedIndex != -1)
      {
        Settings.Default.comboBoxServerSourceIndex = comboBoxServerSource.SelectedIndex;
      }

      // comboBoxTargetSource
      if (comboBoxServerTarget.SelectedIndex != -1)
      {
        Settings.Default.comboBoxServerTargetIndex = comboBoxServerTarget.SelectedIndex;
      }

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
      if (comboBoxServerSource.SelectedIndex == -1)
      {
        MessageBox.Show("You have to choose a source server", "No server selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (string.IsNullOrEmpty(textBoxSourcePort.Text))
      {
        MessageBox.Show("You have to choose a source port number", "No port number", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (string.IsNullOrEmpty(textBoxSourceName.Text))
      {
        MessageBox.Show("You have to choose a source username", "No username", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (string.IsNullOrEmpty(textBoxSourcePassword.Text))
      {
        MessageBox.Show("You have to choose a source password", "No password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }
      
      if (string.IsNullOrEmpty(textBoxDatabaseNameSource.Text))
      {
        MessageBox.Show("You have to choose a database to conenct to", "No database", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      DatabaseAuthentication dbConnexion = new DatabaseAuthentication
      {
        UserName = textBoxSourceName.Text,
        UserPassword = textBoxSourcePassword.Text,
        ServerName = comboBoxServerSource.Text, //.SelectedItem.ToString(),
        Port = int.Parse(textBoxSourcePort.Text),
        DatabaseName = textBoxDatabaseNameSource.Text
      };

      string sqlQuery = ConnectionSqlServer.TestRequest();
      if (DALHelper.TestConnection(dbConnexion.ToString()))
      {
        MessageBox.Show("Connection OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show($"Cannot connect to the database: {dbConnexion.DatabaseName} on the server: {dbConnexion.ServerName}", "Connection KO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void ButtonTestconnectionTarget_Click(object sender, EventArgs e)
    {
      if (comboBoxServerTarget.SelectedIndex == -1)
      {
        MessageBox.Show("You have to choose a target server", "No server selected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (string.IsNullOrEmpty(textBoxTargetPort.Text))
      {
        MessageBox.Show("You have to choose a target port number", "No port number", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (string.IsNullOrEmpty(textBoxTargetName.Text))
      {
        MessageBox.Show("You have to choose a target username", "No username", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      if (string.IsNullOrEmpty(textBoxTargetPassword.Text))
      {
        MessageBox.Show("You have to choose a source password", "No password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }

      DatabaseAuthentication dbConnexion = new DatabaseAuthentication
      {
        UserName = textBoxTargetName.Text,
        UserPassword = textBoxTargetPassword.Text,
        ServerName = comboBoxServerTarget.SelectedItem.ToString(),
        Port = int.Parse(textBoxTargetPort.Text),
        DatabaseName = "postgres"
      };

      string sqlQuery = ConnectionSqlServer.TestRequest();
      if (DALHelper.TestConnection(dbConnexion.ToString()))
      {
        MessageBox.Show("Connection OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show($"Cannot connect to the database: {dbConnexion.DatabaseName} on the server: {dbConnexion.ServerName}", "Connection KO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBoxApplication aboutBox1 = new AboutBoxApplication();
      aboutBox1.ShowDialog();
    }

    private void ComboBoxServerSource_KeyUp(object sender, KeyEventArgs e)
    {
      //if Enter (return) key is pressed
      if (e.KeyCode == Keys.Enter)
      {
        //don't add text if it's empty
        if (comboBoxServerSource.Text != "")
        {
          for (int i = 0; i < comboBoxServerSource.Items.Count; i++)
          {
            //exit event if text already exists
            if (comboBoxServerSource.Text == comboBoxServerSource.Items[i].ToString())
            {
              return;
            }
          }
          
          comboBoxServerSource.Items.Add(comboBoxServerSource.Text);
        }
      }
    }
  }
}
