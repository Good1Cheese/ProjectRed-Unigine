using System;
using Unigine;

namespace ProjectRed.Mechanics.Weapon;

[Serializable]
public struct Weapon
{
    [ShowInEditor]
    private float _delayAfterShotInMilliseconds;

    public float DelayAfterShotInMilliseconds => _delayAfterShotInMilliseconds;

    public Node Node { get; set; }
    public Node Base { get; set; }
}
