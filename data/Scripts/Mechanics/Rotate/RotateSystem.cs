using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Rotate;

public class RotateSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Rotation> _movementPool;
    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<Object.Player> _playerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Rotation>();
        _gameObjectPool = world.GetPool<GameObject>();
        _playerPool = world.GetPool<Object.Player>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<GameObject>().Inc<Object.Player>().Inc<Rotation>().End();

        foreach (int entity in filter)
        {
            ref var rotation = ref _movementPool.Get(entity);
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var player = ref _playerPool.Get(entity);

            var rotate = -rotation.Input * rotation.Speed * Game.IFps;

            gameObject.Node.Rotate(0, 0, rotate.x);
            player.Head.Rotate(rotate.y, 0, 0);
        }
    }
}
