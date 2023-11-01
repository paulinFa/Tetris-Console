using Console1;
using Tetris.Model;

namespace Tetris.Controller
{
    internal class GameController
    {
        private Game? ActiveGame;

        public void Init()
        {
            ActiveGame = new Game();
        }

        public void Start()
        {
            bool stop = false;
            bool reset = false;
            while (!stop)
            {
                Console.Clear();
                Draw();
                int[,] copiedArray = (int[,])ActiveGame.Land.Clone();
                if (reset)
                {
                    reset = false;
                    ActiveGame.ResetBlock();
                }
                else if (CanDown())
                {
                    ActiveGame.Block.DownBlock();
                }
                else
                {
                    FixBlock();
                    List<int> lineComplete = ActiveGame.LineComplete();
                    reset = true;
                    if (lineComplete.Contains(0))
                    {
                        ActiveGame.ResetGame();
                    }
                    if (lineComplete.Count > 0)
                    {
                        Console.Clear();
                        Draw();
                        Console.WriteLine("Bravo vous avez complété {0} lignes", lineComplete);
                        System.Threading.Thread.Sleep(100);
                        ActiveGame.ShiftRowsDownAndAddZeroRow(lineComplete);
                        ActiveGame.Block = null;
                    }
                }
                System.Threading.Thread.Sleep(20);
            }
        }

        public void Draw()
        {
            int[,] DrawLand = (int[,])ActiveGame.Land.Clone();
            if (ActiveGame.Block != null)
            {
                for (int i = 0; i < ActiveGame.Block.getCoords().Length; i++)
                {
                    DrawLand[ActiveGame.Block.getCoords()[i].x, ActiveGame.Block.getCoords()[i].y] = 2;
                }
            }
            for (int i = 0; i < GameProperty.Length; i++)
            {
                for (int j = 0; j < GameProperty.Width; j++)
                {
                    if ((DrawLand[i, j]) == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("%");
                    }
                    else if ((DrawLand[i, j]) >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("%");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool CanDown()
        {
            for (int i = 0; i < ActiveGame.Block.getCoords().Length; i++)
            {
                if (ActiveGame.Block.getCoords()[i].x + 1 == GameProperty.Length)
                {
                    return false;
                }
                if (ActiveGame.Land[ActiveGame.Block.getCoords()[i].x + 1, ActiveGame.Block.getCoords()[i].y] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void FixBlock()
        {
            for (int i = 0; i < ActiveGame.Block.getCoords().Length; i++)
            {
                ActiveGame.Land[ActiveGame.Block.getCoords()[i].x, ActiveGame.Block.getCoords()[i].y] = 1;
            }
        }
    }
}