using Tetris.Model;

namespace Console1.Model
{
    internal class Square : Block, IBlock
    {
        public Square()
        {
            Random rnd = new Random();
            int value = rnd.Next(GameProperty.Width - 2);
            coords = new (int, int)[] { (0, value), (1, value), (0, value + 1), (1, value + 1) };
        }
    }
}