using Leopotam.EcsLite;
using System.Threading.Tasks;

namespace ProjectRed.Extensions;

public static class EcsExtensions
{
    public static ref T Get<T>(this EcsPool<T> pool, in EcsPackedEntityWithWorld packedEntity) where T : struct
    {
        packedEntity.Unpack(out _, out int owner);
        return ref pool.Get(owner);
    }

    public static void Add<T>(this EcsWorld world, in int entity, in T existing) where T : struct
    {
        var pool = world.GetPool<T>();
        pool.Add(entity);

        ref var component = ref pool.Get(entity);

        component = existing;
    }

    public static void Add<T>(this EcsPool<T> pool, in int entity, in T existing) where T : struct
    {
        ref var component = ref pool.Add(entity);

        component = existing;
    }

    public async static Task Del<T>(this EcsPool<T> pool, int entity, float delayInMilliseconds) where T : struct
    {
        await Task.Delay((int)delayInMilliseconds);

        pool.Del(entity);
    }
}
