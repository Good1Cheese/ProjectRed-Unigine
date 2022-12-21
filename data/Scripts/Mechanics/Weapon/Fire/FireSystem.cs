using Leopotam.EcsLite;
using ProjectRed;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Weapon.Fire;
using ProjectRed.Mechanics.Weapon;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;
using static Unigine.Image;
using Unigine.Plugins.IG;

namespace ProjectRed.Mechanics.Weapon.Fire;

public class FireSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON FireKey = Input.MOUSE_BUTTON.LEFT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<DelayMarker> _delayMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _gameObjectPool = world.GetPool<GameObject>();
        _delayMarkerPool = world.GetPool<DelayMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        if (!Input.IsMouseButtonPressed(FireKey)) return;

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<GameObject>().Inc<PickupMarker>().Exc<DelayMarker>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var weapon = ref _weaponPool.Get(entity);

            Node bullet = SpawnBullet(gameObject);

            ref var delayMarker = ref _delayMarkerPool.Add(entity);
            delayMarker.Milliseconds = weapon.DelayAfterShotInMilliseconds;

            Node spawnEffect = World.LoadNode(weapon.BulletSpawnEffect);
            spawnEffect.SetWorldParent(weapon.Node);
        }
    }

    private static Node SpawnBullet(in GameObject gameObject)
    {
        vec3 spawn = gameObject.BulletsSpawnPoint.WorldPosition;
        Node result = gameObject.BulletNodeLink.Load(spawn);

        vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);
        result.SetWorldDirection(forward, vec3.UP);

        return result;
    }
}
