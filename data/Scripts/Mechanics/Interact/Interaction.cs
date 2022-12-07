using System;
using Unigine;

[Serializable]
public struct Interaction
{
    [ShowInEditor]
    [ParameterMask]
    private int _mask;

    [ShowInEditor]
    private float _length;

    public WorldIntersection Intersection { get; set; }

    public int Mask => _mask;
    public float Length => _length;
}
