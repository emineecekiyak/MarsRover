using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.VehicleSection
{
    public interface IVehicleBuilder
    {
        Vehicle Build(string argument);
    }
}