using System;
using Unigine;

namespace ProjectRed.Mechanics.Move;

[Serializable]
public struct Movement
{
    [ShowInEditor]
    private float _speed;

    public vec2 Input { get; set; }

    public float Speed => _speed;
}
