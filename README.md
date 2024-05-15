# Grayscale Image (GSI) converter
Tool to convert any grayscale image to a 4bpp indexed image format (15 tints + transparent), to be drawn with 1-bit dithered patterns.

Also includes the code to draw the resulting image files for the playdate.

# Setup
- Converter tool (Windows only): Download and run the .exe from bin/Release
- Playdate drawing: Download the GSImage.h file from 'C Code/' into your Playdate c project

# Basic usage
Load an image file using File->Load image (or ctrl+L). Colors will automatically be assigned a matching pattern. Export using File->Export GSI for run-time dithered drawing, or File->Export PNG for a pre-dithered image.

In C, load the GSI image using the `loadGSImage` function, and draw it using the `drawGSImage` function.

# Additional features
- The image will be drawn in the tool using run-time dithering. You can drag the preview window to move the image around and see how this affects how it looks.
- Dither patterns can be mapped automatically using the Mapping dropdown, and/or modified using the per-color pattern dropdowns.
- The preview can be zoomed using Alt+1/2/3
- The preview background can be set to either white, black, or checkered
- The preview can be drawn using either pure black+white, or using the playdate simulator colors.

# GSImage file format
Width: 16 bits
Height: 16 bits
Data: 4bpp 16-bit pattern indices

# Notes
- Input images need to have a multiple of 2 for its width
- This is a fairly naive approach to drawing. If you plan to draw a lot of images at the same time, you may run into performance problems. Let me know if you have any ideas for improvements
