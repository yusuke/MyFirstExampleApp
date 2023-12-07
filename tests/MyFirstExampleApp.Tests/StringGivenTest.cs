namespace MyFirstExampleApp.Tests;

public class StringGivenFive
{
    public Value Value { get; } = new StringGiven(5, "Buzz");
}

[CollectionDefinition("FiveBuzzTests")]
public class StringGivenFiveBuzzTests : ICollectionFixture<StringGivenFive>
{
}

[Collection("FiveBuzzTests")]
public class FiveBuzzTestsOriginal
{
    private readonly StringGivenFive _stringGivenFive;

    public FiveBuzzTestsOriginal(StringGivenFive stringGivenFive)
    {
        _stringGivenFive = stringGivenFive;
    }

    [Fact]
    public void OriginalIsFive()
    {
        Assert.Equal(5, _stringGivenFive.Value.Original);
    }
}

[Collection("FiveBuzzTests")]
public class FiveBuzzTestsAsString
{
    private readonly StringGivenFive _stringGivenFive;

    public FiveBuzzTestsAsString(StringGivenFive stringGivenFive)
    {
        _stringGivenFive = stringGivenFive;
    }

    [Fact]
    public void TestAsString()
    {
        Assert.Equal("Five", _stringGivenFive.Value.AsString());
    }
}

[Collection("FiveBuzzTests")]
public class FiveBuzzTestsString
{
    private readonly StringGivenFive _stringGivenFive;

    public FiveBuzzTestsString(StringGivenFive stringGivenFive)
    {
        _stringGivenFive = stringGivenFive;
    }

    [Fact]
    private void StringIsNotNull()
    {
        Assert.NotNull(_stringGivenFive.Value.String());
    }
}