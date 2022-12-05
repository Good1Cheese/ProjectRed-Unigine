using Leopotam.EcsLite;
using Unigine;

[Component(PropertyGuid = "efaac500af98f45ff5d8363228e39fe99f75e834")]
public class Systems : Component, Initiable
{
    public void Initialize(EcsWorld world, EcsSystems systems)
    {
        systems.Add(new MovementInputSystem());
        systems.Add(new MoveSystem());
    }
}
