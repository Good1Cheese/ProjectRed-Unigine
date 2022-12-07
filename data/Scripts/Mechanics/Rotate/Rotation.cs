using System;
using Unigine;

namespace ProjectRed.Mechanics.Rotate;

[Serializable]
public struct Rotation
{
    [ShowInEditor]
    private float _speed;

    public float Speed { get => _speed; set => _speed = value; }
    public vec2 Input { get; set; }
}
