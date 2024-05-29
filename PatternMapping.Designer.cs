namespace GrayscaleImageConverter
{
	partial class PatternMapping
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.colorPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.patternDropdown = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// colorPanel
			// 
			this.colorPanel.Location = new System.Drawing.Point(4, 4);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new System.Drawing.Size(65, 26);
			this.colorPanel.TabIndex = 0;
			this.colorPanel.Click += new System.EventHandler(this.colorPanel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(75, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "->";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(106, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(89, 26);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// patternDropdown
			// 
			this.patternDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.patternDropdown.FormattingEnabled = true;
			this.patternDropdown.Location = new System.Drawing.Point(201, 7);
			this.patternDropdown.Name = "patternDropdown";
			this.patternDropdown.Size = new System.Drawing.Size(53, 21);
			this.patternDropdown.TabIndex = 3;
			this.patternDropdown.SelectedIndexChanged += new System.EventHandler(this.patternDropdown_SelectedIndexChanged);
			// 
			// PatternMapping
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.patternDropdown);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.colorPanel);
			this.Name = "PatternMapping";
			this.Size = new System.Drawing.Size(261, 34);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel colorPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox patternDropdown;
	}
}
