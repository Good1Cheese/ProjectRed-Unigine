using Leopotam.EcsLite;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Rotate;
using Unigine;
using ProjectRed.Mechanics.Pickup;

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
        _systems.Add(new PickupSystem());

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