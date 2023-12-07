namespace MyFirstExampleApp;

public record StringGiven(
    int Original,
    string Text
) : Value
{
    public string AsString()
    {
        return Text;
    }

    public string String()
    {
        return Text;
    }
}
