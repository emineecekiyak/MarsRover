using MarsRover.Contract.Interfaces;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.VehicleSection
{
    public interface IVehicleContextFactory
    {
        IVehicleContext Generate(Surface surface, Vehicle vehicle);
    }
}