using MarsRover.Contract.Enums;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.VehicleSection
{
    public interface IVehicleFactory
    {
        Vehicle Generate(VehicleTypes vehicleType, string argument);
    }
}