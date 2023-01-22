using Leopotam.EcsLite;
using Unigine;

namespace XorterDI;

[Component(PropertyGuid = "cdb60996262533fd12be6538eee667373fa11b2a")]
public class Installer : Component
{
    protected readonly Container _container = new();

    private void Init()
    {
        InstallBindings();
        InjectComponents();
    }

    private void InjectComponents()
    {
        ICollection<Node> nodes = new List<Node>();
        World.GetNodes(nodes);

        foreach (Node node in nodes)
        {
            Log.MessageLine(node.Name);

            var entity = node.GetComponent<IEntity>();

            if (entity == null) continue;

            _container.SetBindings(entity);
        }
    }

    public virtual void InstallBindings() { }
}
