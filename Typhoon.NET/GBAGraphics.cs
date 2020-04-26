using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;

namespace Typhoon.NET
{
    public static class GBAGraphics
    {
        public static Color DecodeGBAPalette(ushort GBAPalette)
        {
            ushort Red = Convert.ToUInt16((GBAPalette & 31) << 3);
            ushort Green = Convert.ToUInt16(((GBAPalette >> 5) & 31) << 3);
            ushort Blue = Convert.ToUInt16(((GBAPalette >> 10) & 31) << 3);

            return Color.FromArgb(Red, Green, Blue);
        }

        public static void DrawTile(FastPixel fp, int TileIndex, int TileSize, int TilesPerRow, byte[] Graphics, Color[] Palette)
        {
            int x = 0;
            int y = 0;
            byte[] GraphicsBuffer = new byte[32];
            int DestX = (TileIndex % TilesPerRow) * TileSize;
            int DestY = (TileIndex / TilesPerRow) * TileSize;

            Array.Copy(Graphics, (TileIndex & 0x3FF) << 5, GraphicsBuffer, 0, 32);
            for (int i = 0; i < 32; i++)
            {
                byte color1 = Convert.ToByte((GraphicsBuffer[i] >> 4) & 0xF);
                byte color2 = Convert.ToByte(GraphicsBuffer[i] & 0xF);

                fp.SetPixel(DestX + x + 1, DestY + y, Palette[color1]);
                fp.SetPixel(DestX + x, DestY + y, Palette[color2]);

                x += 2;
                if (x == 8)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }
}
