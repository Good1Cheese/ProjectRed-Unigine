using System;
using Unigine;

namespace ProjectRed.Mechanics.Weapon.Intersection;

[Serializable]
public struct IntersectionComponent
{
    [ShowInEditor]
    [ParameterMask]
    private int _mask;

    [ShowInEditor]
    private float _length;

    [ShowInEditor]
    private PhysicsIntersection _physicalIntersection;

    public int Mask => _mask;
    public float Length => _length;
    public PhysicsIntersection PhysicalIntersection => _physicalIntersection;
}
