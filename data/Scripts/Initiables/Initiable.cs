using Leopotam.EcsLite;

namespace ProjectRed.Initiables;

public interface IInitiable
{
    void Initialize(EcsWorld world, EcsSystems systems);
}
