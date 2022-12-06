using Leopotam.EcsLite;
using Unigine;

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

        EcsFilter filter = world.Filter<GameObject>().Inc<Movement>().End();

        foreach (int entity in filter)
        {
            ref var movement = ref _movementPool.Get(entity);

            movement.Input = _input;
        }
    }

    private void GetInput()
    {
        _input.x = InputExtensions.GetAxis(Input.KEY.D, Input.KEY.A);
        _input.y = InputExtensions.GetAxis(Input.KEY.W, Input.KEY.S);

        _input.Normalize();
    }
}
