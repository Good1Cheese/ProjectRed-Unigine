using Leopotam.EcsLite;
using ProjectRed.Mechanics.Object;
using Unigine;

public class InteractSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<GameObject> _gameObjectPool;
    private EcsPool<Interaction> _intersectionPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _gameObjectPool = world.GetPool<GameObject>();
        _intersectionPool = world.GetPool<Interaction>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<GameObject>().Inc<Interaction>().End();

        foreach (int entity in filter)
        {
            ref var gameObject = ref _gameObjectPool.Get(entity);
            ref var interaction = ref _intersectionPool.Get(entity);

            vec3 v1 = gameObject.Head.WorldPosition;
            vec3 forward = gameObject.Head.GetWorldDirection(MathLib.AXIS.Y);
            vec3 v2 = v1 + forward * interaction.Length;
         

            var obj = World.GetIntersection(v1, v2, interaction.Mask, interaction.Intersection);

            Log.MessageLine(obj == null);
        }
    }
}
