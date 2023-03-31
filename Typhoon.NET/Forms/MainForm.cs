using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Typhoon.Core.Drawing;

namespace Typhoon.NET
{
    public partial class MainForm : Form
    {
        private const int DEC = 10;
        private const int HEX = 16;
        private const int TileSize = 8;
        private const int TileblockSize = 16;
        private const int TileblocksPerRow = 8;

        ushort BlockAmount = 0;
        int MapWidth, MapHeight;
        int PaletteRows, TilesAmount;
        int CurrentTileblock = 0, TopTile = 0, BottomTile = 0;
        int TilesPerRow = 1;

        Bitmap TilesImage, TilesetImage, MapImage, BottomImage;
        Graphics TilesetGraphics, MapGraphics, BottomGraphics;

        string TilesPath, TilesetPath, PalettePath, TilemapPath;

        Color[] Palette;
        byte[] TileGraphics;
        ushort[,] MapData;
        TileData[] TilesetData;

        private readonly Surface tileTopLayerSurface;

        private readonly Surface currentTileSurface;
        private readonly Surface currentTileblockSurface;

        private readonly EditorContext context;

        public MainForm()
        {
            InitializeComponent();

            context = new EditorContext
            {
                CurrentTile = 0,
                FourBitsPerPixelTiles = false
            };

            currentTileSurface = new Surface(48, 48, InterpolationMode.NearestNeighbor);
            picCurrentTile.Image = currentTileSurface.GetBitmap();

            currentTileblockSurface = new Surface(48, 48, InterpolationMode.NearestNeighbor);
            picCurrentTileblock.Image = currentTileblockSurface.GetBitmap();

            BottomImage = new Bitmap(48, 48);
            picBottom.Image = BottomImage;
            BottomGraphics = Graphics.FromImage(BottomImage);
            BottomGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            tileTopLayerSurface = new Surface(48, 48, InterpolationMode.NearestNeighbor);
            picTop.Image = tileTopLayerSurface.GetBitmap();

            Width = 662;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuOpenTiles_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog
            {
                Title = "Open Tiles...",
                Filter = "All Supported Files (*.bin;*.bmp;*.png;*.raw)|*.bin;*.bmp;*.png;*.raw|Binary Files (*.bin)|*.bin|Bitmap Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|RAW Files (*.raw)|*.raw"
            })
            {
                if (openDialog.ShowDialog() != DialogResult.OK) return;

                TilesPath = openDialog.FileName;
                if (Path.GetExtension(TilesPath) == ".bin" || Path.GetExtension(TilesPath) == ".raw")
                {
                    context.FourBitsPerPixelTiles = true;
                    MessageBox.Show("This option allows you to load a binary or raw file with graphics data in 4bpp format but you would also need to provide palette data in GBA format. You can easily do this by using WinGrit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var cdgOpenPalette = new OpenFileDialog();
                    cdgOpenPalette.Title = "Open Palette...";
                    cdgOpenPalette.Filter = "All Supported Files (*.bin;*.raw)|*.bin;*.raw|Binary Files (*.bin)|*.bin|RAW Files (*.raw)|*.raw";

                    if (cdgOpenPalette.ShowDialog() != DialogResult.OK)
                    {
                        openDialog.Dispose();
                        cdgOpenPalette.Dispose();
                        return;
                    }

                    PalettePath = cdgOpenPalette.FileName;
                    TilesImage = RenderTiles(TilesPath, PalettePath);
                    picTiles.Image = TilesImage;

                    cdgOpenPalette.Dispose();
                }
                else
                {
                    TilesImage = new Bitmap(Bitmap.FromFile(TilesPath));
                    picTiles.Image = TilesImage;
                }

                if (!GameDevModeMenuItem.Checked)
                    TilesPerRow = (TilesImage.Width / TileSize);
                else
                    TilesPerRow = (TilesImage.Width / TileblockSize);

                picTop.Visible = true;
                picBottom.Visible = true;
                pnlTiles.Visible = true;
                picCurrentTile.Visible = true;

                chkHFlip.Enabled = true;
                chkVFlip.Enabled = true;
                txtWidth.Enabled = true;
                txtHeight.Enabled = true;
                mnuNewTilemap.Enabled = true;
                GameDevModeMenuItem.Enabled = true;
                mnuOpenTilemap.Enabled = true;
                PaletteIndexCombo.Enabled = true;

                txtWidth.Text = 32.ToString();
                txtHeight.Text = 32.ToString();

                DrawCurrentTile();
                PaletteIndexCombo.SelectedIndex = 0;
            }
        }

