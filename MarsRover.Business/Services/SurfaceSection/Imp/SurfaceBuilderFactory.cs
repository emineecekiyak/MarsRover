using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.SurfaceSection.Imp
{
    public class SurfaceBuilderFactory : ISurfaceBuilderFactory
    {
        private readonly IEnumerable<ISurfaceBuilder> _surfaceBuilders;

        public SurfaceBuilderFactory(IEnumerable<ISurfaceBuilder> surfaceBuilders)
        {
            _surfaceBuilders = surfaceBuilders ?? throw new Exception($"{nameof(surfaceBuilders)} should not be null");
        }

        public ISurfaceBuilder Generate(Type surfaceTypes)
        {
            ISurfaceBuilder surfaceBuilder = null;
            if (surfaceTypes == typeof(Plateau))
            {
                surfaceBuilder = _surfaceBuilders.FirstOrDefault(builder => builder is IPlateauBuilder);
            }

            if (surfaceBuilder == null)
            {
                throw new Exception($"There is not defined surface builder for [{surfaceTypes}]");
            }

            return surfaceBuilder;
        }
    }
}