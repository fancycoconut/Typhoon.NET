namespace Typhoon.NET
{
    public class EditorContext
    {
        public bool GameDevelopmentMode { get; set; }
        public bool FourBitsPerPixelTiles { get; set; }

        public int CurrentTile { get; set; }
        public int CurrentTileblock { get; set; }
    }
}
