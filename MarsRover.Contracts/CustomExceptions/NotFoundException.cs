using System;

namespace MarsRover.Contract.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}