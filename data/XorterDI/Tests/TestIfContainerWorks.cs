namespace XorterDI.Tests;

public class TestIfContainerWorks
{
    public void Test()
    {
        var container = new Container();

        var bindable = new TestBindable
        {
            Val = "Not initial"
        };

        var bindGet = new BindGetTest();

        container.Bind(bindable);
        container.SetBindings(bindGet);

        var result = bindGet.TestBindable == null;
    }
}