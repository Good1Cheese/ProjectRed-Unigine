using Leopotam.EcsLite;
using ProjectRed.Mechanics.Pickup;

public class WeaponArmSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Weapon> _weaponPool;
    private EcsPool<PickupMarker> _pickupMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _pickupMarkerPool = world.GetPool<PickupMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PickupMarker>().Inc<OneFramePickupMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);
            ref var pickupMarker = ref _pickupMarkerPool.Get(entity);

            weapon.Node.SetWorldParent(pickupMarker.Slot);
        }
    }
}