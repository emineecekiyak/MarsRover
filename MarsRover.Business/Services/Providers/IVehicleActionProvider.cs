using System.Collections.Generic;
using MarsRover.Contract.Enums.Actions;

namespace MarsRover.Business.Services.Providers
{
    public interface IVehicleActionProvider
    {
        IEnumerable<VehicleActions> Provide(string arg);
    }
}