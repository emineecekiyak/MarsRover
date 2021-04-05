using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Contract.CustomExceptions;
using MarsRover.Contract.Enums;

namespace MarsRover.Business.Services.InputSection.Imp
{
    public class InputProviderFactory : IInputProviderFactory
    {
        private readonly IEnumerable<IInputProvider> _inputProviders;

        public InputProviderFactory(IEnumerable<IInputProvider> inputProviders)
        {
            _inputProviders = inputProviders ?? 
                              throw new Exception($"{nameof(inputProviders)} should not be null");
        }

        public IInputProvider Generate(InputProviderTypes inputProviderType)
        {
            if (!Enum.IsDefined(typeof(InputProviderTypes), inputProviderType))
            {
                throw new NotValidException($"Input provider type is not valid ({inputProviderType.ToString()})", null);
            }

            var inputProvider = inputProviderType switch
            {
                InputProviderTypes.Console => _inputProviders.FirstOrDefault(p => p is IConsoleInputProvider),
                _ => throw new Exception($"Input provider type not found [{inputProviderType.ToString()}]")
            };

            if (inputProvider == null)
            {
                throw new Exception($"No predefined {nameof(IInputProvider)} for {inputProviderType}");
            }

            return inputProvider;
        }
    }
}