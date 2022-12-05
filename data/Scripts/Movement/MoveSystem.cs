using Leopotam.EcsLite;
using Unigine;

public class MoveSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Movement> _movementPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Movement>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Movement>().End();

        foreach (int entity in filter)
        {
            ref var movement = ref _movementPool.Get(entity);

            var move = movement.Input * movement.Speed * Game.IFps;

            movement.Node.Translate((vec3)move);
        }
    }
}
