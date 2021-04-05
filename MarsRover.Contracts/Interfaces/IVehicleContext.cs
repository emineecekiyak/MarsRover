using MarsRover.Contract.Enums.Actions;
using MarsRover.Contract.Models;

namespace MarsRover.Contract.Interfaces
{
    public interface IVehicleContext
    {
        Vehicle Vehicle { get; }
        void Move(VehicleActions action);
    }
}