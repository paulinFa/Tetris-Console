namespace Tetris.Model
{
    internal abstract class Block
    {
        protected (int x, int y)[] coords;

        public void DownBlock()
        {
            for (int i = 0; i < coords.Length; i++)
            {
                coords[i] = (coords[i].x + 1, coords[i].y);
            }
        }

        public (int x, int y)[] getCoords()
        {
            return (coords);
        }
    }
}