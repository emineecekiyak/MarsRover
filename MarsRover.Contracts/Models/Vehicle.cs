using System;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Enums.Directions;
using MarsRover.Contract.Interfaces;

namespace MarsRover.Contract.Models
{
    public class Vehicle : IMovable
    {
        public Point CurrentPoint { get; protected set; }
        public CompassDirections Direction { get; protected set; }
        
        protected Vehicle(int x, int y, CompassDirections direction)
        {
            if (!Enum.IsDefined(typeof(CompassDirections), direction))
            {
                throw new NotValidException($"Direction is not valid {direction.ToString()}", null);
            }

            CurrentPoint = new Point(x, y);
            Direction = direction;
        }

        public void Forward()
        {
            CurrentPoint = Direction switch
            {
                CompassDirections.E => new Point(CurrentPoint.X + 1, CurrentPoint.Y),
                CompassDirections.N => new Point(CurrentPoint.X, CurrentPoint.Y + 1),
                CompassDirections.W => new Point(CurrentPoint.X - 1, CurrentPoint.Y),
                CompassDirections.S => new Point(CurrentPoint.X, CurrentPoint.Y - 1),
                _ => throw new NotValidException($"{nameof(Direction)} is not valid [{Direction}]", null)
            };
        }
        
        public void Turn(RelativeDirections relativeDirection)
        {
            if (!Enum.IsDefined(typeof(RelativeDirections), relativeDirection))
            {
                throw new NotValidException($"Direction is not valid ({relativeDirection.ToString()})", null);
            }

            var compassDirection = relativeDirection switch
            {
                RelativeDirections.Left => (CompassDirections) (((int) Direction + 90) % 360),
                RelativeDirections.Right => (CompassDirections) (((int) Direction + 270) % 360),
                _ => throw new Exception($"Direction is not implemented ({relativeDirection.ToString()})")
            };

            Direction = compassDirection;
        }
        
        public override string ToString()
        {
            return $"{CurrentPoint} {Direction.ToString()}";
        }
    }
}