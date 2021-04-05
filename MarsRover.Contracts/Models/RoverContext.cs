using MarsRover.Contract.Interfaces;

namespace MarsRover.Contract.Models
{
    public class RoverContext : VehicleContext, IRoverContext
    {
        public RoverContext(Vehicle vehicle, Surface surface) : base(vehicle, surface)
        {
        }
    }
}