using Leopotam.EcsLite;
using ProjectRed.Mechanics.Delay;
using ProjectRed.Mechanics.Weapon.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Weapon.Fire;

public class FireSystem : IEcsInitSystem, IEcsRunSystem
{
    public const Input.MOUSE_BUTTON FireKey = Input.MOUSE_BUTTON.LEFT;

    private EcsPool<Weapon> _weaponPool;
    private EcsPool<FiredMarker> _firedMarkerPool;
    private EcsPool<DelayMarker> _delayMarkerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _firedMarkerPool = world.GetPool<FiredMarker>();
        _delayMarkerPool = world.GetPool<DelayMarker>();
    }

    public void Run(IEcsSystems systems)
    {
        if (!Input.IsMouseButtonPressed(FireKey)) return;

        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PickupMarker>().Exc<DelayMarker>().Exc<FiredMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);

            _firedMarkerPool.Add(entity);

            ref var delayMarker = ref _delayMarkerPool.Add(entity);
            delayMarker.Milliseconds = weapon.DelayAfterShotInMilliseconds;
        }
    }
}
