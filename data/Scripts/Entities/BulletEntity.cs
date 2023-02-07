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

    public void Spawn(in Mechanics.Object.Player player, in Bullet bullet)
    {
        Node result = World.LoadNode(bullet.Prefab);
        Node spawnEffect = World.LoadNode(bullet.SpawnEffect);

        result.WorldTransform = player.BulletsSpawnPoint.WorldTransform;
        spawnEffect.WorldPosition = player.BulletsSpawnPoint.WorldPosition;

        GameObject gameObject = new() 
        {
            Node = result
        };

        Movement movement = new() 
        {
            Speed = bullet.Speed,
            Input = player.BulletsSpawnPoint.GetDirection(MathLib.AXIS.Y) 
        };

        int entity = _world.NewEntity();

        _world.Add(entity, gameObject);
        _world.Add(entity, movement);
    }
}