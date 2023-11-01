using Tetris.Model;

namespace Console1.Model
{
    internal class Z : Block, IBlock
    {
        public Z()
        {
            Random rnd = new Random();
            int value = rnd.Next(GameProperty.Width - 3);
            coords = new (int, int)[] { (0, value), (0, value + 1), (1, value + 1), (1, value + 2) };
        }
    }
}