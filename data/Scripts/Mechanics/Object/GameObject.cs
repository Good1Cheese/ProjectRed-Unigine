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

    public Node Body => _body;
    public Node Head => _head;
    public Node WeaponSlot => _weaponSlot;
}
