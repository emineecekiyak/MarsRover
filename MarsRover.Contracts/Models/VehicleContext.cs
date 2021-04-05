using System;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Enums.Actions;
using MarsRover.Contract.Enums.Directions;
using MarsRover.Contract.Interfaces;

namespace MarsRover.Contract.Models
{
    public abstract class VehicleContext : IVehicleContext
    {
        private Surface Surface { get; }
        public Vehicle Vehicle { get; }
        
        protected VehicleContext(Vehicle vehicle, Surface surface)
        {
            Vehicle = vehicle;
            Surface = surface;

            CheckPosition();
        }

        private void CheckPosition()
        {
            var isValidPosition = Surface.Contains(Vehicle.CurrentPoint);
            if (!isValidPosition) 
                throw new NotValidException($"The vehicle is not on the surface", null);
        }
        
        public void Move(VehicleActions action)
        {
            if (!Enum.IsDefined(typeof(VehicleActions), action))
            {
                throw new NotValidException($"Vehicle action is not valid ({action.ToString()})", null);
            }

            switch (action)
            {
                case VehicleActions.L:
                    Vehicle.Turn(RelativeDirections.Left);
                    break;
                case VehicleActions.R:
                    Vehicle.Turn(RelativeDirections.Right);
                    break;
                case VehicleActions.M:
                    Vehicle.Forward();
                    CheckPosition();
                    break;
                default:
                    throw new Exception($"Vehicle action is not implemented [{action.ToString()}]");
            }
        }
    }
}