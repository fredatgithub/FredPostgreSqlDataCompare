using FredPostgreSqlDataCompare.DAL;
using FredPostgreSqlDataCompare.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace FredPostgreSqlDataCompare
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      LoadComboboxes();
      GetWindowValue();
      DisplayTitle();
    }

    private void LoadComboboxes()
    {
      comboBoxServerSource.Items.Clear();
      comboBoxServerSource.Items.Add($"{Dns.GetHostName()}");
      comboBoxServerTarget.Items.Clear();
      comboBoxServerTarget.Items.Add($"{Dns.GetHostName()}");

      comboBoxSourceSchema.Items.Clear();
      comboBoxSourceSchema.Items.Add("Public");

      comboBoxTargetSchema.Items.Clear();
      comboBoxTargetSchema.Items.Add("Public");

      comboBoxSourceSchema.SelectedIndex = Settings.Default.ComboBoxSourceAuthenticationIndex;
      comboBoxTargetSchema.SelectedIndex = Settings.Default.ComboBoxTargetAuthenticationIndex;
      checkBoxSourceRememberCredentials.Checked = Settings.Default.CheckBoxSourceRememberCredentials;
      checkBoxTargetRememberCredentials.Checked = Settings.Default.CheckBoxTargetRememberCredentials;
      textBoxTargetName.Text = Settings.Default.textBoxTargetName;
      textBoxSourceName.Text = Settings.Default.textBoxSourceName;
      comboBoxServerSource.SelectedIndex = Settings.Default.comboBoxServerSource;
      comboBoxServerTarget.SelectedIndex = Settings.Default.comboBoxTargetSource;

      comboBoxSourceDatabase.Items.Clear();
      foreach (string item in Settings.Default.comboBoxSourceDatabase.Split(';'))
      {
        comboBoxSourceDatabase.Items.Add(item);
      }

      comboBoxTargetDatabase.Items.Clear();
      foreach (string item in Settings.Default.comboBoxTargetDatabase.Split(';'))
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
      Settings.Default.comboBoxServerSource = comboBoxServerSource.SelectedIndex;
      Settings.Default.comboBoxTargetSource = comboBoxServerTarget.SelectedIndex;
      Settings.Default.Save();
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
      comboBoxServerSource.SelectedIndex = Settings.Default.comboBoxServerSource;
      comboBoxServerTarget.SelectedIndex = Settings.Default.comboBoxTargetSource;
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
        DatabaseName = "master"
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
        Settings.Default.comboBoxServerSource = comboBoxServerSource.SelectedIndex;
      }

      // comboBoxTargetSource
      if (comboBoxServerTarget.SelectedIndex != -1)
      {
        Settings.Default.comboBoxTargetSource = comboBoxServerTarget.SelectedIndex;
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
  }
}
