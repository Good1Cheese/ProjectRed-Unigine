using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Fireable.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Fireable;

public class ThrowSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON ThrowKey = Input.MOUSE_BUTTON.RIGHT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<Object.Player> _playerPool;
    private EcsPool<PickupMarker> _pickupMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _playerPool = world.GetPool<Object.Player>();
        _pickupMarkerPool = world.GetPool<PickupMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        if (!Input.IsMouseButtonPressed(ThrowKey)) return;

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PickupMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);
            ref var gameObject = ref _playerPool.Get(weapon.Owner);

            weapon.Node.SetWorldParent(null);

            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);

            BodyRigid rigid = weapon.Base.ObjectBodyRigid;
            rigid.Gravity = true;
            rigid.AddLinearImpulse(forward * 5);

            _pickupMarkerPool.Del(entity);
        }
    }
}
