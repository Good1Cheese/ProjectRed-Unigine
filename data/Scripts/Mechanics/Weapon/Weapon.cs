using System;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

[Serializable]
public struct Weapon
{
    [ShowInEditor]
    private float _delayAfterShotInMilliseconds;

    [ShowInEditor]
    [ParameterFile]
    private string _bulletSpawnEffect;

    public float DelayAfterShotInMilliseconds => _delayAfterShotInMilliseconds;
    public string BulletSpawnEffect => _bulletSpawnEffect;


    public Node Node { get; set; }
    public Node Base { get; set; }
}
