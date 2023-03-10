namespace FredPostgreSqlDataCompare
{
  partial class FormMain
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enregistrersousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.imprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aperçuavantimpressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rétablirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.couperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.collerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.sélectionnertoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.personnaliserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sommaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rechercherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.àproposdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControlMain = new System.Windows.Forms.TabControl();
      this.tabPageDataSources = new System.Windows.Forms.TabPage();
      this.textBoxTargetPort = new System.Windows.Forms.TextBox();
      this.textBoxSourcePort = new System.Windows.Forms.TextBox();
      this.labelTargetPort = new System.Windows.Forms.Label();
      this.labelSourcePort = new System.Windows.Forms.Label();
      this.buttonCopyServerName = new System.Windows.Forms.Button();
      this.buttonCopyPassword = new System.Windows.Forms.Button();
      this.buttonCompareCompareNow = new System.Windows.Forms.Button();
      this.buttonCompareToLeftArrow = new System.Windows.Forms.Button();
      this.buttonCompareToRightAndLeftArrow = new System.Windows.Forms.Button();
      this.buttonCompareToRightArrow = new System.Windows.Forms.Button();
      this.buttonCompareSaveAs = new System.Windows.Forms.Button();
      this.buttonCompareSave = new System.Windows.Forms.Button();
      this.buttonTargetCreate = new System.Windows.Forms.Button();
      this.buttonTargetRefresh = new System.Windows.Forms.Button();
      this.labelTargetDatabase = new System.Windows.Forms.Label();
      this.comboBoxTargetDatabase = new System.Windows.Forms.ComboBox();
      this.checkBoxTargetRememberCredentials = new System.Windows.Forms.CheckBox();
      this.textBoxTargetPassword = new System.Windows.Forms.TextBox();
      this.textBoxTargetName = new System.Windows.Forms.TextBox();
      this.labelTargetPassword = new System.Windows.Forms.Label();
      this.labelTargetUserName = new System.Windows.Forms.Label();
      this.comboBoxTargetSchema = new System.Windows.Forms.ComboBox();
      this.labelTargetSchema = new System.Windows.Forms.Label();
      this.labelTargetServer = new System.Windows.Forms.Label();
      this.comboBoxServerTarget = new System.Windows.Forms.ComboBox();
      this.labelTargetOperation = new System.Windows.Forms.Label();
      this.buttonSourceCreate = new System.Windows.Forms.Button();
      this.buttonSourceRefresh = new System.Windows.Forms.Button();
      this.labelSourceDatabase = new System.Windows.Forms.Label();
      this.comboBoxSourceDatabase = new System.Windows.Forms.ComboBox();
      this.checkBoxSourceRememberCredentials = new System.Windows.Forms.CheckBox();
      this.textBoxSourcePassword = new System.Windows.Forms.TextBox();
      this.textBoxSourceName = new System.Windows.Forms.TextBox();
      this.labelSourcePassword = new System.Windows.Forms.Label();
      this.labelSourceUserName = new System.Windows.Forms.Label();
      this.comboBoxSourceSchema = new System.Windows.Forms.ComboBox();
      this.labelSourceSchema = new System.Windows.Forms.Label();
      this.labelSourceServer = new System.Windows.Forms.Label();
      this.comboBoxServerSource = new System.Windows.Forms.ComboBox();
      this.labelSourceOperation = new System.Windows.Forms.Label();
      this.tabPageTables = new System.Windows.Forms.TabPage();
      this.menuStrip1.SuspendLayout();
      this.tabControlMain.SuspendLayout();
      this.tabPageDataSources.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.aideToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(973, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fichierToolStripMenuItem
      // 
      this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.toolStripSeparator,
            this.enregistrerToolStripMenuItem,
            this.enregistrersousToolStripMenuItem,
            this.toolStripSeparator1,
            this.imprimerToolStripMenuItem,
            this.aperçuavantimpressionToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
      this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
      this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.fichierToolStripMenuItem.Text = "&Fichier";
      // 
      // nouveauToolStripMenuItem
      // 
      this.nouveauToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nouveauToolStripMenuItem.Image")));
      this.nouveauToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
      this.nouveauToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.nouveauToolStripMenuItem.Text = "&Nouveau";
      // 
      // ouvrirToolStripMenuItem
      // 
      this.ouvrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripMenuItem.Image")));
      this.ouvrirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
      this.ouvrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.ouvrirToolStripMenuItem.Text = "&Ouvrir";
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(202, 6);
      // 
      // enregistrerToolStripMenuItem
      // 
      this.enregistrerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enregistrerToolStripMenuItem.Image")));
      this.enregistrerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
      this.enregistrerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.enregistrerToolStripMenuItem.Text = "&Enregistrer";
      // 
      // enregistrersousToolStripMenuItem
      // 
      this.enregistrersousToolStripMenuItem.Name = "enregistrersousToolStripMenuItem";
      this.enregistrersousToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.enregistrersousToolStripMenuItem.Text = "Enregistrer &sous";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
      // 
      // imprimerToolStripMenuItem
      // 
      this.imprimerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimerToolStripMenuItem.Image")));
      this.imprimerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
      this.imprimerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.imprimerToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.imprimerToolStripMenuItem.Text = "&Imprimer";
      // 
      // aperçuavantimpressionToolStripMenuItem
      // 
      this.aperçuavantimpressionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aperçuavantimpressionToolStripMenuItem.Image")));
      this.aperçuavantimpressionToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.aperçuavantimpressionToolStripMenuItem.Name = "aperçuavantimpressionToolStripMenuItem";
      this.aperçuavantimpressionToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.aperçuavantimpressionToolStripMenuItem.Text = "Aperçu a&vant impression";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
      // 
      // quitterToolStripMenuItem
      // 
      this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
      this.quitterToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.quitterToolStripMenuItem.Text = "&Quitter";
      this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
      // 
      // editionToolStripMenuItem
      // 
      this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annulerToolStripMenuItem,
            this.rétablirToolStripMenuItem,
            this.toolStripSeparator3,
            this.couperToolStripMenuItem,
            this.copierToolStripMenuItem,
            this.collerToolStripMenuItem,
            this.toolStripSeparator4,
            this.sélectionnertoutToolStripMenuItem});
      this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
      this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
      this.editionToolStripMenuItem.Text = "&Edition";
      // 
      // annulerToolStripMenuItem
      // 
      this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
      this.annulerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.annulerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.annulerToolStripMenuItem.Text = "&Annuler";
      // 
      // rétablirToolStripMenuItem
      // 
      this.rétablirToolStripMenuItem.Name = "rétablirToolStripMenuItem";
      this.rétablirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.rétablirToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.rétablirToolStripMenuItem.Text = "&Rétablir";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
      // 
      // couperToolStripMenuItem
      // 
      this.couperToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("couperToolStripMenuItem.Image")));
      this.couperToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.couperToolStripMenuItem.Name = "couperToolStripMenuItem";
      this.couperToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.couperToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.couperToolStripMenuItem.Text = "&Couper";
      // 
      // copierToolStripMenuItem
      // 
      this.copierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copierToolStripMenuItem.Image")));
      this.copierToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copierToolStripMenuItem.Name = "copierToolStripMenuItem";
      this.copierToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copierToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.copierToolStripMenuItem.Text = "Co&pier";
      // 
      // collerToolStripMenuItem
      // 
      this.collerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("collerToolStripMenuItem.Image")));
      this.collerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.collerToolStripMenuItem.Name = "collerToolStripMenuItem";
      this.collerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.collerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.collerToolStripMenuItem.Text = "Co&ller";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
      // 
      // sélectionnertoutToolStripMenuItem
      // 
      this.sélectionnertoutToolStripMenuItem.Name = "sélectionnertoutToolStripMenuItem";
      this.sélectionnertoutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.sélectionnertoutToolStripMenuItem.Text = "Sélectio&nner tout";
      // 
      // outilsToolStripMenuItem
      // 
      this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personnaliserToolStripMenuItem,
            this.optionsToolStripMenuItem});
      this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
      this.outilsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.outilsToolStripMenuItem.Text = "&Outils";
      // 
      // personnaliserToolStripMenuItem
      // 
      this.personnaliserToolStripMenuItem.Name = "personnaliserToolStripMenuItem";
      this.personnaliserToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.personnaliserToolStripMenuItem.Text = "&Personnaliser";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // aideToolStripMenuItem
      // 
      this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sommaireToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.rechercherToolStripMenuItem,
            this.toolStripSeparator5,
            this.àproposdeToolStripMenuItem});
      this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
      this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
      this.aideToolStripMenuItem.Text = "&Aide";
      // 
      // sommaireToolStripMenuItem
      // 
      this.sommaireToolStripMenuItem.Name = "sommaireToolStripMenuItem";
      this.sommaireToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.sommaireToolStripMenuItem.Text = "&Sommaire";
      // 
      // indexToolStripMenuItem
      // 
      this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
      this.indexToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.indexToolStripMenuItem.Text = "&Index";
      // 
      // rechercherToolStripMenuItem
      // 
      this.rechercherToolStripMenuItem.Name = "rechercherToolStripMenuItem";
      this.rechercherToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.rechercherToolStripMenuItem.Text = "&Rechercher";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(144, 6);
      // 
      // àproposdeToolStripMenuItem
      // 
      this.àproposdeToolStripMenuItem.Name = "àproposdeToolStripMenuItem";
      this.àproposdeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.àproposdeToolStripMenuItem.Text = "À &propos de...";
      // 
      // tabControlMain
      // 
      this.tabControlMain.Controls.Add(this.tabPageDataSources);
      this.tabControlMain.Controls.Add(this.tabPageTables);
      this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlMain.Location = new System.Drawing.Point(0, 24);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new System.Drawing.Size(973, 675);
      this.tabControlMain.TabIndex = 1;
      // 
      // tabPageDataSources
      // 
      this.tabPageDataSources.Controls.Add(this.textBoxTargetPort);
      this.tabPageDataSources.Controls.Add(this.textBoxSourcePort);
      this.tabPageDataSources.Controls.Add(this.labelTargetPort);
      this.tabPageDataSources.Controls.Add(this.labelSourcePort);
      this.tabPageDataSources.Controls.Add(this.buttonCopyServerName);
      this.tabPageDataSources.Controls.Add(this.buttonCopyPassword);
      this.tabPageDataSources.Controls.Add(this.buttonCompareCompareNow);
      this.tabPageDataSources.Controls.Add(this.buttonCompareToLeftArrow);
      this.tabPageDataSources.Controls.Add(this.buttonCompareToRightAndLeftArrow);
      this.tabPageDataSources.Controls.Add(this.buttonCompareToRightArrow);
      this.tabPageDataSources.Controls.Add(this.buttonCompareSaveAs);
      this.tabPageDataSources.Controls.Add(this.buttonCompareSave);
      this.tabPageDataSources.Controls.Add(this.buttonTargetCreate);
      this.tabPageDataSources.Controls.Add(this.buttonTargetRefresh);
      this.tabPageDataSources.Controls.Add(this.labelTargetDatabase);
      this.tabPageDataSources.Controls.Add(this.comboBoxTargetDatabase);
      this.tabPageDataSources.Controls.Add(this.checkBoxTargetRememberCredentials);
      this.tabPageDataSources.Controls.Add(this.textBoxTargetPassword);
      this.tabPageDataSources.Controls.Add(this.textBoxTargetName);
      this.tabPageDataSources.Controls.Add(this.labelTargetPassword);
      this.tabPageDataSources.Controls.Add(this.labelTargetUserName);
      this.tabPageDataSources.Controls.Add(this.comboBoxTargetSchema);
      this.tabPageDataSources.Controls.Add(this.labelTargetSchema);
      this.tabPageDataSources.Controls.Add(this.labelTargetServer);
      this.tabPageDataSources.Controls.Add(this.comboBoxServerTarget);
      this.tabPageDataSources.Controls.Add(this.labelTargetOperation);
      this.tabPageDataSources.Controls.Add(this.buttonSourceCreate);
      this.tabPageDataSources.Controls.Add(this.buttonSourceRefresh);
      this.tabPageDataSources.Controls.Add(this.labelSourceDatabase);
      this.tabPageDataSources.Controls.Add(this.comboBoxSourceDatabase);
      this.tabPageDataSources.Controls.Add(this.checkBoxSourceRememberCredentials);
      this.tabPageDataSources.Controls.Add(this.textBoxSourcePassword);
      this.tabPageDataSources.Controls.Add(this.textBoxSourceName);
      this.tabPageDataSources.Controls.Add(this.labelSourcePassword);
      this.tabPageDataSources.Controls.Add(this.labelSourceUserName);
      this.tabPageDataSources.Controls.Add(this.comboBoxSourceSchema);
      this.tabPageDataSources.Controls.Add(this.labelSourceSchema);
      this.tabPageDataSources.Controls.Add(this.labelSourceServer);
      this.tabPageDataSources.Controls.Add(this.comboBoxServerSource);
      this.tabPageDataSources.Controls.Add(this.labelSourceOperation);
      this.tabPageDataSources.Location = new System.Drawing.Point(4, 22);
      this.tabPageDataSources.Name = "tabPageDataSources";
      this.tabPageDataSources.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageDataSources.Size = new System.Drawing.Size(965, 649);
      this.tabPageDataSources.TabIndex = 0;
      this.tabPageDataSources.Text = "Data Sources";
      this.tabPageDataSources.UseVisualStyleBackColor = true;
      // 
      // textBoxTargetPort
      // 
      this.textBoxTargetPort.Location = new System.Drawing.Point(488, 152);
      this.textBoxTargetPort.Name = "textBoxTargetPort";
      this.textBoxTargetPort.Size = new System.Drawing.Size(100, 20);
      this.textBoxTargetPort.TabIndex = 81;
      this.textBoxTargetPort.Text = "5432";
      // 
      // textBoxSourcePort
      // 
      this.textBoxSourcePort.Location = new System.Drawing.Point(121, 153);
      this.textBoxSourcePort.Name = "textBoxSourcePort";
      this.textBoxSourcePort.Size = new System.Drawing.Size(100, 20);
      this.textBoxSourcePort.TabIndex = 80;
      this.textBoxSourcePort.Text = "5432";
      // 
      // labelTargetPort
      // 
      this.labelTargetPort.AutoSize = true;
      this.labelTargetPort.Location = new System.Drawing.Point(410, 155);
      this.labelTargetPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetPort.Name = "labelTargetPort";
      this.labelTargetPort.Size = new System.Drawing.Size(29, 13);
      this.labelTargetPort.TabIndex = 79;
      this.labelTargetPort.Text = "Port:";
      // 
      // labelSourcePort
      // 
      this.labelSourcePort.AutoSize = true;
      this.labelSourcePort.Location = new System.Drawing.Point(43, 155);
      this.labelSourcePort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourcePort.Name = "labelSourcePort";
      this.labelSourcePort.Size = new System.Drawing.Size(29, 13);
      this.labelSourcePort.TabIndex = 78;
      this.labelSourcePort.Text = "Port:";
      // 
      // buttonCopyServerName
      // 
      this.buttonCopyServerName.Location = new System.Drawing.Point(359, 112);
      this.buttonCopyServerName.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCopyServerName.Name = "buttonCopyServerName";
      this.buttonCopyServerName.Size = new System.Drawing.Size(34, 22);
      this.buttonCopyServerName.TabIndex = 77;
      this.buttonCopyServerName.Text = "-->";
      this.buttonCopyServerName.UseVisualStyleBackColor = true;
      this.buttonCopyServerName.Click += new System.EventHandler(this.ButtonCopyServerName_Click);
      // 
      // buttonCopyPassword
      // 
      this.buttonCopyPassword.Location = new System.Drawing.Point(359, 204);
      this.buttonCopyPassword.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCopyPassword.Name = "buttonCopyPassword";
      this.buttonCopyPassword.Size = new System.Drawing.Size(34, 22);
      this.buttonCopyPassword.TabIndex = 76;
      this.buttonCopyPassword.Text = "-->";
      this.buttonCopyPassword.UseVisualStyleBackColor = true;
      // 
      // buttonCompareCompareNow
      // 
      this.buttonCompareCompareNow.BackColor = System.Drawing.Color.RoyalBlue;
      this.buttonCompareCompareNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCompareCompareNow.ForeColor = System.Drawing.Color.White;
      this.buttonCompareCompareNow.Location = new System.Drawing.Point(519, 451);
      this.buttonCompareCompareNow.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCompareCompareNow.Name = "buttonCompareCompareNow";
      this.buttonCompareCompareNow.Size = new System.Drawing.Size(110, 30);
      this.buttonCompareCompareNow.TabIndex = 74;
      this.buttonCompareCompareNow.Text = "Compare now";
      this.buttonCompareCompareNow.UseVisualStyleBackColor = false;
      // 
      // buttonCompareToLeftArrow
      // 
      this.buttonCompareToLeftArrow.Location = new System.Drawing.Point(422, 451);
      this.buttonCompareToLeftArrow.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCompareToLeftArrow.Name = "buttonCompareToLeftArrow";
      this.buttonCompareToLeftArrow.Size = new System.Drawing.Size(40, 30);
      this.buttonCompareToLeftArrow.TabIndex = 73;
      this.buttonCompareToLeftArrow.Text = "<--";
      this.buttonCompareToLeftArrow.UseVisualStyleBackColor = true;
      // 
      // buttonCompareToRightAndLeftArrow
      // 
      this.buttonCompareToRightAndLeftArrow.Location = new System.Drawing.Point(377, 451);
      this.buttonCompareToRightAndLeftArrow.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCompareToRightAndLeftArrow.Name = "buttonCompareToRightAndLeftArrow";
      this.buttonCompareToRightAndLeftArrow.Size = new System.Drawing.Size(34, 30);
      this.buttonCompareToRightAndLeftArrow.TabIndex = 72;
      this.buttonCompareToRightAndLeftArrow.Text = "<-->";
      this.buttonCompareToRightAndLeftArrow.UseVisualStyleBackColor = true;
      // 
      // buttonCompareToRightArrow
      // 
      this.buttonCompareToRightArrow.Location = new System.Drawing.Point(325, 451);
      this.buttonCompareToRightArrow.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCompareToRightArrow.Name = "buttonCompareToRightArrow";
      this.buttonCompareToRightArrow.Size = new System.Drawing.Size(44, 30);
      this.buttonCompareToRightArrow.TabIndex = 71;
      this.buttonCompareToRightArrow.Text = "-->";
      this.buttonCompareToRightArrow.UseVisualStyleBackColor = true;
      // 
      // buttonCompareSaveAs
      // 
      this.buttonCompareSaveAs.Location = new System.Drawing.Point(121, 451);
      this.buttonCompareSaveAs.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCompareSaveAs.Name = "buttonCompareSaveAs";
      this.buttonCompareSaveAs.Size = new System.Drawing.Size(71, 30);
      this.buttonCompareSaveAs.TabIndex = 70;
      this.buttonCompareSaveAs.Text = "Save as ...";
      this.buttonCompareSaveAs.UseVisualStyleBackColor = true;
      // 
      // buttonCompareSave
      // 
      this.buttonCompareSave.Location = new System.Drawing.Point(44, 451);
      this.buttonCompareSave.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCompareSave.Name = "buttonCompareSave";
      this.buttonCompareSave.Size = new System.Drawing.Size(66, 30);
      this.buttonCompareSave.TabIndex = 69;
      this.buttonCompareSave.Text = "Save";
      this.buttonCompareSave.UseVisualStyleBackColor = true;
      // 
      // buttonTargetCreate
      // 
      this.buttonTargetCreate.Location = new System.Drawing.Point(412, 373);
      this.buttonTargetCreate.Margin = new System.Windows.Forms.Padding(2);
      this.buttonTargetCreate.Name = "buttonTargetCreate";
      this.buttonTargetCreate.Size = new System.Drawing.Size(56, 19);
      this.buttonTargetCreate.TabIndex = 68;
      this.buttonTargetCreate.Text = "Create";
      this.buttonTargetCreate.UseVisualStyleBackColor = true;
      // 
      // buttonTargetRefresh
      // 
      this.buttonTargetRefresh.Location = new System.Drawing.Point(695, 342);
      this.buttonTargetRefresh.Margin = new System.Windows.Forms.Padding(2);
      this.buttonTargetRefresh.Name = "buttonTargetRefresh";
      this.buttonTargetRefresh.Size = new System.Drawing.Size(56, 19);
      this.buttonTargetRefresh.TabIndex = 67;
      this.buttonTargetRefresh.Text = "Refresh";
      this.buttonTargetRefresh.UseVisualStyleBackColor = true;
      // 
      // labelTargetDatabase
      // 
      this.labelTargetDatabase.AutoSize = true;
      this.labelTargetDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTargetDatabase.Location = new System.Drawing.Point(410, 314);
      this.labelTargetDatabase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetDatabase.Name = "labelTargetDatabase";
      this.labelTargetDatabase.Size = new System.Drawing.Size(61, 13);
      this.labelTargetDatabase.TabIndex = 66;
      this.labelTargetDatabase.Text = "Database";
      // 
      // comboBoxTargetDatabase
      // 
      this.comboBoxTargetDatabase.FormattingEnabled = true;
      this.comboBoxTargetDatabase.Location = new System.Drawing.Point(412, 341);
      this.comboBoxTargetDatabase.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxTargetDatabase.Name = "comboBoxTargetDatabase";
      this.comboBoxTargetDatabase.Size = new System.Drawing.Size(276, 21);
      this.comboBoxTargetDatabase.TabIndex = 65;
      this.comboBoxTargetDatabase.Text = "Database name";
      // 
      // checkBoxTargetRememberCredentials
      // 
      this.checkBoxTargetRememberCredentials.AutoSize = true;
      this.checkBoxTargetRememberCredentials.Location = new System.Drawing.Point(488, 236);
      this.checkBoxTargetRememberCredentials.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxTargetRememberCredentials.Name = "checkBoxTargetRememberCredentials";
      this.checkBoxTargetRememberCredentials.Size = new System.Drawing.Size(131, 17);
      this.checkBoxTargetRememberCredentials.TabIndex = 64;
      this.checkBoxTargetRememberCredentials.Text = "Remember credentials";
      this.checkBoxTargetRememberCredentials.UseVisualStyleBackColor = true;
      // 
      // textBoxTargetPassword
      // 
      this.textBoxTargetPassword.Location = new System.Drawing.Point(488, 204);
      this.textBoxTargetPassword.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxTargetPassword.Name = "textBoxTargetPassword";
      this.textBoxTargetPassword.PasswordChar = '*';
      this.textBoxTargetPassword.Size = new System.Drawing.Size(221, 20);
      this.textBoxTargetPassword.TabIndex = 63;
      // 
      // textBoxTargetName
      // 
      this.textBoxTargetName.Location = new System.Drawing.Point(488, 179);
      this.textBoxTargetName.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxTargetName.Name = "textBoxTargetName";
      this.textBoxTargetName.Size = new System.Drawing.Size(221, 20);
      this.textBoxTargetName.TabIndex = 62;
      // 
      // labelTargetPassword
      // 
      this.labelTargetPassword.AutoSize = true;
      this.labelTargetPassword.Location = new System.Drawing.Point(410, 204);
      this.labelTargetPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetPassword.Name = "labelTargetPassword";
      this.labelTargetPassword.Size = new System.Drawing.Size(53, 13);
      this.labelTargetPassword.TabIndex = 61;
      this.labelTargetPassword.Text = "Password";
      // 
      // labelTargetUserName
      // 
      this.labelTargetUserName.AutoSize = true;
      this.labelTargetUserName.Location = new System.Drawing.Point(410, 179);
      this.labelTargetUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetUserName.Name = "labelTargetUserName";
      this.labelTargetUserName.Size = new System.Drawing.Size(60, 13);
      this.labelTargetUserName.TabIndex = 60;
      this.labelTargetUserName.Text = "User Name";
      // 
      // comboBoxTargetSchema
      // 
      this.comboBoxTargetSchema.FormattingEnabled = true;
      this.comboBoxTargetSchema.Location = new System.Drawing.Point(488, 273);
      this.comboBoxTargetSchema.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxTargetSchema.Name = "comboBoxTargetSchema";
      this.comboBoxTargetSchema.Size = new System.Drawing.Size(221, 21);
      this.comboBoxTargetSchema.TabIndex = 59;
      this.comboBoxTargetSchema.Text = "Public";
      // 
      // labelTargetSchema
      // 
      this.labelTargetSchema.AutoSize = true;
      this.labelTargetSchema.Location = new System.Drawing.Point(410, 273);
      this.labelTargetSchema.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetSchema.Name = "labelTargetSchema";
      this.labelTargetSchema.Size = new System.Drawing.Size(46, 13);
      this.labelTargetSchema.TabIndex = 58;
      this.labelTargetSchema.Text = "Schema";
      // 
      // labelTargetServer
      // 
      this.labelTargetServer.AutoSize = true;
      this.labelTargetServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTargetServer.Location = new System.Drawing.Point(408, 86);
      this.labelTargetServer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetServer.Name = "labelTargetServer";
      this.labelTargetServer.Size = new System.Drawing.Size(115, 13);
      this.labelTargetServer.TabIndex = 57;
      this.labelTargetServer.Text = "PostgreSQL Server";
      // 
      // comboBoxServerTarget
      // 
      this.comboBoxServerTarget.FormattingEnabled = true;
      this.comboBoxServerTarget.Location = new System.Drawing.Point(410, 113);
      this.comboBoxServerTarget.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxServerTarget.Name = "comboBoxServerTarget";
      this.comboBoxServerTarget.Size = new System.Drawing.Size(276, 21);
      this.comboBoxServerTarget.TabIndex = 56;
      this.comboBoxServerTarget.Text = "Server";
      // 
      // labelTargetOperation
      // 
      this.labelTargetOperation.AutoSize = true;
      this.labelTargetOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTargetOperation.Location = new System.Drawing.Point(408, 34);
      this.labelTargetOperation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelTargetOperation.Name = "labelTargetOperation";
      this.labelTargetOperation.Size = new System.Drawing.Size(70, 24);
      this.labelTargetOperation.TabIndex = 55;
      this.labelTargetOperation.Text = "Target";
      // 
      // buttonSourceCreate
      // 
      this.buttonSourceCreate.Location = new System.Drawing.Point(45, 373);
      this.buttonSourceCreate.Margin = new System.Windows.Forms.Padding(2);
      this.buttonSourceCreate.Name = "buttonSourceCreate";
      this.buttonSourceCreate.Size = new System.Drawing.Size(56, 19);
      this.buttonSourceCreate.TabIndex = 53;
      this.buttonSourceCreate.Text = "Create";
      this.buttonSourceCreate.UseVisualStyleBackColor = true;
      // 
      // buttonSourceRefresh
      // 
      this.buttonSourceRefresh.Location = new System.Drawing.Point(328, 342);
      this.buttonSourceRefresh.Margin = new System.Windows.Forms.Padding(2);
      this.buttonSourceRefresh.Name = "buttonSourceRefresh";
      this.buttonSourceRefresh.Size = new System.Drawing.Size(56, 19);
      this.buttonSourceRefresh.TabIndex = 52;
      this.buttonSourceRefresh.Text = "Refresh";
      this.buttonSourceRefresh.UseVisualStyleBackColor = true;
      // 
      // labelSourceDatabase
      // 
      this.labelSourceDatabase.AutoSize = true;
      this.labelSourceDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSourceDatabase.Location = new System.Drawing.Point(43, 314);
      this.labelSourceDatabase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourceDatabase.Name = "labelSourceDatabase";
      this.labelSourceDatabase.Size = new System.Drawing.Size(61, 13);
      this.labelSourceDatabase.TabIndex = 51;
      this.labelSourceDatabase.Text = "Database";
      // 
      // comboBoxSourceDatabase
      // 
      this.comboBoxSourceDatabase.FormattingEnabled = true;
      this.comboBoxSourceDatabase.Location = new System.Drawing.Point(45, 341);
      this.comboBoxSourceDatabase.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxSourceDatabase.Name = "comboBoxSourceDatabase";
      this.comboBoxSourceDatabase.Size = new System.Drawing.Size(276, 21);
      this.comboBoxSourceDatabase.TabIndex = 50;
      this.comboBoxSourceDatabase.Text = "Database name";
      // 
      // checkBoxSourceRememberCredentials
      // 
      this.checkBoxSourceRememberCredentials.AutoSize = true;
      this.checkBoxSourceRememberCredentials.Location = new System.Drawing.Point(121, 236);
      this.checkBoxSourceRememberCredentials.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxSourceRememberCredentials.Name = "checkBoxSourceRememberCredentials";
      this.checkBoxSourceRememberCredentials.Size = new System.Drawing.Size(131, 17);
      this.checkBoxSourceRememberCredentials.TabIndex = 49;
      this.checkBoxSourceRememberCredentials.Text = "Remember credentials";
      this.checkBoxSourceRememberCredentials.UseVisualStyleBackColor = true;
      // 
      // textBoxSourcePassword
      // 
      this.textBoxSourcePassword.Location = new System.Drawing.Point(121, 204);
      this.textBoxSourcePassword.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxSourcePassword.Name = "textBoxSourcePassword";
      this.textBoxSourcePassword.PasswordChar = '*';
      this.textBoxSourcePassword.Size = new System.Drawing.Size(221, 20);
      this.textBoxSourcePassword.TabIndex = 48;
      // 
      // textBoxSourceName
      // 
      this.textBoxSourceName.Location = new System.Drawing.Point(121, 179);
      this.textBoxSourceName.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxSourceName.Name = "textBoxSourceName";
      this.textBoxSourceName.Size = new System.Drawing.Size(221, 20);
      this.textBoxSourceName.TabIndex = 47;
      // 
      // labelSourcePassword
      // 
      this.labelSourcePassword.AutoSize = true;
      this.labelSourcePassword.Location = new System.Drawing.Point(43, 204);
      this.labelSourcePassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourcePassword.Name = "labelSourcePassword";
      this.labelSourcePassword.Size = new System.Drawing.Size(53, 13);
      this.labelSourcePassword.TabIndex = 46;
      this.labelSourcePassword.Text = "Password";
      // 
      // labelSourceUserName
      // 
      this.labelSourceUserName.AutoSize = true;
      this.labelSourceUserName.Location = new System.Drawing.Point(43, 179);
      this.labelSourceUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourceUserName.Name = "labelSourceUserName";
      this.labelSourceUserName.Size = new System.Drawing.Size(60, 13);
      this.labelSourceUserName.TabIndex = 45;
      this.labelSourceUserName.Text = "User Name";
      // 
      // comboBoxSourceSchema
      // 
      this.comboBoxSourceSchema.FormattingEnabled = true;
      this.comboBoxSourceSchema.Location = new System.Drawing.Point(121, 273);
      this.comboBoxSourceSchema.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxSourceSchema.Name = "comboBoxSourceSchema";
      this.comboBoxSourceSchema.Size = new System.Drawing.Size(221, 21);
      this.comboBoxSourceSchema.TabIndex = 44;
      this.comboBoxSourceSchema.Text = "Public";
      // 
      // labelSourceSchema
      // 
      this.labelSourceSchema.AutoSize = true;
      this.labelSourceSchema.Location = new System.Drawing.Point(43, 273);
      this.labelSourceSchema.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourceSchema.Name = "labelSourceSchema";
      this.labelSourceSchema.Size = new System.Drawing.Size(46, 13);
      this.labelSourceSchema.TabIndex = 43;
      this.labelSourceSchema.Text = "Schema";
      // 
      // labelSourceServer
      // 
      this.labelSourceServer.AutoSize = true;
      this.labelSourceServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSourceServer.Location = new System.Drawing.Point(41, 86);
      this.labelSourceServer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourceServer.Name = "labelSourceServer";
      this.labelSourceServer.Size = new System.Drawing.Size(115, 13);
      this.labelSourceServer.TabIndex = 42;
      this.labelSourceServer.Text = "PostgreSQL Server";
      // 
      // comboBoxServerSource
      // 
      this.comboBoxServerSource.FormattingEnabled = true;
      this.comboBoxServerSource.Location = new System.Drawing.Point(43, 113);
      this.comboBoxServerSource.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxServerSource.Name = "comboBoxServerSource";
      this.comboBoxServerSource.Size = new System.Drawing.Size(276, 21);
      this.comboBoxServerSource.TabIndex = 41;
      this.comboBoxServerSource.Text = "Server";
      // 
      // labelSourceOperation
      // 
      this.labelSourceOperation.AutoSize = true;
      this.labelSourceOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSourceOperation.Location = new System.Drawing.Point(41, 34);
      this.labelSourceOperation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSourceOperation.Name = "labelSourceOperation";
      this.labelSourceOperation.Size = new System.Drawing.Size(77, 24);
      this.labelSourceOperation.TabIndex = 40;
      this.labelSourceOperation.Text = "Source";
      // 
      // tabPageTables
      // 
      this.tabPageTables.Location = new System.Drawing.Point(4, 22);
      this.tabPageTables.Name = "tabPageTables";
      this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTables.Size = new System.Drawing.Size(965, 649);
      this.tabPageTables.TabIndex = 1;
      this.tabPageTables.Text = "Tables";
      this.tabPageTables.UseVisualStyleBackColor = true;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(973, 699);
      this.Controls.Add(this.tabControlMain);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FormMain";
      this.Text = "Fred PostgreSql Data Compare";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControlMain.ResumeLayout(false);
      this.tabPageDataSources.ResumeLayout(false);
      this.tabPageDataSources.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enregistrersousToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem imprimerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aperçuavantimpressionToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rétablirToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem couperToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copierToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem collerToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem sélectionnertoutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem personnaliserToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sommaireToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rechercherToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem àproposdeToolStripMenuItem;
    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabPageDataSources;
    private System.Windows.Forms.TabPage tabPageTables;
    private System.Windows.Forms.Button buttonCopyPassword;
    private System.Windows.Forms.Button buttonCompareCompareNow;
    private System.Windows.Forms.Button buttonCompareToLeftArrow;
    private System.Windows.Forms.Button buttonCompareToRightAndLeftArrow;
    private System.Windows.Forms.Button buttonCompareToRightArrow;
    private System.Windows.Forms.Button buttonCompareSaveAs;
    private System.Windows.Forms.Button buttonCompareSave;
    private System.Windows.Forms.Button buttonTargetCreate;
    private System.Windows.Forms.Button buttonTargetRefresh;
    private System.Windows.Forms.Label labelTargetDatabase;
    private System.Windows.Forms.ComboBox comboBoxTargetDatabase;
    private System.Windows.Forms.CheckBox checkBoxTargetRememberCredentials;
    private System.Windows.Forms.TextBox textBoxTargetPassword;
    private System.Windows.Forms.TextBox textBoxTargetName;
    private System.Windows.Forms.Label labelTargetPassword;
    private System.Windows.Forms.Label labelTargetUserName;
    private System.Windows.Forms.ComboBox comboBoxTargetSchema;
    private System.Windows.Forms.Label labelTargetSchema;
    private System.Windows.Forms.Label labelTargetServer;
    private System.Windows.Forms.ComboBox comboBoxServerTarget;
    private System.Windows.Forms.Label labelTargetOperation;
    private System.Windows.Forms.Button buttonSourceCreate;
    private System.Windows.Forms.Button buttonSourceRefresh;
    private System.Windows.Forms.Label labelSourceDatabase;
    private System.Windows.Forms.ComboBox comboBoxSourceDatabase;
    private System.Windows.Forms.CheckBox checkBoxSourceRememberCredentials;
    private System.Windows.Forms.TextBox textBoxSourcePassword;
    private System.Windows.Forms.TextBox textBoxSourceName;
    private System.Windows.Forms.Label labelSourcePassword;
    private System.Windows.Forms.Label labelSourceUserName;
    private System.Windows.Forms.ComboBox comboBoxSourceSchema;
    private System.Windows.Forms.Label labelSourceSchema;
    private System.Windows.Forms.Label labelSourceServer;
    private System.Windows.Forms.ComboBox comboBoxServerSource;
    private System.Windows.Forms.Label labelSourceOperation;
    private System.Windows.Forms.Button buttonCopyServerName;
    private System.Windows.Forms.TextBox textBoxTargetPort;
    private System.Windows.Forms.TextBox textBoxSourcePort;
    private System.Windows.Forms.Label labelTargetPort;
    private System.Windows.Forms.Label labelSourcePort;
  }
}

