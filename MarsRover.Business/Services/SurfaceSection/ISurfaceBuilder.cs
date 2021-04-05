using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.SurfaceSection
{
    public interface ISurfaceBuilder
    {
        Surface Build(string arguments);
    }
}