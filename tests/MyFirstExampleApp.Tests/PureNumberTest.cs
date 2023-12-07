using MyFirstExampleApp.Values;

namespace MyFirstExampleApp.Tests;

public class PureNumberTest
{
    [Fact]
    public void TestOne()
    {
        var value = new PureNumber(1);
        Assert.Equal("1", value.AsString());
    }

    [Fact]
    public void Three()
    {
        var three = new PureNumber(3);
        Assert.Equal("3", three.AsString());
    }
}
