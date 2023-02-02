using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct GameObject
{
    [ShowInEditor]
    private Node _node;

    public Node Node { get => _node; set => _node = value; }
}
