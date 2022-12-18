using Leopotam.EcsLite;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

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

            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);
            vec3 spawn = gameObject.BulletsSpawnPoint.WorldPosition;

            Node bullet = gameObject.BulletNodeLink.Load(spawn);
            bullet.SetWorldDirection(forward, vec3.UP);

            ref var delayMarker = ref _delayMarkerPool.Add(entity);
            delayMarker.Milliseconds = weapon.DelayAfterShotInMilliseconds;

            Node spawnEffect = World.LoadNode(weapon.BulletSpawnEffect);
            spawnEffect.SetWorldParent(bullet);
        }
    }
}
