using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

public class BulletSpawnSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Weapon> _weaponPool;
    private EcsPool<GameObject> _gameObjectPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _gameObjectPool = world.GetPool<GameObject>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<GameObject>().Inc<FiredMarker>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var weapon = ref _weaponPool.Get(entity);

            vec3 spawn = gameObject.BulletsSpawnPoint.WorldPosition;
            Node bullet = gameObject.BulletNodeLink.Load(spawn);

            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);
            bullet.SetWorldDirection(forward, vec3.UP);

            Node spawnEffect = World.LoadNode(weapon.BulletSpawnEffect);
            spawnEffect.SetWorldParent(bullet);
        }
    }
}