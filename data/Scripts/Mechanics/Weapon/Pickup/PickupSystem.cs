using Leopotam.EcsLite;
using ProjectRed.Entities;
using ProjectRed.Mechanics.Weapon.Intersection;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Weapon.Pickup;

public class PickupSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<IntersectionMarker> _intersectionMarkerPool;
    private EcsPool<PickupMarker> _pickupMarkerPool;
    private EcsPool<OneFramePickupMarker> _oneFramePickupMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _gameObjectPool = world.GetPool<GameObject>();
        _intersectionMarkerPool = world.GetPool<IntersectionMarker>();
        _pickupMarkerPool = world.GetPool<PickupMarker>();
        _oneFramePickupMarkerPool = world.GetPool<OneFramePickupMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<GameObject>().Inc<IntersectionComponent>().Inc<IntersectionMarker>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var intersection = ref _intersectionMarkerPool.Get(entity);

            var weaponNode = intersection.Result.GetComponentInParent<WeaponEntity>();

            if (weaponNode == null) continue;

            if (weaponNode.PackedEntity.Unpack(world, out int unpacked))
            {
                _oneFramePickupMarkerPool.Add(unpacked);

                ref var pickupMarker = ref _pickupMarkerPool.Add(unpacked);
                pickupMarker.WeaponParent = gameObject.WeaponSlot;
                pickupMarker.Head = gameObject.Head;
            }
        }
    }
}
