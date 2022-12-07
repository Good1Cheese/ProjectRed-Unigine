using Leopotam.EcsLite;

namespace ProjectRed.Extensions;

public static class EcsExtensions
{
    public static void Add<T>(this EcsWorld world, in int entity, in T existing) where T : struct
    {
        var pool = world.GetPool<T>();
        pool.Add(entity);

        ref var component = ref pool.Get(entity);

        component = existing;
    }
}
