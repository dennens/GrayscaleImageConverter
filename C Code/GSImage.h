#include "pd_api.h"
#include <math.h>

// C bools yay
#define bool int
#define true 1
#define false 0

// Define image type

// 2 shorts each for width and height
int GSImageHeaderSizeV1 = 4;
// 2 shorts each for width/height, and 3 ints containing pattern info
int GSImageHeaderSizeV2 = 4 + (4 * 3);
typedef struct GSImage
{
	int width;
	int height;
	bool hasPatternInfo;
	int usedPatternIndices[15];
	char* data;
} GSImage;

GSImage* loadGSImage(PlaydateAPI* pd, const char* path)
{
	// Get file size for allocating buffer
	FileStat stat;
	pd->file->stat(path, &stat);

	char* buffer = m3d_malloc(stat.size);

	// Read file into buffer
	SDFile* file = pd->file->open(path, kFileRead);
	pd->file->read(file, buffer, stat.size);

	// Setup image with file data
	GSImage* image = m3d_malloc(sizeof(GSImage));
	image->data = buffer;
	uint16_t* t = (uint16_t*)buffer;
	image->width = t[0];
	image->height = t[1];

	// Leftmost bit in width is used to indicate use of 33 potential patterns
	if ((image->width & (1 << 15)) > 0)
	{
		image->hasPatternInfo = true;
		image->width ^= 1 << 15;

		uint32_t* intBuffer = (uint32_t*)buffer;
		// first index is used by size
		uint32_t patternInt1 = buffer[1];
		uint32_t patternInt2 = buffer[2];
		uint32_t patternInt3 = buffer[3];
		for (int i = 0; i < 3; ++i)
		{
			uint32_t patternInt = intBuffer[i + 1];
			for (int j = 0; j < 5; ++j)
				image->usedPatternIndices[i * 5 + j] = patternInt >> (6 * (4 - j)) & 0x3F;
		}
	}
	else
		image->hasPatternInfo = false;

	return image;
}


typedef uint8_t Pattern[8];

static const Pattern patterns[] =
{
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
	{ 0x80, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00 },
	{ 0x88, 0x00, 0x00, 0x00, 0x88, 0x00, 0x00, 0x00 },
	{ 0x88, 0x00, 0x20, 0x00, 0x88, 0x00, 0x02, 0x00 },
	{ 0x88, 0x00, 0x22, 0x00, 0x88, 0x00, 0x22, 0x00 },
	{ 0xa8, 0x00, 0x22, 0x00, 0x8a, 0x00, 0x22, 0x00 },
	{ 0xaa, 0x00, 0x22, 0x00, 0xaa, 0x00, 0x22, 0x00 },
	{ 0xaa, 0x00, 0xa2, 0x00, 0xaa, 0x00, 0x2a, 0x00 },
	{ 0xaa, 0x00, 0xaa, 0x00, 0xaa, 0x00, 0xaa, 0x00 },
	{ 0xaa, 0x40, 0xaa, 0x00, 0xaa, 0x04, 0xaa, 0x00 },
	{ 0xaa, 0x44, 0xaa, 0x00, 0xaa, 0x44, 0xaa, 0x00 },
	{ 0xaa, 0x44, 0xaa, 0x10, 0xaa, 0x44, 0xaa, 0x01 },
	{ 0xaa, 0x44, 0xaa, 0x11, 0xaa, 0x44, 0xaa, 0x11 },
	{ 0xaa, 0x54, 0xaa, 0x11, 0xaa, 0x45, 0xaa, 0x11 },
	{ 0xaa, 0x55, 0xaa, 0x11, 0xaa, 0x55, 0xaa, 0x11 },
	{ 0xaa, 0x55, 0xaa, 0x51, 0xaa, 0x55, 0xaa, 0x15 },
	{ 0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55 },
	{ 0xba, 0x55, 0xaa, 0x55, 0xab, 0x55, 0xaa, 0x55 },
	{ 0xbb, 0x55, 0xaa, 0x55, 0xbb, 0x55, 0xaa, 0x55 },
	{ 0xbb, 0x55, 0xea, 0x55, 0xbb, 0x55, 0xae, 0x55 },
	{ 0xbb, 0x55, 0xee, 0x55, 0xbb, 0x55, 0xee, 0x55 },
	{ 0xfb, 0x55, 0xee, 0x55, 0xbf, 0x55, 0xee, 0x55 },
	{ 0xff, 0x55, 0xee, 0x55, 0xff, 0x55, 0xee, 0x55 },
	{ 0xff, 0x55, 0xfe, 0x55, 0xff, 0x55, 0xef, 0x55 },
	{ 0xff, 0x55, 0xff, 0x55, 0xff, 0x55, 0xff, 0x55 },
	{ 0xff, 0x55, 0xff, 0xd5, 0xff, 0x55, 0xff, 0x5d },
	{ 0xff, 0x55, 0xff, 0xdd, 0xff, 0x55, 0xff, 0xdd },
	{ 0xff, 0x75, 0xff, 0xdd, 0xff, 0x57, 0xff, 0xdd },
	{ 0xff, 0x77, 0xff, 0xdd, 0xff, 0x77, 0xff, 0xdd },
	{ 0xff, 0x77, 0xff, 0xfd, 0xff, 0x77, 0xff, 0xdf },
	{ 0xff, 0x77, 0xff, 0xff, 0xff, 0x77, 0xff, 0xff },
	{ 0xff, 0xf7, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff },
	{ 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }
};

