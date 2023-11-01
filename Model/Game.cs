using Console1;
using Console1.Controller;
using Console1.Model;

namespace Tetris.Model
{
    internal class Game
    {
        public int[,] Land { get; set; } = new int[GameProperty.Length, GameProperty.Width];
        public IBlock Block { get; set; }

        public Game()
        {
            Block = BlockController.GenerateBlock();
        }

        public void ResetBlock()
        {
            Block = BlockController.GenerateBlock();
        }

        public List<int> LineComplete()
        {
            int lineNumber = 0;
            int[,] LandCopy = (int[,])Land.Clone();
            List<int> lines = new List<int>();

            for (int x = 0; x < GameProperty.Length; x++)
            {
                int sum = 0;
                for (int y = 0; y < GameProperty.Width; y++)
                {
                    sum += LandCopy[x, y] >= 1 ? 1 : 0;
                }
                if (sum == GameProperty.Width)
                {
                    lineNumber++;
                    lines.Add(x);
                }
            }
            return lines;
        }

        public void ShiftRowsDownAndAddZeroRow(List<int> indexsLinesComplete)
        {
            foreach (var indexLineComplete in indexsLinesComplete)
            {
                if (indexLineComplete >= 2)
                {
                    Console.Write(indexLineComplete);
                }
                int[,] newArray = new int[GameProperty.Length, GameProperty.Width];

                for (int i = 0; i < GameProperty.Length; i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < GameProperty.Width; j++)
                        {
                            newArray[i, j] = 0;
                        }
                    }
                    else if (i <= indexLineComplete)
                    {
                        for (int j = 0; j < GameProperty.Width; j++)
                        {
                            newArray[i, j] = Land[i - 1, j];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < GameProperty.Width; j++)
                        {
                            newArray[i, j] = Land[i, j];
                        }
                    }
                }
                Land = newArray;
            }
        }

        public void ResetGame()
        {
            Land = new int[GameProperty.Length, GameProperty.Width];
        }
    }
}