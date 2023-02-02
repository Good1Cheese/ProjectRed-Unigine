using System;
using Unigine;

namespace ProjectRed.Mechanics.Rotate;

public struct Rotation
{
    [ShowInEditor]
    private float _speed;

    public float Speed => _speed;
    public vec2 Input { get; set; }
}