// Fix little-endianness
int bitShiftIndices[] = { 7, 6, 5, 4, 3, 2, 1, 0,
							15, 14, 13, 12, 11, 10, 9, 8,
							23, 22, 21, 20, 19, 18, 17, 16,
							31, 30, 29, 28, 27, 26, 25, 24 };

static int v1PatternIndices[] = { 0, 2, 4, 6, 8, 10, 12, 16, 18, 22, 24, 26, 28, 30, 32 };

static void drawGSImage(PlaydateAPI* pd, GSImage* image, int drawX, int drawY)
{
	int width = image->width;
	int height = image->height;

	// Skip images that are entirely off-screen
	if (drawX > 400 || drawX + width < 0 || drawY > 240 || drawY + height < 0)
		return;

	// Get data from image
	char* imageData = image->data + (image->hasPatternInfo ? GSImageHeaderSizeV2 : GSImageHeaderSizeV1);

	// Setup patterns
	Pattern usedPatterns[15];
	if (image->hasPatternInfo)
	{
		// Get from image info
		for (int i = 0; i < 15; ++i)
		{
			const uint8_t* p = patterns[image->usedPatternIndices[i]];
			for (int b = 0; b < 8; ++b)
				usedPatterns[i][b] = p[b];
		}
	}
	else
	{
		// Or get default indices
		for (int i = 0; i < 15; ++i)
		{
			const uint8_t* p = patterns[v1PatternIndices[i]];
			for (int b = 0; b < 8; ++b)
				usedPatterns[i][b] = p[b];
		}
	}

	int halfWidth = width / 2;
	// Offset for image row number
	int imageYAddr = 0;
	// grayscale value of image pixel
	int imageValue = 0;

	uint32_t* buffer = (uint32_t*)pd->graphics->getFrame();

	// Currently drawing on this y coordinate
	int screenY = drawY;

	// Current address of byte in display buffer
	int bufferAddr = 0;
	// Bits to shift to get the right pixel
	int blitBitIndex = 0;
	// Image opacity mask
	uint32_t blitMask = 0;
	// Bit values to blit
	uint32_t blitValue = 0;
	// Horizontal address offset in frame buffer where blitting will happen
	int xAddr = 0;
	// Amount of bits to shift for setting specific bits in the blitvalue
	int bitShift;

	int x, y;
	y = 0;
	if (drawY < 0)
		y = -drawY;

	int screenX = drawX;
	if (drawX < 0)
		screenX = 0;

	for (; y < height; ++y)
	{
		screenY = y + drawY;
		if (screenY >= 240) break;

		xAddr = screenX / 32;
		bufferAddr = screenY * 13 + xAddr;
		blitBitIndex = screenX - xAddr * 32;

		imageYAddr = y * halfWidth;

		blitMask = 0;
		blitValue = 0;

		x = 0;
		if (drawX < 0)
			x = -drawX;
		for (; x < width; ++x)
		{
			// Get grayscale value from image data
			// Value: between 0 and 15 where 0 is transparent, 1 is black, 15 is white
			int imageAddr = (x / 2) + imageYAddr;
			imageValue = ((imageData[imageAddr]) >> (4 * (x & 1))) & 0x0F;
			int sx = x + drawX;

			// Get bit from pattern
#define _PATTERN ((uint8_t*)&usedPatterns[imageValue - 1])
#define _PATTERNROW _PATTERN[screenY & 7]

			// Check if we can blit a full 32bit int rather than individual pixels
			if (blitBitIndex == 0 && x + 32 < width)
			{
				bool blitFullInt = true;
				// 8-bit value for checking bytes quickly
				int valueIfSame = imageValue + (imageValue << 4);
				// Loop through 16 bytes (32 4-bit pixels)
				for (int i = 0; i < 16; ++i)
				{
					if (imageData[imageAddr + i] != valueIfSame)
					{
						// Can't blit full integer at once, break to regular flow
						blitFullInt = false;
						break;
					}
				}
				if (blitFullInt)
				{
					// imageValue of 0 means transparency - skip rather than blitting
					if (imageValue > 0)
					{
						for (int i = 0; i < 4; ++i)
							blitValue |= (_PATTERNROW) << (i * 8);
						buffer[bufferAddr] = blitValue;
					}
					++bufferAddr;
					blitBitIndex = 0;
					blitMask = 0;
					blitValue = 0;
					x += 31;	// final ++ is done in loop
					if (sx > 400)
						break;
					continue;
				}
			}
			// Regular pixel-by-pixel blitting
			if (imageValue > 0)
			{
				// Set mask and value for this bit
				bitShift = bitShiftIndices[blitBitIndex];
				blitMask |= 1 << bitShift;

				blitValue |= ((_PATTERNROW >> (7 - (sx & 7))) & 1) << bitShift;
			}
			// Blit resulting int
			if (++blitBitIndex > 31 || x == width - 1)
			{
				// Reached end of int, write blit and advance
				buffer[bufferAddr] &= ~blitMask;
				buffer[bufferAddr] |= blitValue;
				++bufferAddr;

				// Reset for next int
				blitBitIndex = 0;
				blitMask = 0;
				blitValue = 0;
				if (sx > 400)
					break;
			}
		}
	}
}
