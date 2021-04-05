using System;
using MarsRover.Common;
using MarsRover.Contract.Enums.Directions;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.VehicleSection.Imp
{
    public class RoverBuilder : IRoverBuilder
    {
        public Vehicle Build(string arg)
        {
            if (arg == null) 
                throw new Exception(StringResources.RoverArgumentShouldNotBeEmpty);

            string[] parameters = arg.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 3) 
                throw new Exception(StringResources.IncorrectArgumentCountForRover);

            string xStr = parameters[0];
            string yStr = parameters[1];
            string directionStr = parameters[2]?.ToUpperInvariant();

            if (!int.TryParse(xStr, out int x))
            {
                throw new Exception($"First parameter format not valid [{arg}]");
            }
            
            if (!int.TryParse(yStr, out int y))
            {
                throw new Exception($"Second parameter format not valid [{arg}]");
            }

            if (!Enum.IsDefined(typeof(CompassDirections), directionStr))
            {
                throw new Exception($"Third parameter format not valid [{arg}]");
            }

            var direction = (CompassDirections) Enum.Parse(typeof(CompassDirections), directionStr);

            Vehicle vehicle = new Rover(x, y, direction);
            return vehicle;
        }
    }
}