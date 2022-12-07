using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct GameObject
{
    public GameObject(Node node, PlayerDummy camera)
    {
        Node = node;
        Camera = camera;
    }

    public Node Node { get; set; }
    public PlayerDummy Camera { get; set; }
}
