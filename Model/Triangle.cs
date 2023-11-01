using Tetris.Model;

namespace Console1.Model
{
    internal class Triangle : Block, IBlock
    {
        public Triangle()
        {
            Random rnd = new Random();
            int value = rnd.Next(GameProperty.Width - 2);
            coords = new (int, int)[] { (1, value), (0, value + 1), (1, value + 1), (1, value + 2) };
        }
    }
}