using Leopotam.EcsLite;

public interface IInitializable
{
	void Init(EcsWorld world, EcsSystems systems);
}