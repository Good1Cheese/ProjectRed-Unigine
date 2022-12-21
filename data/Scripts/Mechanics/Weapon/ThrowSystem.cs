using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

public class ThrowSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON ThrowKey = Input.MOUSE_BUTTON.RIGHT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<PlayerGameObject> _gameObjectPool;
    private EcsPool<PickupMarker> _pickupMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _gameObjectPool = world.GetPool<PlayerGameObject>();
        _pickupMarkerPool = world.GetPool<PickupMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        if (!Input.IsMouseButtonPressed(ThrowKey)) return;

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PlayerGameObject>().Inc<PickupMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);
            ref var gameObject = ref _gameObjectPool.Get(entity);

            weapon.Node.SetWorldParent(null);

            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);

            BodyRigid rigid = weapon.Base.ObjectBodyRigid;
            rigid.Gravity = true;
            rigid.AddLinearImpulse(forward * 5);

            _pickupMarkerPool.Del(entity);
        }
    }
}
