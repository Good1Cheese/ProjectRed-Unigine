using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Rotate;
using ProjectRed.Mechanics.Fireable.Pickup;
using ProjectRed.Mechanics.Fireable;
using ProjectRed.Mechanics.Intersection;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "4fbd8b2465035c33b551f3f6ebd25adde5e69e98")]
public class EcsSystemsHandler : Component
{
    private EcsSystems _systems;

    public void Create(EcsWorld world)
    {
        _systems = new(world);

        _systems.Add(new MoveInputSystem());
        _systems.Add(new RotateInputSystem());
        _systems.Add(new DelayHandlerSystem());

        _systems.Add(new MarkerDeleteSystem<OneFramePickupMarker>());
        _systems.Add(new MarkerDeleteSystem<IntersectionMarker>());
        _systems.Add(new IntersectionSystem());
        _systems.Add(new PickupSystem());

        _systems.Add(new FireSystem());
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
