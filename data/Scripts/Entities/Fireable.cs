using Leopotam.EcsLite;
using ProjectRed.Entities;
using ProjectRed.Extensions;
using Unigine;

namespace ProjectRed.Entities;

[Component(PropertyGuid = "16556aacd211e61b81a964be26bac505dbe7f2a0")]
public class Fireable : Component, IEntity
{
    [ShowInEditor]
    private Weapon _weapon;

    public EcsPackedEntity PackedEntity { get; set; }

    public void Create(EcsWorld world)
    {
        int entity = world.NewEntity();

        world.Add(entity, _weapon);

        PackedEntity = world.PackEntity(entity);
    }
}
