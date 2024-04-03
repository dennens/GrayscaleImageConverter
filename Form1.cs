using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrayscaleImageConverter
{
	public partial class Form1 : Form
	{
		class ImageProcessing
		{
			public List<Color> colors;
			public Dictionary<Color, int> patternMapping = new Dictionary<Color, int>();
			public byte[] imageData;
		}

		class ImageProcessingSource
		{
			public Bitmap image;
			public Dictionary<Color, int> patternMapping;
		}

		int imageWidth = 0;
		int imageHeight = 0;
		int imageX = 0;
		int imageY = 0;
		int imageXOnDrag = 0;
		int imageYOnDrag = 0;

		bool mouseDragging = false;
		int mouseX = 0;
		int mouseY = 0;
		int scale = 1;

		public Color blackColor = Color.Black;
		public Color whiteColor = Color.White;

		Bitmap imageSource;
		ImageProcessing processedImage;

		Bitmap previewImage = new Bitmap(400, 240);
		enum BackgroundType
		{
			White,
			Black,
			Checkered
		}
		BackgroundType bgType = BackgroundType.White;

		enum MappingType
		{
			Match,
			Brightest,
			Darkest,
			Central,
			Spread,
			Contrast,
			Custom
		}

		MappingType mappingType = MappingType.Match;

		List<PatternMapping> mappingSwatches = new List<PatternMapping>();

		public Form1()
		{
			InitializeComponent();
			comboBox1.DataSource = Enum.GetValues(typeof(BackgroundType));
			comboBox1.SelectedItem = bgType;

			mappingTypeDropdown.DataSource = Enum.GetValues(typeof(MappingType));
			mappingTypeDropdown.SelectedItem = mappingType;
			mappingTypeDropdown.SelectedIndexChanged += mappingTypeDropdown_SelectedIndexChanged;

			for (int i = 0; i < patternMappings.Controls.Count; ++i)
			{
				PatternMapping ctrl = patternMappings.Controls[i] as PatternMapping;
				if (ctrl != null)
				{
					mappingSwatches.Add(patternMappings.Controls[i] as PatternMapping);
					patternMappings.Controls[i].Enabled = false;
				}
			}
			mappingSwatches.Sort((a, b) => a.Location.Y.CompareTo(b.Location.Y));
		}

		private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.FileName.EndsWith("gsi"))
				{
					byte[] data = System.IO.File.ReadAllBytes(dlg.FileName);
					int width0 = (int)data[0];
					int width1 = (int)data[1];
					int width = width0 + (width1 << 8);

					int height0 = (int)data[2];
					int height1 = (int)data[3];
					int height = height0 + (height1 << 8);

					int i = 4;

					// Temp list of colors
					List<Color> colors = new List<Color>();
					colors.Add(Color.Transparent);
					for (int c = 0; c < 15; ++c)
						colors.Add(Color.FromArgb(c * 16, c * 16, c * 16));

					using (DirectBitmap bmp = new DirectBitmap(width, height))
					{
						for (int y = 0; y < height; ++y)
							for (int x = 0; x < width / 2; ++x)
							{
								byte v = data[i];
								int vl = (v >> 4) & 0x0F;
								int vr = v & 0x0F;
								bmp.SetPixel(x * 2, y, colors[vl]);
								bmp.SetPixel(x * 2 + 1, y, colors[vr]);
								++i;
							}
						imageSource = new Bitmap(bmp.Bitmap);
					}
				}
				else
				{
					using (Bitmap tmp = new Bitmap(dlg.FileName))
						imageSource = new Bitmap(tmp);
				}

				imageWidth = imageSource.Width;
				imageHeight = imageSource.Height;
				if (imageWidth % 2 != 0)
				{
					MessageBox.Show("Image width not a multiple of 2 (" + imageWidth + "), aborting");
					return;
				}

				ImageProcessingSource input = new ImageProcessingSource();
				processedImage = null;
				input.image = imageSource;
				input.patternMapping = null;
				if (mappingType == MappingType.Custom)
					mappingType = MappingType.Match;

				imageX = 0;
				imageY = 0;

				backgroundWorker1.RunWorkerAsync(input);
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			ImageProcessingSource input = (ImageProcessingSource)e.Argument;
			Bitmap source = input.image;

			backgroundWorker1.ReportProgress(1, "Generating palette...");

			List<Color> colors = new List<Color>();

			// Get all grayscale colors from image
			for (int y = 0; y < source.Height; ++y)
			{
				for (int x = 0; x < source.Width; ++x)
				{
					Color c = source.GetPixel(x, y);
					if (!colors.Contains(c))
						colors.Add(c);
				}
			}
			if (colors.Count > 16)
			{
				e.Cancel = true;
				backgroundWorker1.ReportProgress(0, "File has too many colors! " + colors.Count + " colors detected, max is 16 (including transparent).");
				return;
			}

			colors.Sort((a, b) => a.A < b.A ? -1 : b.A > a.A ? 1 : a.R.CompareTo(b.R));
			if (colors[0].A != 0)
				colors.Insert(0, Color.Transparent);

			Dictionary<Color, int> mapping = input.patternMapping;
			if (mapping == null)
			{
				mapping = new Dictionary<Color, int>
				{
					{ colors[0], 0 }
				};
				switch (mappingType)
				{
					case MappingType.Match:
						for (int i = 1; i < colors.Count; ++i)
						{
							float color = colors[i].R / 2.55f;
							int closest = 1;
							float closestError = 100;
							for (int p = 0; p < PatternMapping.patternBrightness.Count; ++p)
							{
								float error = Math.Abs(color - PatternMapping.patternBrightness[p]);
								if (error < closestError)
								{
									closest = p + 1;
									closestError = error;
								}
							}
							mapping.Add(colors[i], closest);
						}
						break;
					case MappingType.Spread:
						float stepSize = (colors.Count - 1) / 15f;
						float currentStep = 1;
						int colorIndex = 1;
						for (int i = 1; i < 16; ++i)
						{
							if (currentStep >= colorIndex)
								mapping.Add(colors[colorIndex++], i);
							currentStep += stepSize;
						}
						break;
					case MappingType.Contrast:
						int halfNumColors = (colors.Count - 1) / 2;
						colorIndex = 1;
						for (int i = 0; i < halfNumColors; ++i)
							mapping.Add(colors[colorIndex++], i + 1);

						for (int i = 16 - (colors.Count - 1 - halfNumColors); i < 16; ++i)
							mapping.Add(colors[colorIndex++], i);
						break;
					case MappingType.Central:
						int diff = 16 - colors.Count;
						diff /= 2;
						for (int i = diff + 1; i < diff + colors.Count; ++i)
							mapping.Add(colors[i - diff], i);
						break;
					case MappingType.Brightest:
						int start = 16 - colors.Count;
						for (int i = start + 1; i < 16; ++i)
							mapping.Add(colors[i - start], i);
						break;
					case MappingType.Darkest:
						for (int i = 1; i < colors.Count; ++i)
							mapping.Add(colors[i], i);
						break;
				}
			}

			backgroundWorker1.ReportProgress(50, "Indexing image");
			byte[] data = new byte[source.Width * source.Height / 2];
			int dataIndex = 0;

			for (int y = 0; y < source.Height; ++y)
			{
				for (int x = 0; x < source.Width; x += 2)
				{
					Color c1 = source.GetPixel(x, y);
					Color c2 = source.GetPixel(x + 1, y);

					int v1 = mapping[c1];
					int v2 = mapping[c2];

					byte res = (byte)((v2 << 4) + v1);
					data[dataIndex++] = res;
				}
			}

			backgroundWorker1.ReportProgress(100, "Image processed");
			ImageProcessing result = new ImageProcessing();
			result.patternMapping = mapping;
			result.imageData = data;
			result.colors = colors;
			e.Result = result;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				return;

			processedImage = (ImageProcessing)e.Result;
			pictureBox1.Invalidate();

			SuspendLayout();
			int swatchIndex = 0;
			for (int i = 1; i < processedImage.colors.Count; ++i)
			{
				Color c = processedImage.colors[i];
				mappingSwatches[swatchIndex].Enabled = true;
				mappingSwatches[swatchIndex].Init(this, processedImage.patternMapping[c], c);
				++swatchIndex;
			}
			for (; swatchIndex < 15; ++swatchIndex)
				mappingSwatches[swatchIndex].Enabled = false;
			ResumeLayout();
		}

		public void OnMappingChanged(Color color, int newMapping)
		{
			mappingTypeDropdown.SelectedItem = MappingType.Custom;

			processedImage.patternMapping[color] = newMapping;

			ImageProcessingSource input = new ImageProcessingSource();
			input.image = imageSource;
			input.patternMapping = processedImage?.patternMapping;
			backgroundWorker1.RunWorkerAsync(input);
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// error state
			if (e.ProgressPercentage == 0)
			{
				processedImage = null;
				MessageBox.Show((string)e.UserState);
			}
			else
				statusLabel.Text = (string)e.UserState;

			progressBar1.Value = e.ProgressPercentage;
		}

		private void exportAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (processedImage == null) return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = "gsi";
			dlg.Filter = "Grayscale images(*.gsi)|*.gsi|All files (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				// Save file...
				// Size header (shorts)
				List<byte> sizeBytes = new List<byte>();
				int heightB1 = imageHeight & 0xFF;
				int heightB2 = (imageHeight >> 8) & 0xFF;
				int widthB1 = imageWidth & 0xFF;
				int widthB2 = (imageWidth >> 8) & 0xFF;
				sizeBytes.Add((byte)widthB1);
				sizeBytes.Add((byte)widthB2);
				sizeBytes.Add((byte)heightB1);
				sizeBytes.Add((byte)heightB2);

				List<byte> bytes = processedImage.imageData.ToList();
				bytes.InsertRange(0, sizeBytes);

				System.IO.File.WriteAllBytes(dlg.FileName, bytes.ToArray());
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (processedImage == null) return;

			Graphics g = Graphics.FromImage(previewImage);
			switch (bgType)
			{
				case BackgroundType.White:
					g.Clear(whiteColor);
					break;
				case BackgroundType.Black:
					g.Clear(blackColor);
					break;
				case BackgroundType.Checkered:
					g.Clear(whiteColor);

					Brush b = new SolidBrush(blackColor);
					for (int x = 0; x < 400 / 8; x += 2)
						for (int y = 0; y < 240 / 8; ++y)
						{
							g.FillRectangle(b, new Rectangle((x * 8) + (8 * (y % 2)), y * 8, 8, 8));
						}
					break;
			}

			using (DirectBitmap dithered = GrayscaleBlitter.BlitGrayscale(processedImage.imageData, imageX, imageY, imageWidth, imageHeight, blackColor, whiteColor))
				g.DrawImage(dithered.Bitmap, new Point(imageX, imageY));

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(previewImage, new Rectangle(0, 0, 400 * scale, 240 * scale));
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDragging)
			{
				imageX = imageXOnDrag + (e.X - mouseX) / scale;
				imageY = imageYOnDrag + (e.Y - mouseY) / scale;
				numericUpDownX.Value = imageX;
				numericUpDownY.Value = imageY;

				pictureBox1.Invalidate();
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDragging = true;
			mouseX = e.X;
			mouseY = e.Y;
			imageXOnDrag = imageX;
			imageYOnDrag = imageY;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDragging = false;
		}

		private void SetScale(int scale)
		{
			pictureBox1.Width = 400 * scale;
			pictureBox1.Height = 240 * scale;
			this.scale = scale;
			pictureBox1.Invalidate();
		}

		private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetScale(1);
		}

		private void x2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetScale(2);
		}

		private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetScale(3);
		}

		private void playdatePalette_CheckedChanged(object sender, EventArgs e)
		{
			if (playdatePalette.Checked)
			{
				blackColor = Color.FromArgb(255, 48, 46, 39);
				whiteColor = Color.FromArgb(255, 176, 174, 167);
			}
			else
			{
				blackColor = Color.Black;
				whiteColor = Color.White;
			}
			pictureBox1.Invalidate();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Enum.TryParse(comboBox1.SelectedValue.ToString(), out bgType);
			pictureBox1.Invalidate();
		}

		private void numericUpDownY_ValueChanged(object sender, EventArgs e)
		{
			if (!mouseDragging)
			{
				imageY = (int)numericUpDownY.Value;
				pictureBox1.Invalidate();
			}
		}

		private void numericUpDownX_ValueChanged(object sender, EventArgs e)
		{
			if (!mouseDragging)
			{
				imageX = (int)numericUpDownX.Value;
				pictureBox1.Invalidate();
			}
		}

		private void mappingTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
		{
			MappingType newType = (MappingType)mappingTypeDropdown.SelectedValue;
			if (newType == mappingType) return;

			mappingType = newType;
			if (mappingType == MappingType.Custom) return;

			ImageProcessingSource input = new ImageProcessingSource();
			input.image = imageSource;
			input.patternMapping = null;
			backgroundWorker1.RunWorkerAsync(input);
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (processedImage == null) return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = "png";
			dlg.Filter = "PNG images(*.png)|*.png|All files (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				using (DirectBitmap dithered = GrayscaleBlitter.BlitGrayscale(processedImage.imageData, 0, 0, imageWidth, imageHeight, Color.Black, Color.White))
					dithered.Bitmap.Save(dlg.FileName);
			}
		}
	}
}
