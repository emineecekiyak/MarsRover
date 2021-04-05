using MarsRover.Contract.Enums;

namespace MarsRover.Business.Services.InputSection
{
    public interface IInputProviderFactory
    {
        IInputProvider Generate(InputProviderTypes inputProviderType);
    }
}