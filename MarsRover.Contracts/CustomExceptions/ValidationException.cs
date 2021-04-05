using System;

namespace MarsRover.Contract.CustomExceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}