using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Mechanics.Move;

public class MoveInputSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Movement> _movementPool;

    private vec2 _input = new();

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _movementPool = world.GetPool<Movement>();
    }

    public void Run(IEcsSystems systems)
    {
        GetInput();

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Movement>().Inc<PlayerGameObject>().End();

        foreach (int entity in filter)
        {
            ref var movement = ref _movementPool.Get(entity);

            movement.Input = (vec3)_input;
        }
    }

    private void GetInput()
    {
        _input.x = InputExtensions.GetAxis(Input.KEY.D, Input.KEY.A);
        _input.y = InputExtensions.GetAxis(Input.KEY.W, Input.KEY.S);

        if (_input.Length2 > 0)
        {
            _input.Normalize();
        }
    }
}
