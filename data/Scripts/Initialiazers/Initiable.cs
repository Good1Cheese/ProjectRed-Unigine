using Leopotam.EcsLite;

public interface Initiable
{
	void Initialize(EcsWorld world, EcsSystems systems);
}