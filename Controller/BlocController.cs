using Console1.Model;

namespace Console1.Controller
{
    public static class BlockController
    {
        public static IBlock GenerateBlock()
        {
            Random rnd = new Random();
            int value = rnd.Next(5);
            switch (value)
            {
                case 0:
                    return (IBlock)new Line();

                case 1:
                    return (IBlock)new Triangle();

                case 2:
                    return (IBlock)new Z();

                case 3:
                    return (IBlock)new Square();

                default:
                    break;
            }
            return (IBlock)new Line();
        }
    }
}