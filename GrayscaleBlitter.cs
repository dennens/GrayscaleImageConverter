﻿using System;
using System.Drawing;

namespace GrayscaleImageConverter
{
	internal class GrayscaleBlitter
	{
		public static byte[][] patterns = new byte[][]
		{
			new byte[]{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
			new byte[]{ 0x80, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00 },
			new byte[]{ 0x88, 0x00, 0x00, 0x00, 0x88, 0x00, 0x00, 0x00 },
			new byte[]{ 0x88, 0x00, 0x20, 0x00, 0x88, 0x00, 0x02, 0x00 },
			new byte[]{ 0x88, 0x00, 0x22, 0x00, 0x88, 0x00, 0x22, 0x00 },
			new byte[]{ 0xa8, 0x00, 0x22, 0x00, 0x8a, 0x00, 0x22, 0x00 },
			new byte[]{ 0xaa, 0x00, 0x22, 0x00, 0xaa, 0x00, 0x22, 0x00 },
			new byte[]{ 0xaa, 0x00, 0xa2, 0x00, 0xaa, 0x00, 0x2a, 0x00 },
			new byte[]{ 0xaa, 0x00, 0xaa, 0x00, 0xaa, 0x00, 0xaa, 0x00 },
			new byte[]{ 0xaa, 0x40, 0xaa, 0x00, 0xaa, 0x04, 0xaa, 0x00 },
			new byte[]{ 0xaa, 0x44, 0xaa, 0x00, 0xaa, 0x44, 0xaa, 0x00 },
			new byte[]{ 0xaa, 0x44, 0xaa, 0x10, 0xaa, 0x44, 0xaa, 0x01 },
			new byte[]{ 0xaa, 0x44, 0xaa, 0x11, 0xaa, 0x44, 0xaa, 0x11 },
			new byte[]{ 0xaa, 0x54, 0xaa, 0x11, 0xaa, 0x45, 0xaa, 0x11 },
			new byte[]{ 0xaa, 0x55, 0xaa, 0x11, 0xaa, 0x55, 0xaa, 0x11 },
			new byte[]{ 0xaa, 0x55, 0xaa, 0x51, 0xaa, 0x55, 0xaa, 0x15 },
			new byte[]{ 0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55 },
			new byte[]{ 0xba, 0x55, 0xaa, 0x55, 0xab, 0x55, 0xaa, 0x55 },
			new byte[]{ 0xbb, 0x55, 0xaa, 0x55, 0xbb, 0x55, 0xaa, 0x55 },
			new byte[]{ 0xbb, 0x55, 0xea, 0x55, 0xbb, 0x55, 0xae, 0x55 },
			new byte[]{ 0xbb, 0x55, 0xee, 0x55, 0xbb, 0x55, 0xee, 0x55 },
			new byte[]{ 0xfb, 0x55, 0xee, 0x55, 0xbf, 0x55, 0xee, 0x55 },
			new byte[]{ 0xff, 0x55, 0xee, 0x55, 0xff, 0x55, 0xee, 0x55 },
			new byte[]{ 0xff, 0x55, 0xfe, 0x55, 0xff, 0x55, 0xef, 0x55 },
			new byte[]{ 0xff, 0x55, 0xff, 0x55, 0xff, 0x55, 0xff, 0x55 },
			new byte[]{ 0xff, 0x55, 0xff, 0xd5, 0xff, 0x55, 0xff, 0x5d },
			new byte[]{ 0xff, 0x55, 0xff, 0xdd, 0xff, 0x55, 0xff, 0xdd },
			new byte[]{ 0xff, 0x75, 0xff, 0xdd, 0xff, 0x57, 0xff, 0xdd },
			new byte[]{ 0xff, 0x77, 0xff, 0xdd, 0xff, 0x77, 0xff, 0xdd },
			new byte[]{ 0xff, 0x77, 0xff, 0xfd, 0xff, 0x77, 0xff, 0xdf },
			new byte[]{ 0xff, 0x77, 0xff, 0xff, 0xff, 0x77, 0xff, 0xff },
			new byte[]{ 0xff, 0xf7, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff },
			new byte[]{ 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }
		};

		private static int LerpInt(int a, int b, float t)
		{
			return (int)((1 - t) * a + (b * t));
		}

		private static Color ColorLerp(Color c1, Color c2, float factor)
		{
			return Color.FromArgb(LerpInt(c1.R, c2.R, factor), LerpInt(c1.G, c2.G, factor), LerpInt(c1.B, c2.B, factor));
		}

		public static DirectBitmap BlitGrayscale(byte[] imageData, byte[] usedPatternIndices, int drawX, int drawY, int width, int height, Color blackColor, Color whiteColor, DirectBitmap imageSource, Color highlightedColor, Color highlightColor)
		{
			DirectBitmap result = new DirectBitmap(width, height);
			int halfWidth = width / 2;
			// Offset for image row number
			int imageYAddr;
			// grayscale value of image pixel
			int imageValue = 0;

			// Currently drawing on this y coordinate
			int screenY = drawY;

			int x, y;
			try
			{
				for (y = 0; y < height; ++y)
				{
					screenY = y + drawY;
					//if (screenY >= 240) break;

					imageYAddr = y * halfWidth;

					for (x = 0; x < width; ++x)
					{
						// Get grayscale value from image data
						// Value: between 0 and 15 where 0 is transparent, 1 is black, 15 is white
						imageValue = ((imageData[(x / 2) + imageYAddr]) >> (4 * (x & 1))) & 0x0F;

						if (imageValue > 0)
						{
							// Get bit from pattern
							byte[] pattern = patterns[usedPatternIndices[imageValue - 1]];
							byte patternRow = pattern[screenY & 7];
							int shift = (x + drawX) & 7;
							uint bit = (uint)(patternRow >> shift) & 1;
							Color c = bit == 1 ? whiteColor : blackColor;
							if (highlightedColor != Color.Transparent
								&& imageSource != null
								&& imageSource.GetPixel(x, y) == highlightedColor)
								c = ColorLerp(c, highlightColor, 0.7f);
							result.SetPixel(x, y, c);
						}
						else
						{
							result.SetPixel(x, y, Color.Transparent);
						}
					}
				}
			} catch (Exception e)
			{
				int i = 0;
			}
			return result;
		}
	}
}
