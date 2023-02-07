using Leopotam.EcsLite;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Fireable.Pickup;
using ProjectRed.Extensions;
using Unigine;
using ProjectRed.Mechanics.Move;
using ProjectRed.Entities;

namespace ProjectRed.Mechanics.Fireable;

public class FireSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON FireKey = Input.MOUSE_BUTTON.LEFT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<Bullet> _bulletPool;
    private EcsPool<Object.Player> _playerPool;
    private EcsPool<DelayMarker> _delayMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _bulletPool = world.GetPool<Bullet>();
        _playerPool = world.GetPool<Object.Player>();
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
            ref var player = ref _playerPool.Get(weapon.Owner);
            ref var bullet = ref _bulletPool.Get(weapon.Owner);

            var bulletEntity = new BulletEntity(world);
            bulletEntity.Spawn(player, bullet);

            ref var delayMarker = ref _delayMarkerPool.Add(entity);
            delayMarker.Milliseconds = weapon.DelayAfterShotInMilliseconds;
        }
    }
}
