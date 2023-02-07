using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct Player
{
    [ShowInEditor]
    private Node _head;

    [ShowInEditor]
    private Node _weaponSlot;

    [ShowInEditor]
    private Node _bulletsSpawnPoint;

    public Node Head => _head;
    public Node WeaponSlot => _weaponSlot;
    public Node BulletsSpawnPoint => _bulletsSpawnPoint;
}
