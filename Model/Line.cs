using Tetris.Model;

namespace Console1.Model
{
    internal class Line : Block, IBlock
    {
        public Line()
        {
            Random rnd = new Random();
            int value = rnd.Next(GameProperty.Width - 3);
            coords = new (int, int)[] { (0, value), (0, value + 1), (0, value + 2), (0, value + 3) };
        }
    }
}