using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct Bullet
{
    [ShowInEditor]
    [ParameterFile]
    private string _prefab;

    [ShowInEditor]
    [ParameterFile]
    private string _spawnEffect;

    [ShowInEditor]
    private float _speed;

    public string Prefab { get => _prefab; }
    public string SpawnEffect { get => _spawnEffect; }
    public float Speed { get => _speed; }
}
