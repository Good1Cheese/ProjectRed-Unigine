using Leopotam.EcsLite;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Weapon.Pickup;
using ProjectRed.Extensions;
using Unigine;

namespace ProjectRed.Mechanics.Weapon.Fire;

public class FireSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON FireKey = Input.MOUSE_BUTTON.LEFT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<PlayerGameObject> _playerGameObjectPool;
    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<DelayMarker> _delayMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _playerGameObjectPool = world.GetPool<PlayerGameObject>();
        _gameObjectPool = world.GetPool<GameObject>();
        _delayMarkerPool = world.GetPool<DelayMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        if (!Input.IsMouseButtonPressed(FireKey)) return;

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PlayerGameObject>().Inc<PickupMarker>().Exc<DelayMarker>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _playerGameObjectPool.Get(entity);
            ref var weapon = ref _weaponPool.Get(entity);

            Node bullet = SpawnBullet(gameObject);
            CreateBulletEntity(world, bullet);

            Node spawnEffect = World.LoadNode(gameObject.BulletSpawnEffect);
            spawnEffect.SetWorldParent(weapon.Node);

            ref var delayMarker = ref _delayMarkerPool.Add(entity);
            delayMarker.Milliseconds = weapon.DelayAfterShotInMilliseconds;
        }
    }

    private Node SpawnBullet(in PlayerGameObject gameObject)
    {
        Node result = World.LoadNode(gameObject.Bullet);

        result.WorldPosition = gameObject.BulletsSpawnPoint.WorldPosition;
        result.SetWorldDirection(gameObject.Head.GetWorldDirection(MathLib.AXIS.Y), vec3.FORWARD);

        return result;
    }

    private void CreateBulletEntity(EcsWorld world, Node bullet)
    {
        int entity = world.NewEntity();

        GameObject gameObject = new() { Node = bullet };

        _gameObjectPool.Add(entity, gameObject);
    }
}
