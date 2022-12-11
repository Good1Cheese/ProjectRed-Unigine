using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Entities;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Pickup;

public class PickupSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.KEY PickupKey = Input.KEY.E;

    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<Intersection> _intersectionPool;
    private EcsPool<PickupMarker> _pickupMarkerPool;
    private EcsPool<OneFramePickupMarker> _oneFramePickupMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _gameObjectPool = world.GetPool<GameObject>();
        _intersectionPool = world.GetPool<Intersection>();
        _pickupMarkerPool = world.GetPool<PickupMarker>();
        _oneFramePickupMarkerPool = world.GetPool<OneFramePickupMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter pickupFilter = world.Filter<PickupMarker>().End();

        if (pickupFilter.GetEntitiesCount() > 0 || !Input.IsKeyPressed(PickupKey)) return;

        EcsFilter filter = world.Filter<GameObject>().Inc<Intersection>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var interaction = ref _intersectionPool.Get(entity);

            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);
            vec3 p0 = gameObject.Head.WorldPosition;
            vec3 p1 = p0 + forward * interaction.Length;

            var obj = World.GetIntersection(p0, p1, interaction.Mask);

            if (obj == null) continue;

            var parent = obj.Parent.Parent;

            var fireable = parent.GetComponent<WeaponEntity>();

            if (fireable == null) continue;

            if (fireable.PackedEntity.Unpack(world, out int unpacked))
            {
                _oneFramePickupMarkerPool.Add(unpacked);

                ref var pickupMarker = ref _pickupMarkerPool.Add(unpacked);
                pickupMarker.WeaponParent = gameObject.WeaponSlot;
            }
        }
    }
}
