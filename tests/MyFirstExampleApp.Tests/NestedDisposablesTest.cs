namespace MyFirstExampleApp.Tests;

public class NestedDisposablesTest
{
    public IDisposable GetDisposable(NestedDisposablesTestMode mode)
    {
        return mode.GetDisposable();
    }
}

public enum NestedDisposablesTestMode
{
    NO_EXCEPTION,
    EXCEPTION,
}

public static class NestedDisposablesTestModeExtensions
{
    private class AnonymousDisposable : IDisposable
    {
        private readonly Close _close;

        public AnonymousDisposable(Close close)
        {
            _close = close;
        }

        public void Dispose()
        {
            _close();
        }
    }

    public static IDisposable GetDisposable(this NestedDisposablesTestMode mode)
    {
        switch (mode)
        {
            case NestedDisposablesTestMode.NO_EXCEPTION:
                return new AnonymousDisposable((() => { }));
            case NestedDisposablesTestMode.EXCEPTION:
                return new AnonymousDisposable(() => throw new Exception($"exception of {mode}"));
        }
        throw new ArgumentException($"unknown mode: { mode }");
    }
}

public delegate void Close();

[CollectionDefinition("NestedDisposablesTest")]
public class NestedDisposablesCollectionTest: ICollectionFixture<NestedDisposablesTest> {}

[Collection("NestedDisposablesTest")]
public class DeepNestedDisposablesTest
{
    private readonly NestedDisposablesTest _fixture;

    public DeepNestedDisposablesTest(NestedDisposablesTest fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ThousandFirst()
    {
        var first = _fixture.GetDisposable(NestedDisposablesTestMode.EXCEPTION);
        var second = _fixture.GetDisposable(NestedDisposablesTestMode.NO_EXCEPTION);
        var disposable = new NestedDisposable(first, second);
        for (int i = 0; i < 1000; i++)
        {
            disposable = disposable.Add(_fixture.GetDisposable(NestedDisposablesTestMode.NO_EXCEPTION));
        }
        Assert.Equal(1000, disposable.Depth);
        disposable.Dispose();
    }

    [Fact]
    public void ThousandLast()
    {
        var first = _fixture.GetDisposable(NestedDisposablesTestMode.NO_EXCEPTION);
        var second = _fixture.GetDisposable(NestedDisposablesTestMode.NO_EXCEPTION);
        var disposable = new NestedDisposable(first, second);
        for (int i = 0; i < 999; i++)
        {
            disposable = disposable.Add(_fixture.GetDisposable(NestedDisposablesTestMode.NO_EXCEPTION));
        }
        disposable = disposable.Add(_fixture.GetDisposable(NestedDisposablesTestMode.EXCEPTION));
        Assert.Equal(1000, disposable.Depth);
        disposable.Dispose();
    }
}
