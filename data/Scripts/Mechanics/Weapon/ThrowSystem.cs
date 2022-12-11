using Leopotam.EcsLite;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

public class ThrowSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.KEY ThrowKey = Input.KEY.G;

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
        if (!Input.IsKeyPressed(ThrowKey)) return;

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PickupMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);

            weapon.Node.SetWorldParent(null);
            _pickupMarkerPool.Del(entity);
        }
    }
}
