namespace BoardGameLibrary.Models
{
    public class Square
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool isLandmine { get; set; }
        public bool isOccupied { get; set; }

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}