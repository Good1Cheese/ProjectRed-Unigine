using Leopotam.EcsLite;
using Unigine;

namespace ProjectRed.Mechanics.Rotate;

public class RotateInputSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Rotation> _movementPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Rotation>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Rotation>().End();

        foreach (int entity in filter)
        {
            ref var rotation = ref _movementPool.Get(entity);

            rotation.Input = Input.MouseDeltaPosition;
        }
    }
}
