namespace MyFirstExampleApp.Tests;

public class WillThrow
{
    public 
    WillThrow()
    {
        throw new TestException();
    }

    [Fact]
    public void Test1()
    {
        var one = int.Parse("1");
        Assert.Equal(1, one);
    }

    [Fact]
    public void Test4()
    {
        var four = int.Parse("4");
        Assert.Equal(4, four);
    }
}

public class TestException: Exception {}
