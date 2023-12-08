namespace MyFirstExampleApp;

public class MyAsync : IDisposable
{
    private readonly List<Timer> _timers = new();

    public Task<string> Run(Func<string> task, TimeSpan timeSpan)
    {
        var source = new TaskCompletionSource<string>();
        var timer = new Timer(_ =>
        {
            try
            {
                var result = task();
                source.SetResult(result);
            }
            catch (Exception e)
            {
                source.SetException(e);
            }
        }, null, timeSpan, Timeout.InfiniteTimeSpan);
        _timers.Add(timer);
        return source.Task;
    }

    public void Dispose()
    {
        foreach (var timer in _timers)
        {
            timer.Dispose();
        }
    }
}
