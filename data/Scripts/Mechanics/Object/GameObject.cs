using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct GameObject
{
    public GameObject(Node node, Node cameraNode)
    {
        Body = node;
        Head = cameraNode;
    }

    public Node Body { get; }
    public Node Head { get; }
}
