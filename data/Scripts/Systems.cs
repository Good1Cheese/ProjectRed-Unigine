using Leopotam.EcsLite;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Rotate;
using Unigine;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Weapon;
using ProjectRed.Mechanics.Weapon.Pickup;
using ProjectRed.Mechanics.Weapon.Intersection;
using ProjectRed.Mechanics.Delay;

namespace ProjectRed;

[Component(PropertyGuid = "efaac500af98f45ff5d8363228e39fe99f75e834")]
public class Systems : Component
{
    private EcsSystems _systems;

    public void Initialize(EcsWorld world)
    {
        _systems = new(world);

        _systems.Add(new MoveInputSystem());
        _systems.Add(new RotateInputSystem());
        _systems.Add(new DelayHandlerSystem());

        _systems.Add(new MarkerDeleteSystem<OneFramePickupMarker>());
        _systems.Add(new MarkerDeleteSystem<IntersectionMarker>());
        _systems.Add(new IntersectionSystem());
        _systems.Add(new PickupSystem());

        _systems.Add(new MarkerDeleteSystem<FiredMarker>());
        _systems.Add(new FireSystem());
        _systems.Add(new BulletSpawnSystem());
        _systems.Add(new ArmSystem());
        _systems.Add(new ThrowSystem());

        _systems.Add(new MoveSystem());
        _systems.Add(new RotateSystem());

        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void Shutdown()
    {
        _systems.Destroy();
    }
}
