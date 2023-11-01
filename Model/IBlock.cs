namespace Console1.Model
{
    public interface IBlock
    {
        public void DownBlock();

        public (int x, int y)[] getCoords();
    }
}