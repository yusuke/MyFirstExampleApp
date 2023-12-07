namespace MyFirstExampleApp;

public class NestedDisposable: IDisposable
{

    public int Depth { get; }
    private readonly IDisposable _first;
    private readonly IDisposable _second;

    public NestedDisposable(IDisposable first, IDisposable second)
    {
        Depth = 0;
        _first = first;
        _second = second;
    }

    private NestedDisposable(int depth, IDisposable first, IDisposable second)
    {
        Depth = depth;
        _first = first;
        _second = second;
    }

    public NestedDisposable Add(IDisposable other)
    {
        return new NestedDisposable(Depth + 1, this, other);
    }

    public void Dispose()
    {
        var disposables = new List<IDisposable>() { _first, _second };
        Exception? exception = null;
        foreach (var disposable in disposables)
        {
            try
            {
                disposable.Dispose();
            }
            catch (Exception e)
            {
                if (exception == null)
                {
                    exception = e;
                }
                else
                {
                    var pre = exception;
                    exception = new AggregateException(pre, e);
                }
            }
        }
        if (exception != null)
        {
            throw exception;
        }
    }
}
