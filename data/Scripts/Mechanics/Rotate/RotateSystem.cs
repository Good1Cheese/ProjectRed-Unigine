using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Rotate;

public class RotateSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Rotation> _movementPool;
    private EcsPool<PlayerGameObject> _playerGameObjectPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Rotation>();
        _playerGameObjectPool = world.GetPool<PlayerGameObject>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<PlayerGameObject>().Inc<Rotation>().End();

        foreach (int entity in filter)
        {
            ref var rotation = ref _movementPool.Get(entity);
            ref var gameObject = ref _playerGameObjectPool.Get(entity);

            var move = -rotation.Input * rotation.Speed * Game.IFps;

            gameObject.Body.Rotate(0, 0, move.x);
            gameObject.Head.Rotate(move.y, 0, 0);
        }
    }
}
