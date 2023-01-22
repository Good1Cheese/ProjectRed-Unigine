namespace XorterDI.Tests;

public class BindGetTest
{
    public TestBindable TestBindable { get; set; }

    [Inject]
    public void Construct(TestBindable testBindable)
    {
        TestBindable = testBindable;
    }
}
