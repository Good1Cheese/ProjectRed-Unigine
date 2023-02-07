using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Object;
using Unigine;

namespace ProjectRed.Entities;

public class BulletEntity
{
    private EcsWorld _world;

    public BulletEntity(EcsWorld world)
    {
        _world = world;
    }

    public void Spawn(in PlayerGameObject player)
    {
        Node bullet = World.LoadNode(player.Bullet);
        Node spawnEffect = World.LoadNode(player.BulletSpawnEffect);

        bullet.WorldTransform = player.BulletsSpawnPoint.WorldTransform;
        spawnEffect.WorldPosition = player.BulletsSpawnPoint.WorldPosition;

        int entity = _world.NewEntity();

        GameObject gameObject = new() { Node = bullet };
        Movement movement = new() { Speed = 0.5f, Input = player.BulletsSpawnPoint.GetDirection(MathLib.AXIS.Y) };

        _world.Add(entity, gameObject);
        _world.Add(entity, movement);
    }
}