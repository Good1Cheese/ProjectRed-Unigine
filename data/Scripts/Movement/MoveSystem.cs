using Leopotam.EcsLite;
using Unigine;

public class MoveSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Movement> _movementPool;
    private EcsPool<GameObject> _gameObjectPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Movement>();
        _gameObjectPool = world.GetPool<GameObject>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<GameObject>().Inc<Movement>().End();

        foreach (int entity in filter)
        {
            ref var movement = ref _movementPool.Get(entity);
            ref var gameObject = ref _gameObjectPool.Get(entity);

            var move = movement.Input * movement.Speed * Game.IFps;

            gameObject.Node.Translate((vec3)move);
        }
    }
}
