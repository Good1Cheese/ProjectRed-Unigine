using Leopotam.EcsLite;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Rotate;
using Unigine;

namespace ProjectRed.Initiables.Entities;

[Component(PropertyGuid = "efaac500af98f45ff5d8363228e39fe99f75e834")]
public class Systems : Component, Initiable
{
    public void Initialize(EcsWorld world, EcsSystems systems)
    {
        systems.Add(new MoveInputSystem());
        systems.Add(new RotateInputSystem());

        systems.Add(new MoveSystem());
        systems.Add(new RotateSystem());
    }
}