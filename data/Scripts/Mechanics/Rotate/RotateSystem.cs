using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Rotate;

public class RotateSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Rotation> _movementPool;
    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<PlayerGameObject> _playerGameObjectPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Rotation>();
        _gameObjectPool = world.GetPool<GameObject>();
        _playerGameObjectPool = world.GetPool<PlayerGameObject>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<GameObject>().Inc<PlayerGameObject>().Inc<Rotation>().End();

        foreach (int entity in filter)
        {
            ref var rotation = ref _movementPool.Get(entity);
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var player = ref _playerGameObjectPool.Get(entity);

            var rotate = -rotation.Input * rotation.Speed * Game.IFps;

            gameObject.Node.Rotate(0, 0, rotate.x);
            player.Head.Rotate(rotate.y, 0, 0);
        }
    }
}
