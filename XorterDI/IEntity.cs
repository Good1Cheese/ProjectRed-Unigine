using XorterDI;

namespace Leopotam.EcsLite;

public interface IEntity
{
    [Inject]
    void Create(EcsWorld world);
}
