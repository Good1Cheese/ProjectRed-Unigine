using Leopotam.EcsLite;
using ProjectRed.Extensions;

namespace ProjectRed.Mechanics.Delay;

public class DelayHandlerSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<DelayMarker> _markerPool;

    public void Init(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        _markerPool = world.GetPool<DelayMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<DelayMarker>().End();

        foreach (int entity in filter)
        {
            ref var delayMarker = ref _markerPool.Get(entity);

            if (delayMarker.Going) continue;

            delayMarker.Going = true;
            _markerPool.Del(entity, delayMarker.Milliseconds);
        }
    }
}
