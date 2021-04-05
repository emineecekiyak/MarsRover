using MarsRover.Contract.Enums.Directions;

namespace MarsRover.Contract.Models
{
    public class Rover : Vehicle
    {
        public Rover(int x, int y, CompassDirections direction) : base(x, y, direction)
        {
        }
        
        public Rover() : this(0, 0, CompassDirections.N) //initial location
        {
        }
    }
}