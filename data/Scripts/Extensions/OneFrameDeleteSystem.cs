using Leopotam.EcsLite;

namespace ProjectRed.Extensions;

public class OneFrameDeleteSystem<T> : IEcsInitSystem, IEcsRunSystem where T : struct
{
    private EcsPool<T> _markerPool;

    public void Init(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        _markerPool = world.GetPool<T>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<T>().End();

        foreach (int entity in filter)
        {
            _markerPool.Del(entity);
        }
    }
}
