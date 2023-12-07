namespace MyFirstExampleApp;

public readonly struct PureNumber: Value
{
    public PureNumber(int original)
    {
        Original = original;
    }

    public int Original { get; init; }

    public string AsString()
    {
        return Original.ToString();
    }

    public string? String()
    {
        return null;
    }
}
