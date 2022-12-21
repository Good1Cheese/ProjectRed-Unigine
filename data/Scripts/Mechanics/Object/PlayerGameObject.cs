using System;
using Unigine;

namespace ProjectRed.Mechanics.Object;

[Serializable]
public struct PlayerGameObject
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
    [ParameterFile]
    private string _bullet;

    [ShowInEditor]
    [ParameterFile]
    private string _bulletSpawnEffect;

    public Node Body => _body;
    public Node Head => _head;
    public Node WeaponSlot => _weaponSlot;
    public Node BulletsSpawnPoint => _bulletsSpawnPoint;
    public string Bullet => _bullet;
    public string BulletSpawnEffect => _bulletSpawnEffect;
}
