using Leopotam.EcsLite;
using ProjectRed.Entities;
using ProjectRed.Mechanics.Intersection;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Fireable.Pickup;

public class PickupSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Object.Player> _playerGameObject;
    private EcsPool<IntersectionMarker> _intersectionMarkerPool;
    private EcsPool<PickupMarker> _pickupMarkerPool;
    private EcsPool<OneFramePickupMarker> _oneFramePickupMarkerPool;
    private EcsPool<Weapon> _weaponPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _playerGameObject = world.GetPool<Object.Player>();
        _intersectionMarkerPool = world.GetPool<IntersectionMarker>();
        _pickupMarkerPool = world.GetPool<PickupMarker>();
        _oneFramePickupMarkerPool = world.GetPool<OneFramePickupMarker>();
        _weaponPool = world.GetPool<Weapon>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Object.Player>().Inc<IntersectionComponent>().Inc<IntersectionMarker>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _playerGameObject.Get(entity);
            ref var intersection = ref _intersectionMarkerPool.Get(entity);

            var WeaponNode = intersection.Result.GetComponentInParent<WeaponEntity>();

            if (WeaponNode == null) continue;

            if (WeaponNode.PackedEntity.Unpack(world, out int unpacked))
            {
                ref var weapon = ref _weaponPool.Get(unpacked);
                weapon.Owner = world.PackEntityWithWorld(entity);

                _pickupMarkerPool.Add(unpacked);
                _oneFramePickupMarkerPool.Add(unpacked);
            }
        }
    }
}
