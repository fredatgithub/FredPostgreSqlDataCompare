using FredPostgreSqlDataCompare.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
      textBoxTargetName.Text = Settings.Default.TextBoxTargetPort;
      Settings.Default.Save();
    }

    private string DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      return string.Format("-V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void ButtonCopyServerName_Click(object sender, EventArgs e)
    {
      comboBoxServerTarget.SelectedIndex = comboBoxServerSource.SelectedIndex;
    }
  }
}
