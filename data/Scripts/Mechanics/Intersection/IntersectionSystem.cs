using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Fireable.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Intersection;

public class IntersectionSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.KEY PickupKey = Input.KEY.E;

    private EcsPool<Object.Player> _playerPool;
    private EcsPool<IntersectionComponent> _intersectionPool;
    private EcsPool<IntersectionMarker> _intersectionMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _playerPool = world.GetPool<Object.Player>();
        _intersectionPool = world.GetPool<IntersectionComponent>();
        _intersectionMarkerPool = world.GetPool<IntersectionMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter pickupFilter = world.Filter<PickupMarker>().End();

        if (pickupFilter.GetEntitiesCount() > 0 || !Input.IsKeyPressed(PickupKey)) return;

        EcsFilter filter = world.Filter<Object.Player>().Inc<IntersectionComponent>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _playerPool.Get(entity);
            ref var intersection = ref _intersectionPool.Get(entity);

            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);
            vec3 p0 = gameObject.Head.WorldPosition;
            vec3 p1 = p0 + forward * intersection.Length;

            var result = Physics.GetIntersection(p0, p1, intersection.Mask, intersection.PhysicalIntersection);

            if (result == null) continue;

            ref var marker = ref _intersectionMarkerPool.Add(entity);
            marker.Result = result;
        }
    }
}
