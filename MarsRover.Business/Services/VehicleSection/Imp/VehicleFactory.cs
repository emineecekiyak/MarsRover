using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Enums;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.VehicleSection.Imp
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IEnumerable<IVehicleBuilder> _vehicleBuilderCollection;

        public VehicleFactory(IEnumerable<IVehicleBuilder> vehicleBuilderCollection)
        {
            _vehicleBuilderCollection = vehicleBuilderCollection ?? throw new Exception($"{nameof(vehicleBuilderCollection)} should not be null");
        }

        public Vehicle Generate(VehicleTypes vehicleType, string arg)
        {
            var vehicleBuilder = vehicleType switch
            {
                VehicleTypes.Rover => _vehicleBuilderCollection.FirstOrDefault(v => v is IRoverBuilder),
                _ => throw new NotValidException($"Vehicle type is not valid ({vehicleType.ToString()})", null)
            };

            if (vehicleBuilder == null)
            {
                throw new Exception($"{nameof(vehicleBuilder)} should not be null");
            }

            Vehicle vehicle = vehicleBuilder.Build(arg);
            return vehicle;
        }
    }
}