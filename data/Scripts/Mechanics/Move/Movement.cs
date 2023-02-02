using Unigine;

namespace ProjectRed.Mechanics.Move;

public struct Movement
{
    [ShowInEditor]
    private float _speed;

    public float Speed { get => _speed; set => _speed = value; }
    public vec3 Input { get; set; }
}
