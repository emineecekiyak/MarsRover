using System;
using MarsRover.Common;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.SurfaceSection.Imp
{
    public class PlateauBuilder : IPlateauBuilder
    {
        public Surface Build(string argument)
        {
            if (argument == null) 
                throw new NotValidException(StringResources.PlateauArgumentShouldNotBeEmpty, null);

            var parameters = argument.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 2) throw new NotValidException($"Incorrect parameter count. Parameter count: {parameters.Length} - {nameof(argument)}:{argument}", null);

            if (!int.TryParse(parameters[0], out var x))
            {
                throw new NotValidException($"Parameter are in an invalid format for modelling Plateau [{argument}]", null);
            }

            if (!int.TryParse(parameters[1], out var y))
            {
                throw new NotValidException($"Parameters are in an invalid format for modelling Plateau [{argument}]", null);
            }

            Contract.Models.Surface surface = new Plateau(x, y);
            return surface;
        }
    }
}