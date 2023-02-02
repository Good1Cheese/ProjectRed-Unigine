using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Weapon;
using Unigine;
using XorterDI;

namespace ProjectRed.Entities;

[Component(PropertyGuid = "16556aacd211e61b81a964be26bac505dbe7f2a0")]
public class WeaponEntity : Component, IEntity
{
    [ShowInEditor]
    private Weapon _weapon;

    public EcsPackedEntity PackedEntity { get; set; }

    [Inject]
    public void Create(EcsWorld world)
    {
        int entity = world.NewEntity();

        _weapon.Node = node;
        _weapon.Base = node.GetChild(0);

        world.Add(entity, _weapon);

        PackedEntity = world.PackEntity(entity);
    }
}
