using System;
using Unigine;

namespace ProjectRed.Mechanics.Object;

public struct PlayerGameObject
{
    [ShowInEditor]
    private Node _head;

    [ShowInEditor]
    private Node _WeaponSlot;

    [ShowInEditor]
    private Node _bulletsSpawnPoint;

    [ShowInEditor]
    [ParameterFile]
    private string _bullet;

    [ShowInEditor]
    [ParameterFile]
    private string _bulletSpawnEffect;

    public Node Head => _head;
    public Node WeaponSlot => _WeaponSlot;
    public Node BulletsSpawnPoint => _bulletsSpawnPoint;
    public string Bullet => _bullet;
    public string BulletSpawnEffect => _bulletSpawnEffect;
}
