using Leopotam.EcsLite;

namespace ProjectRed.Entities;

public interface IEntity
{
    void Create(EcsWorld world);
}
