using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Move;

public class MoveSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Movement> _movementPool;
    private EcsPool<PlayerGameObject> _playerGameObjectPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Movement>();
        _playerGameObjectPool = world.GetPool<PlayerGameObject>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<PlayerGameObject>().Inc<Movement>().End();

        foreach (int entity in filter)
        {
            ref var movement = ref _movementPool.Get(entity);
            ref var gameObject = ref _playerGameObjectPool.Get(entity);

            var move = movement.Input * movement.Speed * Game.IFps;

            gameObject.Body.Translate((vec3)move);
        }
    }
}
