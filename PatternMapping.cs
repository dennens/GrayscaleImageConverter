using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrayscaleImageConverter
{
	public partial class PatternMapping : UserControl
	{
		Form1 parent;
		Color color;

		private bool canFireEvent = false;

		static List<Bitmap> palette = new List<Bitmap>();
		public static List<int> patternBrightness = new List<int>();
		static int[] NIBBLE_LOOKUP = { 0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4 };

		static int count_ones(byte b)
		{
			return NIBBLE_LOOKUP[b & 0x0F] + NIBBLE_LOOKUP[b >> 4];
		}

		static PatternMapping()
		{
			int width = 90;
			int height = 26;
			for (int i = 0; i < 15; ++i)
			{
				int mapping = i + 1;
				byte[] data = new byte[width * height / 2];
				for (int d = 0; d < data.Length; ++d)
				{
					data[d] = (byte)((mapping << 4) | mapping);
				}
				using (DirectBitmap pattern = GrayscaleBlitter.BlitGrayscale(data, 0, 0, width, height, Color.Black, Color.White))
					palette.Add(new Bitmap(pattern.Bitmap));


				byte[] patternBytes = GrayscaleBlitter.patterns[i];
				int white = 0;
				for (int b = 0; b < patternBytes.Length; ++b)
					white += count_ones(patternBytes[b]);
				patternBrightness.Add(white * 100 / 64);
			}
		}

		public PatternMapping()
		{
			InitializeComponent();

			canFireEvent = false;
			for (int i = 1; i < 16; ++i)
			{
				patternDropdown.Items.Add(patternBrightness[i - 1] + "%");
			}
		}

		public void Init(Form1 parent, int currentMapping, Color color)
		{
			canFireEvent = false;

			this.parent = parent;
			this.color = color;

			colorPanel.BackColor = color;
			patternDropdown.SelectedIndex = currentMapping - 1;
			pictureBox1.Image = palette[currentMapping - 1];

			canFireEvent = true;
		}

		private void patternDropdown_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!canFireEvent) return;

			parent.OnMappingChanged(color, patternDropdown.SelectedIndex + 1);
		}
	}
}
