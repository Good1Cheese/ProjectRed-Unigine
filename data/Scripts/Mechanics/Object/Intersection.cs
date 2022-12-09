using System;
using Unigine;

namespace ProjectRed.Mechanics.Object;

[Serializable]
public struct Intersection
{
    [ShowInEditor]
    [ParameterMask]
    private int _mask;

    [ShowInEditor]
    private float _length;

    public int Mask => _mask;
    public float Length => _length;
}
