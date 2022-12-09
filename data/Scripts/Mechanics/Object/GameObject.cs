using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct GameObject
{
    public GameObject(Node body, Node head, Node weaponSlot)
    {
        Body = body;
        Head = head;
        WeaponSlot = weaponSlot;
    }

    public Node Body { get; }
    public Node Head { get; }
    public Node WeaponSlot { get; }
}
