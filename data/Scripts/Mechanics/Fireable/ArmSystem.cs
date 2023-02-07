﻿using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Fireable.Pickup;
using Unigine;

namespace ProjectRed.Mechanics.Fireable;

public class ArmSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsPool<Weapon> _weaponPool;
    private EcsPool<Object.Player> _playerPool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        _weaponPool = world.GetPool<Weapon>();
        _playerPool = world.GetPool<Object.Player>();
    }

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        EcsFilter filter = world.Filter<Weapon>().Inc<PickupMarker>().Inc<OneFramePickupMarker>().End();

        foreach (int entity in filter)
        {
            ref var weapon = ref _weaponPool.Get(entity);
            ref var gameObject = ref _playerPool.Get(weapon.Owner);

            BodyRigid rigid = weapon.Base.ObjectBodyRigid;
            rigid.Gravity = false;

            weapon.Node.SetWorldParent(gameObject.WeaponSlot);
            ResetNode(weapon.Node);
            ResetNode(weapon.Base);
        }
    }

    private static void ResetNode(Node node)
    {
        node.Position = vec3.ZERO;
        node.SetRotation(quat.IDENTITY);
    }
}