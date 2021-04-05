using System;
using System.Collections.Generic;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Enums.Actions;

namespace MarsRover.Business.Services.Providers.Imp
{
    public class VehicleActionProvider : IVehicleActionProvider
    {
        public IEnumerable<VehicleActions> Provide(string argument)
        {
            argument ??= string.Empty;
            var vehicleActions = new List<VehicleActions>();
            foreach (var c in argument)
            {
                if (Enum.TryParse(c.ToString().ToUpperInvariant(), out VehicleActions action))
                {
                    vehicleActions.Add(action);
                }
                else
                {
                    throw new NotValidException($"Action is not valid ({argument})", null);
                }
            }

            return vehicleActions;
        }
    }
}