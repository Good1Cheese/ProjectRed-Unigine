using Leopotam.EcsLite;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

public class ArmSystem : IEcsInitSystem, IEcsRunSystem
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

            weapon.Node.SetWorldParent(pickupMarker.WeaponParent);
            weapon.Node.Position = vec3.ZERO;
            weapon.Node.SetRotation(quat.IDENTITY);
        }
    }
}
