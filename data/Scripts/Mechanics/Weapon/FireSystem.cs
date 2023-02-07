using Leopotam.EcsLite;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Weapon.Pickup;
using ProjectRed.Extensions;
using Unigine;
using ProjectRed.Mechanics.Move;
using ProjectRed.Entities;

namespace ProjectRed.Mechanics.Weapon;

public class FireSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON FireKey = Input.MOUSE_BUTTON.LEFT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<PlayerGameObject> _playerGameObjectPool;
    private EcsPool<DelayMarker> _delayMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _playerGameObjectPool = world.GetPool<PlayerGameObject>();
        _delayMarkerPool = world.GetPool<DelayMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        if (!Input.IsMouseButtonPressed(FireKey)) return;

        EcsFilter filter = world.Filter<Weapon>().Inc<PickupMarker>().Exc<DelayMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);
            ref var gameObject = ref _playerGameObjectPool.Get(weapon.Owner);

            var bullet = new BulletEntity(world);
            bullet.Spawn(gameObject);

            ref var delayMarker = ref _delayMarkerPool.Add(entity);
            delayMarker.Milliseconds = weapon.DelayAfterShotInMilliseconds;
        }
    }
}
