using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

public class ArmSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Weapon> _weaponPool;
    private EcsPool<PlayerGameObject> _playerGameObjectPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _playerGameObjectPool = world.GetPool<PlayerGameObject>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PlayerGameObject>().Inc<PickupMarker>().Inc<OneFramePickupMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);
            ref var gameObject = ref _playerGameObjectPool.Get(entity);

            BodyRigid rigid = weapon.Base.ObjectBodyRigid;
            rigid.Gravity = false;

            weapon.Node.SetWorldParent(gameObject.WeaponSlot);
            ResetNode(weapon.Node);
            ResetNode(weapon.Base);
        }
    }

    private static void ResetNode(Node node)
    {
        node.Position = vec3.ZERO;
        node.SetRotation(quat.IDENTITY);
    }
}
