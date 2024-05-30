namespace GrayscaleImageConverter
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.statusLabel = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.playdatePalette = new System.Windows.Forms.CheckBox();
			this.patternMappingPanel = new System.Windows.Forms.Panel();
			this.patternMappings = new System.Windows.Forms.Panel();
			this.mappingTypeDropdown = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.patternMapping15 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping14 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping13 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping12 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping11 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping10 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping9 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping8 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping7 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping6 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping5 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping4 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping3 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping2 = new GrayscaleImageConverter.PatternMapping();
			this.patternMapping1 = new GrayscaleImageConverter.PatternMapping();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
			this.patternMappingPanel.SuspendLayout();
			this.patternMappings.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.zoomToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(984, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.exportAsToolStripMenuItem,
            this.exportPNGToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadImageToolStripMenuItem
			// 
			this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
			this.loadImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.loadImageToolStripMenuItem.Text = "Load image...";
			this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
			// 
			// exportAsToolStripMenuItem
			// 
			this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
			this.exportAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.exportAsToolStripMenuItem.Text = "Export GSI...";
			this.exportAsToolStripMenuItem.Click += new System.EventHandler(this.exportAsToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.exportPNGToolStripMenuItem.Text = "Export PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// zoomToolStripMenuItem
			// 
			this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x1ToolStripMenuItem,
            this.x2ToolStripMenuItem,
            this.x3ToolStripMenuItem});
			this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
			this.zoomToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.zoomToolStripMenuItem.Text = "Zoom";
			// 
			// x1ToolStripMenuItem
			// 
			this.x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
			this.x1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
			this.x1ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.x1ToolStripMenuItem.Text = "x1";
			this.x1ToolStripMenuItem.Click += new System.EventHandler(this.x1ToolStripMenuItem_Click);
			// 
			// x2ToolStripMenuItem
			// 
			this.x2ToolStripMenuItem.Name = "x2ToolStripMenuItem";
			this.x2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
			this.x2ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.x2ToolStripMenuItem.Text = "x2";
			this.x2ToolStripMenuItem.Click += new System.EventHandler(this.x2ToolStripMenuItem_Click);
			// 
			// x3ToolStripMenuItem
			// 
			this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
			this.x3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
			this.x3ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.x3ToolStripMenuItem.Text = "x3";
			this.x3ToolStripMenuItem.Click += new System.EventHandler(this.x3ToolStripMenuItem_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(3, 3);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(207, 23);
			this.progressBar1.TabIndex = 1;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(216, 7);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(37, 13);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Status";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(400, 240);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.numericUpDownX);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.numericUpDownY);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.playdatePalette);
			this.panel1.Controls.Add(this.progressBar1);
			this.panel1.Controls.Add(this.statusLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 652);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 29);
			this.panel1.TabIndex = 4;
			// 
			// numericUpDownX
			// 
			this.numericUpDownX.Dock = System.Windows.Forms.DockStyle.Right;
			this.numericUpDownX.Location = new System.Drawing.Point(519, 0);
			this.numericUpDownX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numericUpDownX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.numericUpDownX.Name = "numericUpDownX";
			this.numericUpDownX.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownX.TabIndex = 7;
			this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Location = new System.Drawing.Point(575, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(10, 29);
			this.label3.TabIndex = 8;
			this.label3.Text = ",";
			// 
			// numericUpDownY
			// 
			this.numericUpDownY.Dock = System.Windows.Forms.DockStyle.Right;
			this.numericUpDownY.Location = new System.Drawing.Point(585, 0);
			this.numericUpDownY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numericUpDownY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.numericUpDownY.Name = "numericUpDownY";
			this.numericUpDownY.Size = new System.Drawing.Size(51, 20);
			this.numericUpDownY.TabIndex = 6;
			this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Location = new System.Drawing.Point(636, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 29);
			this.label1.TabIndex = 5;
			this.label1.Text = "Background type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(739, 0);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// playdatePalette
			// 
			this.playdatePalette.AutoSize = true;
			this.playdatePalette.Dock = System.Windows.Forms.DockStyle.Right;
			this.playdatePalette.Location = new System.Drawing.Point(860, 0);
			this.playdatePalette.Name = "playdatePalette";
			this.playdatePalette.Size = new System.Drawing.Size(124, 29);
			this.playdatePalette.TabIndex = 3;
			this.playdatePalette.Text = "Use Playdate palette";
			this.playdatePalette.UseVisualStyleBackColor = true;
			this.playdatePalette.CheckedChanged += new System.EventHandler(this.playdatePalette_CheckedChanged);
			// 
			// patternMappingPanel
			// 
			this.patternMappingPanel.Controls.Add(this.patternMappings);
			this.patternMappingPanel.Controls.Add(this.label2);
			this.patternMappingPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.patternMappingPanel.Location = new System.Drawing.Point(724, 24);
			this.patternMappingPanel.MinimumSize = new System.Drawing.Size(260, 0);
			this.patternMappingPanel.Name = "patternMappingPanel";
			this.patternMappingPanel.Size = new System.Drawing.Size(260, 628);
			this.patternMappingPanel.TabIndex = 5;
			// 
			// patternMappings
			// 
			this.patternMappings.Controls.Add(this.mappingTypeDropdown);
			this.patternMappings.Controls.Add(this.label4);
			this.patternMappings.Controls.Add(this.patternMapping15);
			this.patternMappings.Controls.Add(this.patternMapping14);
			this.patternMappings.Controls.Add(this.patternMapping13);
			this.patternMappings.Controls.Add(this.patternMapping12);
			this.patternMappings.Controls.Add(this.patternMapping11);
			this.patternMappings.Controls.Add(this.patternMapping10);
			this.patternMappings.Controls.Add(this.patternMapping9);
			this.patternMappings.Controls.Add(this.patternMapping8);
			this.patternMappings.Controls.Add(this.patternMapping7);
			this.patternMappings.Controls.Add(this.patternMapping6);
			this.patternMappings.Controls.Add(this.patternMapping5);
			this.patternMappings.Controls.Add(this.patternMapping4);
			this.patternMappings.Controls.Add(this.patternMapping3);
			this.patternMappings.Controls.Add(this.patternMapping2);
			this.patternMappings.Controls.Add(this.patternMapping1);
			this.patternMappings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.patternMappings.Location = new System.Drawing.Point(0, 13);
			this.patternMappings.MinimumSize = new System.Drawing.Size(362, 0);
			this.patternMappings.Name = "patternMappings";
			this.patternMappings.Size = new System.Drawing.Size(362, 615);
			this.patternMappings.TabIndex = 1;
			// 
			// mappingTypeDropdown
			// 
			this.mappingTypeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mappingTypeDropdown.FormattingEnabled = true;
			this.mappingTypeDropdown.Location = new System.Drawing.Point(136, 4);
			this.mappingTypeDropdown.Name = "mappingTypeDropdown";
			this.mappingTypeDropdown.Size = new System.Drawing.Size(121, 21);
			this.mappingTypeDropdown.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(62, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Mapping:";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(260, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Pattern mapping";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// patternMapping15
			// 
			this.patternMapping15.Location = new System.Drawing.Point(52, 577);
			this.patternMapping15.Name = "patternMapping15";
			this.patternMapping15.Size = new System.Drawing.Size(205, 34);
			this.patternMapping15.TabIndex = 14;
			// 
			// patternMapping14
			// 
			this.patternMapping14.Location = new System.Drawing.Point(52, 538);
			this.patternMapping14.Name = "patternMapping14";
			this.patternMapping14.Size = new System.Drawing.Size(205, 34);
			this.patternMapping14.TabIndex = 13;
			// 
			// patternMapping13
			// 
			this.patternMapping13.Location = new System.Drawing.Point(52, 499);
			this.patternMapping13.Name = "patternMapping13";
			this.patternMapping13.Size = new System.Drawing.Size(205, 34);
			this.patternMapping13.TabIndex = 12;
			// 
			// patternMapping12
			// 
			this.patternMapping12.Location = new System.Drawing.Point(52, 460);
			this.patternMapping12.Name = "patternMapping12";
			this.patternMapping12.Size = new System.Drawing.Size(205, 34);
			this.patternMapping12.TabIndex = 11;
			// 
			// patternMapping11
			// 
			this.patternMapping11.Location = new System.Drawing.Point(52, 421);
			this.patternMapping11.Name = "patternMapping11";
			this.patternMapping11.Size = new System.Drawing.Size(205, 34);
			this.patternMapping11.TabIndex = 10;
			// 
			// patternMapping10
			// 
			this.patternMapping10.Location = new System.Drawing.Point(52, 382);
			this.patternMapping10.Name = "patternMapping10";
			this.patternMapping10.Size = new System.Drawing.Size(205, 34);
			this.patternMapping10.TabIndex = 9;
			// 
			// patternMapping9
			// 
			this.patternMapping9.Location = new System.Drawing.Point(52, 343);
			this.patternMapping9.Name = "patternMapping9";
			this.patternMapping9.Size = new System.Drawing.Size(205, 34);
			this.patternMapping9.TabIndex = 8;
			// 
			// patternMapping8
			// 
			this.patternMapping8.Location = new System.Drawing.Point(52, 304);
			this.patternMapping8.Name = "patternMapping8";
			this.patternMapping8.Size = new System.Drawing.Size(205, 34);
			this.patternMapping8.TabIndex = 7;
			// 
			// patternMapping7
			// 
			this.patternMapping7.Location = new System.Drawing.Point(52, 265);
			this.patternMapping7.Name = "patternMapping7";
			this.patternMapping7.Size = new System.Drawing.Size(205, 34);
			this.patternMapping7.TabIndex = 6;
			// 
			// patternMapping6
			// 
			this.patternMapping6.Location = new System.Drawing.Point(52, 226);
			this.patternMapping6.Name = "patternMapping6";
			this.patternMapping6.Size = new System.Drawing.Size(205, 34);
			this.patternMapping6.TabIndex = 5;
			// 
			// patternMapping5
			// 
			this.patternMapping5.Location = new System.Drawing.Point(52, 187);
			this.patternMapping5.Name = "patternMapping5";
			this.patternMapping5.Size = new System.Drawing.Size(205, 34);
			this.patternMapping5.TabIndex = 4;
			// 
			// patternMapping4
			// 
			this.patternMapping4.Location = new System.Drawing.Point(52, 148);
			this.patternMapping4.Name = "patternMapping4";
			this.patternMapping4.Size = new System.Drawing.Size(205, 34);
			this.patternMapping4.TabIndex = 3;
			// 
			// patternMapping3
			// 
			this.patternMapping3.Location = new System.Drawing.Point(52, 109);
			this.patternMapping3.Name = "patternMapping3";
			this.patternMapping3.Size = new System.Drawing.Size(205, 34);
			this.patternMapping3.TabIndex = 2;
			// 
			// patternMapping2
			// 
			this.patternMapping2.Location = new System.Drawing.Point(52, 71);
			this.patternMapping2.Name = "patternMapping2";
			this.patternMapping2.Size = new System.Drawing.Size(205, 34);
			this.patternMapping2.TabIndex = 1;
			// 
			// patternMapping1
			// 
			this.patternMapping1.Location = new System.Drawing.Point(52, 31);
			this.patternMapping1.Name = "patternMapping1";
			this.patternMapping1.Size = new System.Drawing.Size(205, 34);
			this.patternMapping1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 681);
			this.Controls.Add(this.patternMappingPanel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Grayscale Image Converter";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
			this.patternMappingPanel.ResumeLayout(false);
			this.patternMappings.ResumeLayout(false);
			this.patternMappings.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label statusLabel;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox playdatePalette;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel patternMappingPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel patternMappings;
		private PatternMapping patternMapping15;
		private PatternMapping patternMapping14;
		private PatternMapping patternMapping13;
		private PatternMapping patternMapping12;
		private PatternMapping patternMapping11;
		private PatternMapping patternMapping10;
		private PatternMapping patternMapping9;
		private PatternMapping patternMapping8;
		private PatternMapping patternMapping7;
		private PatternMapping patternMapping6;
		private PatternMapping patternMapping5;
		private PatternMapping patternMapping4;
		private PatternMapping patternMapping3;
		private PatternMapping patternMapping2;
		private PatternMapping patternMapping1;
		private System.Windows.Forms.NumericUpDown numericUpDownX;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownY;
		private System.Windows.Forms.ComboBox mappingTypeDropdown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
	}
}

