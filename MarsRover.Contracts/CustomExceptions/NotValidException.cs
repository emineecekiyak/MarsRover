using System;

namespace MarsRover.Contract.CustomExceptions
{
    public class NotValidException : Exception
    {
        public NotValidException(string message, Exception innerEx) : base(message, innerEx)
        {
        }
    }
}