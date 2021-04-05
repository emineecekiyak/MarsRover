using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.InputSection
{
    public interface IInputProvider
    {
        Input Provide(string arg);
    }
}