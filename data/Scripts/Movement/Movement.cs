﻿using System;
using Unigine;

[Serializable]
public struct Movement
{
    [ShowInEditor]
    private float _speed;

    public float Speed { get => _speed; set => _speed = value; }
    public vec2 Input { get; set; }
}