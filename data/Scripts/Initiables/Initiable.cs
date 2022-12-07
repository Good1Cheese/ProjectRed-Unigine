using Leopotam.EcsLite;

namespace ProjectRed.Initiables;

public interface Initiable
{
    void Initialize(EcsWorld world, EcsSystems systems);
}
