using Leopotam.EcsLite;
using System.Threading.Tasks;

namespace ProjectRed.Extensions;

public static class EcsExtensions
{
    public static void Add<T>(this EcsWorld world, in int entity) where T : struct
    {
        var pool = world.GetPool<T>();

        pool.Add(entity);
    }

    public static void Add<T>(this EcsWorld world, in int entity, in T existing) where T : struct
    {
        var pool = world.GetPool<T>();
        pool.Add(entity);

        ref var component = ref pool.Get(entity);

        component = existing;
    }

    public async static Task Del<T>(this EcsPool<T> pool, int entity, float delayInMilliseconds) where T : struct
    {
        await Task.Delay((int)delayInMilliseconds);

        pool.Del(entity);
    }
}
