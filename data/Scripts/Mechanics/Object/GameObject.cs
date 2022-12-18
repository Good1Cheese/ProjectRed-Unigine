using System;
using Unigine;

namespace ProjectRed.Mechanics.Object;

[Serializable]
public struct GameObject
{
    [ShowInEditor] 
    private Node _body;

    [ShowInEditor] 
    private Node _head;

    [ShowInEditor]
    private Node _weaponSlot;

    [ShowInEditor]
    private Node _bulletsSpawnPoint;

    [ShowInEditor]
    private AssetLinkNode _bulletAsset;

    public Node Body => _body;
    public Node Head => _head;
    public Node WeaponSlot => _weaponSlot;
    public Node BulletsSpawnPoint => _bulletsSpawnPoint;
    public AssetLinkNode BulletNodeLink => _bulletAsset;
}
