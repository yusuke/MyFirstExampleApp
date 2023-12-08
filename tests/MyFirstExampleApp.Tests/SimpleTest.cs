using MyFirstExampleApp.Tests.Ext;

namespace MyFirstExampleApp.Tests;

public class SimpleTest
{
    [Fact]
    public void FooHasSize3()
    {
        string foo = "foo";
        foo.HasSize(3);
    }

    [Fact]
    public void FooHasSize7()
    {
        string foo = "foo";
        foo.HasSize(7);
    }
}