        private void mnuOpenTilemap_Click(object sender, EventArgs e)
        {
            OpenFileDialog cdgOpen = new OpenFileDialog();
            cdgOpen.Title = "Open Tilemap...";
            cdgOpen.Filter = "All Supported Files (*.bin;*.raw;*.tilemap)|*.bin;*.dmp;*.raw;*.tilemap|Binary Files (*.bin)|*.bin|RAW Files (*.raw)|*.raw|Tilemap Files (*.tilemap)|*.tilemap";

            if (cdgOpen.ShowDialog() == DialogResult.OK)
            {
                TilemapPath = cdgOpen.FileName;
                BinaryReader ReadROM = new BinaryReader(File.Open(TilemapPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

                ReadROM.BaseStream.Position = 0;
                if (!GameDevModeMenuItem.Checked)
                {
                    MapWidth = Convert.ToInt32(txtWidth.Text);
                    MapHeight = Convert.ToInt32(txtHeight.Text);
                }
                else
                {
                    MapWidth = ReadROM.ReadInt32();
                    MapHeight = ReadROM.ReadInt32();

                    ReadROM.BaseStream.Position = 0x1D;
                }

                MapData = new ushort[MapWidth, MapHeight];
                try
                {
                    for (int y = 0; y < MapHeight; y++)
                        for (int x = 0; x < MapWidth; x++)
                            MapData[x, y] = ReadROM.ReadUInt16();
                }
                catch
                {
                }

                ReadROM.Close();

                MapImage = RenderTilemap();
                picMap.Image = MapImage;

                pnlMap.Visible = true;
                mnuSaveTilemap.Enabled = true;
                MapGraphics = Graphics.FromImage(MapImage);
            }

            cdgOpen.Dispose();
        }

        private void picTiles_Paint(object sender, PaintEventArgs e)
        {
            Pen Cursor = new Pen(Color.Blue, 2f);
            if (GameDevModeMenuItem.Checked)
                e.Graphics.DrawRectangle(Cursor, (context.CurrentTile % TilesPerRow) * TileblockSize, (context.CurrentTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
            else
                e.Graphics.DrawRectangle(Cursor, (context.CurrentTile % TilesPerRow) * TileSize, (context.CurrentTile / TilesPerRow) * TileSize, TileSize, TileSize);
        }

        private void picTiles_MouseHandle(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= TilesImage.Width || e.Y < 0 || e.Y >= TilesImage.Height)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            if (!GameDevModeMenuItem.Checked)
                context.CurrentTile = ((e.Y / TileSize) * TilesPerRow) + (e.X / TileSize);
            else
                context.CurrentTile = ((e.Y / TileblockSize) * TilesPerRow) + (e.X / TileblockSize);
            DrawCurrentTile();

            lblCurrentTile.Text = "Current Tile: 0x" + Convert.ToString(context.CurrentTile, HEX).ToUpper();
            picTiles.Invalidate();
        }

        private void DrawCurrentTile()
        {
            var tileSize = GameDevModeMenuItem.Checked ? TileblockSize : TileSize;
            var x = (context.CurrentTile % TilesPerRow) * tileSize;
            var y = (context.CurrentTile / TilesPerRow) * tileSize;            

            var dest = new Rectangle(0, 0, 48, 48);
            var src = new Rectangle(x, y, tileSize, tileSize);

            var surface = new Surface(TilesImage);
            currentTileSurface.DrawImage(surface, src, dest);

            picCurrentTile.Invalidate();
        }

        private Bitmap RenderTiles(string TilesFile, string PaletteFile)
        {
            Bitmap Tiles = new Bitmap(256, 256);
            Graphics TilesGraphics = Graphics.FromImage(Tiles);
            BinaryReader ReadTiles = new BinaryReader(File.Open(TilesFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            BinaryReader ReadPalette = new BinaryReader(File.Open(PaletteFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

            ReadTiles.BaseStream.Position = 0; // Read entire file for tiles
            int FileSize = (int)ReadTiles.BaseStream.Length;
            TileGraphics = ReadTiles.ReadBytes(FileSize);

            ReadPalette.BaseStream.Position = 0; // Read entire file for palettes
            FileSize = (int)ReadPalette.BaseStream.Length / 2;

            ushort[] TilePalette = new ushort[FileSize];
            for (int i = 0; i < FileSize; i++)
                TilePalette[i] = ReadPalette.ReadUInt16();

            // Get Limit for ComboBox
            PaletteRows = FileSize / 16; // 16 colors in a row (32 bytes)

            // Decode Palettes
            Palette = new Color[FileSize];
            for (int i = 0; i < FileSize; i++)
                Palette[i] = GBAGraphics.DecodeGBAPalette(TilePalette[i]);

            TilesGraphics.Clear(Palette[0]); // Background Color

            // Draw Tiles
            TilesAmount = TileGraphics.Length / 32;

            FastPixel fp = new FastPixel(Tiles);
            fp.rgbValues = new byte[Tiles.Width * Tiles.Height * 4];
            fp.Lock();
            for (int i = 0; i < TilesAmount; i++)
                GBAGraphics.DrawTile(fp, i, TileSize, 32, TileGraphics, Palette);

            fp.Unlock(true);

            ReadTiles.Close();
            ReadPalette.Close();

            return Tiles;
        }

        private void PaletteIndexCombo_SelectedIndexChanged(object sender, EventArgs e)
        {         
            if (!context.FourBitsPerPixelTiles) return;
            if (PaletteIndexCombo.SelectedIndex >= PaletteRows) return;

            var paletteBuffer = new Color[16];
            Array.Copy(Palette, PaletteIndexCombo.SelectedIndex * 16, paletteBuffer, 0, 16);

            var fp = new FastPixel(TilesImage);
            fp.rgbValues = new byte[TilesImage.Width * TilesImage.Height * 4];

            fp.Lock();
            for (int i = 0; i < TilesAmount; i++)
                GBAGraphics.DrawTile(fp, i, TileSize, 32, TileGraphics, paletteBuffer);

            fp.Unlock(true);
            picTiles.Invalidate();
        }

        private void GameDevModeMenuItem_Click(object sender, EventArgs e)
        {
            if (GameDevModeMenuItem.Checked)
            {
                Width = 662;
                cmdSaveTile.Enabled = false;
                mnuOpenTileset.Enabled = false;
                mnuSaveTileset.Enabled = false;
                GameDevModeMenuItem.Checked = false;
            }
            else
            {
                Width = 830;
                cmdSaveTile.Enabled = true;
                mnuOpenTileset.Enabled = true;
                mnuSaveTileset.Enabled = true;
                GameDevModeMenuItem.Checked = true;

                BlockAmount = 512;
                TilesetData = new TileData[BlockAmount];
                TilesetImage = new Bitmap(128, BlockAmount * 2);
                picTileset.Image = TilesetImage;
                TilesetGraphics = Graphics.FromImage(TilesetImage);

                TilesetGraphics.Clear(TilesImage.GetPixel(1, 1));
                DrawCurrentTileblock();
            }

            picTiles.Invalidate();
            picTileset.Invalidate();
        }

        private void chkHFlip_CheckedChanged(object sender, EventArgs e)
        {
            var dest = new Rectangle(0, 0, 48, 48);
            var src = new Rectangle(48, 0, -48, 48);

            currentTileSurface.DrawImage(currentTileSurface, src, dest);
            picCurrentTile.Invalidate();
        }

        private void chkVFlip_CheckedChanged(object sender, EventArgs e)
        {
            var dest = new Rectangle(0, 0, 48, 48);
            var src = new Rectangle(0, 48, 48, -48);

            currentTileSurface.DrawImage(currentTileSurface, src, dest);
            picCurrentTile.Invalidate();
        }

        private void mnuNewTilemap_Click(object sender, EventArgs e)
        {
            MapWidth = Convert.ToInt32(txtWidth.Text);
            MapHeight = Convert.ToInt32(txtHeight.Text);

            MapData = new ushort[MapWidth, MapHeight];
            MapImage = RenderTilemap();
            picMap.Image = MapImage;

            pnlMap.Visible = true;
            mnuSaveTilemap.Enabled = true;
            MapGraphics = Graphics.FromImage(MapImage);
        }

        private Bitmap RenderTilemap()
        {
            Bitmap Tilemap;
            if (!GameDevModeMenuItem.Checked)
                Tilemap = new Bitmap(MapWidth * TileSize, MapHeight * TileSize);
            else
                Tilemap = new Bitmap(MapWidth * TileblockSize, MapHeight * TileblockSize);

            FastPixel tp = null;
            FastPixel mp = new FastPixel(Tilemap);
            mp.rgbValues = new byte[Tilemap.Width * Tilemap.Height * 4];

            if (!GameDevModeMenuItem.Checked)
            {
                tp = new FastPixel(TilesImage);
                tp.rgbValues = new byte[TilesImage.Width * TilesImage.Height * 4];
            }
            else
            {
                tp = new FastPixel(TilesetImage);
                tp.rgbValues = new byte[TilesetImage.Width * TilesetImage.Height * 4];
            }

            mp.Lock();
            tp.Lock();

            int SrcX, SrcY, DestX, DestY;
            for (int y = 0; y < MapHeight; y++)
            {
                if (!GameDevModeMenuItem.Checked)
                    DestY = y * TileSize;
                else
                    DestY = y * TileblockSize;

                for (int x = 0; x < MapWidth; x++)
                {
                    int Tile = MapData[x, y];

                    if (!GameDevModeMenuItem.Checked)
                    {
                        Tile = Tile & 0x3FF;
                        SrcX = (Tile % TilesPerRow) * TileSize;
                        SrcY = (Tile / TilesPerRow) * TileSize;
                    }
                    else
                    {
                        SrcX = (Tile % 8) * TileblockSize;
                        SrcY = (Tile / 8) * TileblockSize;
                    }

                    if (!GameDevModeMenuItem.Checked)
                        DestX = x * TileSize;
                    else
                        DestX = x * TileblockSize;

                    if (!GameDevModeMenuItem.Checked)
                    {
                        for (int px = 0; px < TileSize; px++)
                            for (int py = 0; py < TileSize; py++)
                                mp.SetPixel(DestX + px, DestY + py, tp.GetPixel(SrcX + px, SrcY + py));
                    }
                    else
                    {
                        for (int px = 0; px < TileblockSize; px++)
                            for (int py = 0; py < TileblockSize; py++)
                                mp.SetPixel(DestX + px, DestY + py, tp.GetPixel(SrcX + px, SrcY + py));
                    }
                }
            }

            mp.Unlock(true);
            tp.Unlock(true);

            return Tilemap;
        }

        private void DrawTile(int x, int y, int TileNumber)
        {
            if (!GameDevModeMenuItem.Checked)
            {
                Rectangle SrcRect = new Rectangle((TileNumber % TilesPerRow) * TileSize, (TileNumber / TilesPerRow) * TileSize, TileSize, TileSize);
                Rectangle DestRect = new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize);

                MapGraphics.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);
            }
            else
            {
                Rectangle SrcRect = new Rectangle((TileNumber % TileblocksPerRow) * TileblockSize, (TileNumber / TileblocksPerRow) * TileblockSize, TileblockSize, TileblockSize);
                Rectangle DestRect = new Rectangle(x * TileblockSize, y * TileblockSize, TileblockSize, TileblockSize);

                MapGraphics.DrawImage(TilesetImage, DestRect, SrcRect, GraphicsUnit.Pixel);
            }
        }

        private void picMap_MouseHandle(object sender, MouseEventArgs e)
        {
            int x, y;
            if (!GameDevModeMenuItem.Checked)
            {
                x = e.X / TileSize;
                y = e.Y / TileSize;
            }
            else
            {
                x = e.X / TileblockSize;
                y = e.Y / TileblockSize;
            }

            if (e.X < 0 || e.X >= MapImage.Width || e.Y < 0 || e.Y >= MapImage.Height)
                return;

            lblLocation.Text = "X: 0x" + Convert.ToString(x, HEX).ToUpper() + " 0x" + Convert.ToString(y, HEX).ToUpper();
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            if (GameDevModeMenuItem.Checked)
            {
                MapData[x, y] = (ushort)CurrentTileblock;
                DrawTile(x, y, CurrentTileblock);

            }
            else
            {
                MapData[x, y] = (ushort)(context.CurrentTile | (PaletteIndexCombo.SelectedIndex << 12));
                DrawTile(x, y, context.CurrentTile);
            }
            picMap.Invalidate();
        }

        private void picTileset_Paint(object sender, PaintEventArgs e)
        {
            var cursor = new Pen(Color.Red, 2f);
            var x = (CurrentTileblock % TileblocksPerRow) * TileblockSize;
            var y = (CurrentTileblock / TileblocksPerRow) * TileblockSize;

            e.Graphics.DrawRectangle(cursor, x, y, TileblockSize, TileblockSize);
        }

        private void picTileset_MouseHandle(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= TilesetImage.Width || e.Y < 0 || e.Y >= TilesetImage.Height)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            CurrentTileblock = ((e.Y / TileblockSize) * TileblocksPerRow) + (e.X / TileblockSize);
            DrawTileTopBottom();
            DrawCurrentTileblock();

            lblCurrentTileblock.Text = "Current Tileblock: 0x" + Convert.ToString(CurrentTileblock, HEX).ToUpper();
            picTileset.Invalidate();
        }

        private void DrawCurrentTileblock()
        {
            var x = (CurrentTileblock % TileblocksPerRow) * TileblockSize;
            var y = (CurrentTileblock / TileblocksPerRow) * TileblockSize;

            var dest = new Rectangle(0, 0, 48, 48);
            var src = new Rectangle(x, y, TileblockSize, TileblockSize);

            var surface = new Surface(TilesetImage);
            currentTileblockSurface.DrawImage(surface, dest, src);

            
            picCurrentTileblock.Invalidate();
        }

        private void DrawTileTopBottom()
        {
            Rectangle DestRect = new Rectangle(0, 0, 48, 48);

            // Draw Bottom first
            Rectangle SrcRect = new Rectangle((TilesetData[CurrentTileblock].BottomTile % TilesPerRow) * TileblockSize, (TilesetData[CurrentTileblock].BottomTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
            BottomGraphics.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);

            // Draw Top
            SrcRect = new Rectangle((TilesetData[CurrentTileblock].TopTile % TilesPerRow) * TileblockSize, (TilesetData[CurrentTileblock].TopTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);

            var surface = new Surface(TilesImage);
            tileTopLayerSurface.DrawImage(surface, SrcRect, DestRect);

            picTop.Invalidate();
            picBottom.Invalidate();
        }

        private void picBottom_MouseHandle(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= BottomImage.Width || e.Y < 0 || e.Y >= BottomImage.Height)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            BottomTile = context.CurrentTile;
            Rectangle DestRect = new Rectangle(0, 0, 48, 48);
            Rectangle SrcRect = new Rectangle((context.CurrentTile % TilesPerRow) * TileblockSize, (context.CurrentTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
            BottomGraphics.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);

            picBottom.Invalidate();
        }

        private void picTop_MouseHandle(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.X >= tileTopLayerSurface.Width || e.Y < 0 || e.Y >= tileTopLayerSurface.Height)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            TopTile = context.CurrentTile;
            var dest = new Rectangle(0, 0, 48, 48);
            var src = new Rectangle((context.CurrentTile % TilesPerRow) * TileblockSize, (context.CurrentTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);

            var surface = new Surface(TilesImage);
            tileTopLayerSurface.DrawImage(surface, dest, src);

            picTop.Invalidate();
        }

        private void cmdSaveTile_Click(object sender, EventArgs e)
        {
            if (!GameDevModeMenuItem.Checked)
                return;

            TilesetData[CurrentTileblock].TopTile = (ushort)TopTile;
            TilesetData[CurrentTileblock].BottomTile = (ushort)BottomTile; 

            Bitmap TempTile = new Bitmap(16, 16);
            Graphics TempGraphics = Graphics.FromImage(TempTile);

            // Draw bottom tile first
            Rectangle SrcRect = new Rectangle((BottomTile % TilesPerRow) * TileblockSize, (BottomTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
            Rectangle DestRect = new Rectangle(0, 0, TileblockSize, TileblockSize);

            TempGraphics.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);

            // Draw top tile
            SrcRect = new Rectangle((TopTile % TilesPerRow) * TileblockSize, (TopTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
            DestRect = new Rectangle(0, 0, TileblockSize, TileblockSize);

            // Handle transparency
            Bitmap TransparentBuffer = new Bitmap(16, 16);
            Graphics tg = Graphics.FromImage(TransparentBuffer);
            tg.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);
            TransparentBuffer.MakeTransparent(TilesImage.GetPixel(1, 1)); // Makes the first color transparent :)

            TempGraphics.DrawImage(TransparentBuffer, DestRect, DestRect, GraphicsUnit.Pixel);

            SrcRect = new Rectangle(0, 0, TileblockSize, TileblockSize);
            DestRect = new Rectangle((CurrentTileblock % TileblocksPerRow) * TileblockSize, (CurrentTileblock / TileblocksPerRow) * TileblockSize, TileblockSize, TileblockSize);
            TilesetGraphics.DrawImage(TempTile, DestRect, SrcRect, GraphicsUnit.Pixel);

            picTileset.Invalidate();
        }

        private void mnuSaveTileset_Click(object sender, EventArgs e)
        {
            BinaryWriter TilesetFile;

            if (File.Exists(TilesetPath))
            {
                TilesetFile = new BinaryWriter(File.Open(TilesetPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite));

                TilesetFile.BaseStream.Position = 22;
                for (int i = 0; i < BlockAmount; i++)
                {
                    TilesetFile.Write(TilesetData[i].BottomTile);
                    TilesetFile.Write(TilesetData[i].TopTile);
                }
            }
            else
            {
                SaveFileDialog cdgSave = new SaveFileDialog();

                cdgSave.Title = "Save Tileset";
                cdgSave.Filter = "Typhoon Tilesets (*.tpn)|*.tpn";

                if (cdgSave.ShowDialog() != DialogResult.OK)
                    return;

                TilesetPath = cdgSave.FileName;
                TilesetFile = new BinaryWriter(File.Open(TilesetPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite));

                TilesetFile.BaseStream.Position = 0;
                TilesetFile.Write(BlockAmount);
                TilesetFile.BaseStream.Position = 2;
                TilesetFile.Write(Path.GetFileName(TilesPath));

                TilesetFile.BaseStream.Position = 22;
                for (int i = 0; i < BlockAmount; i++)
                {
                    TilesetFile.Write(TilesetData[i].BottomTile);
                    TilesetFile.Write(TilesetData[i].TopTile);
                }
            }


            TilesetFile.Close();
        }

        private void mnuOpenTileset_Click(object sender, EventArgs e)
        {
            OpenFileDialog cdgOpen = new OpenFileDialog();

            cdgOpen.Title = "Open Tileset...";
            cdgOpen.Filter = "Typhoon Tilesets (*.tpn)|*.tpn";

            if (cdgOpen.ShowDialog() != DialogResult.OK)
                return;

            TilesetPath = cdgOpen.FileName;
            BinaryReader ReadFile = new BinaryReader(File.Open(TilesetPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

            ReadFile.BaseStream.Position = 0;
            BlockAmount = ReadFile.ReadUInt16();

            StringBuilder sb = new StringBuilder();
            ReadFile.BaseStream.Position = 2;
            for (int i = 0; i < 20; i++)
            {
                char temp = ReadFile.ReadChar();

                if (temp == 0)
                    break;

                sb.Append(temp);
            }
            string imagefile = sb.ToString().Replace("\t", "");
            TilesPath = Path.GetDirectoryName(TilesetPath) + "\\" + imagefile;

            ReadFile.BaseStream.Position = 22;
            TilesetData = new TileData[BlockAmount];
            for (int i = 0; i < BlockAmount; i++)
            {
                TilesetData[i].BottomTile = ReadFile.ReadUInt16();
                TilesetData[i].TopTile = ReadFile.ReadUInt16();
            }

            ReadFile.Close();

            TilesImage = new Bitmap(Bitmap.FromFile(TilesPath));
            picTiles.Image = TilesImage;

            TilesetImage = RenderTileset();
            picTileset.Image = TilesetImage;
            TilesetGraphics = Graphics.FromImage(TilesetImage);
            picTileset.Invalidate();
        }

        private Bitmap RenderTileset()
        {
            Bitmap TempImage = new Bitmap(128, BlockAmount * 2);
            Graphics TempGraphics = Graphics.FromImage(TempImage);

            TempGraphics.Clear(TilesImage.GetPixel(1, 1));

            for (int i = 0; i < BlockAmount; i++)
            {
                Bitmap TempTile = new Bitmap(16, 16);
                Graphics TileGraphics = Graphics.FromImage(TempTile);

                // Draw bottom tile first
                Rectangle SrcRect = new Rectangle((TilesetData[i].BottomTile % TilesPerRow) * TileblockSize, (TilesetData[i].BottomTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
                Rectangle DestRect = new Rectangle(0, 0, TileblockSize, TileblockSize);

                TileGraphics.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);

                // Draw top tile
                SrcRect = new Rectangle((TilesetData[i].TopTile % TilesPerRow) * TileblockSize, (TilesetData[i].TopTile / TilesPerRow) * TileblockSize, TileblockSize, TileblockSize);
                DestRect = new Rectangle(0, 0, TileblockSize, TileblockSize);

                // Handle transparency
                Bitmap TransparentBuffer = new Bitmap(16, 16);
                Graphics tg = Graphics.FromImage(TransparentBuffer);
                tg.DrawImage(TilesImage, DestRect, SrcRect, GraphicsUnit.Pixel);
                TransparentBuffer.MakeTransparent(TilesImage.GetPixel(1, 1)); // Makes the first color transparent :)

                TileGraphics.DrawImage(TransparentBuffer, DestRect, DestRect, GraphicsUnit.Pixel);

                SrcRect = new Rectangle(0, 0, TileblockSize, TileblockSize);
                DestRect = new Rectangle((i % TileblocksPerRow) * TileblockSize, (i / TileblocksPerRow) * TileblockSize, TileblockSize, TileblockSize);
                TempGraphics.DrawImage(TempTile, DestRect, SrcRect, GraphicsUnit.Pixel);
            }

            return TempImage;
        }

        private void mnuSaveTilemap_Click(object sender, EventArgs e)
        {
            using (var cdgSave = new SaveFileDialog
            {
                Title = "Save Tilemap",
                Filter = "Binary Files (*.bin)|*.bin|RAW Files (*.raw)|*.raw|Tilemap Files (*.tmp)|*.tmp|Typhoon Maps (*.tpm)|*.tpm"
            })
            {
                if (cdgSave.ShowDialog() != DialogResult.OK) return;

                TilemapPath = cdgSave.FileName;
                using (var fs = File.Open(TilemapPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (var writer = new BinaryWriter(fs))
                    {
                        writer.BaseStream.Position = 0;

                        MapWidth = Convert.ToInt32(txtWidth.Text);
                        MapHeight = Convert.ToInt32(txtHeight.Text);
                        
                        if (!GameDevModeMenuItem.Checked)
                        {
                            for (int y = 0; y < MapHeight; y++)
                                for (int x = 0; x < MapWidth; x++)
                                    writer.Write(MapData[x, y]);
                        }
                        else
                        {
                            writer.Write(MapWidth);
                            writer.Write(MapHeight);
                            writer.Write(Path.GetFileName(TilesetPath));
                            writer.BaseStream.Position = 0x1D;
                            for (int y = 0; y < MapHeight; y++)
                                for (int x = 0; x < MapWidth; x++)
                                    writer.Write(MapData[x, y]);
                        }
                    }
                }
            }
        }

    } // End of class

    public struct TileData
    {
        public ushort BottomTile;
        public ushort TopTile;
    }

}