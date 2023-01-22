using System;
using Unigine;

namespace ProjectRed;

[Serializable]
public class SpawnableEntity
{
    [ShowInEditor]
    private vec3 _position;

    [ShowInEditor]
    private quat _rotation;

    [ShowInEditor]
    [ParameterFile]
    private AssetLinkNode _nodeLink;

    public vec3 Position => _position;
    public quat Rotation => _rotation;
    public AssetLinkNode NodeLink => _nodeLink;
}