namespace MyFirstExampleApp.Tests;

public class MyAsyncTest: IDisposable
{
    private readonly MyAsync _myAsync = new();

    [Fact]
    public async Task TestRun()
    {
        var result = await _myAsync.Run(()=> "Example", new TimeSpan(0, 0, 2));
        Assert.Equal("Example", result);
    }

    [Fact]
    public async Task TestFailed()
    {
        var exception = await Assert.ThrowsAsync<Exception>(
            async () =>
            {
                await _myAsync.Run(() => "FOO", new TimeSpan(0, 0, 2));
            }
        );
    }

    [Fact]
    public async Task TestThrow()
    {
        await _myAsync.Run(() => throw new Exception("MyAsync"), new TimeSpan(0, 0, 0, 0, 300));
    }

    public void Dispose()
    {
        _myAsync.Dispose();
    }
}
