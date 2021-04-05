using System;

namespace MarsRover.Business.Services.SurfaceSection
{
    public interface ISurfaceBuilderFactory
    {
        ISurfaceBuilder Generate(Type surfaceType);
    }
}