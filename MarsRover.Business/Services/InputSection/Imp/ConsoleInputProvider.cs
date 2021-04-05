using System;
using System.Linq;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.InputSection.Imp
{
    public class ConsoleInputProvider : IConsoleInputProvider
    {
        public Input Provide(string arg)
        {
            arg ??= string.Empty;
            var lines = arg.Split(new[] {"\\n", "|"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Trim())
                    .Where(line => !string.IsNullOrEmpty(line))
                    .ToArray()
                ;
            if (lines == null || lines.Length == 0)
            {
                throw new NotValidException("Input should not be null or empty", null);
            }

            if (lines.Length < 3)
            {
                throw new NotValidException("At least 3 lines should be supplied", null);
            }

            if (lines.Length % 2 != 1)
            {
                throw new NotValidException("Each vehicle should has at least one action command", null);
            }

            var input = new Input
            {
                SurfaceParameter = lines[0]?.Trim()
            };

            for (var i = 1; i < lines.Length; i += 2)
            {
                var vehicleAndCommands = new Tuple<string, string>(lines[i]?.Trim(), lines[i + 1]?.Trim());
                input.VehicleAndCommandParameterCollection.Add(vehicleAndCommands);
            }

            return input;
        }
    }
}