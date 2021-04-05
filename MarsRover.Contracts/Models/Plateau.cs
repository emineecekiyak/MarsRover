using MarsRover.Contract.CustomExceptions;

namespace MarsRover.Contract.Models
{
    public class Plateau : Surface
    {
        private const int XMin = default;
        private const int YMin = default;
        
        public int X { get; }
        public int Y { get; }
        
        public Plateau(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new NotValidException($"Plateau x - y size not valid ({x},{y})", null);
            }

            X = x;
            Y = y;
        }
        
        public override bool Contains(Point point)
        {
            var isValid = point.X >= XMin && 
                          point.X <= X && 
                          point.Y >= YMin && 
                          point.Y <= Y;

            return isValid;
        }
    }
}