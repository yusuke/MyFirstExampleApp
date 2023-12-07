using System.Security.Cryptography;
using MyFirstExampleApp.Values;

namespace MyFirstExampleApp.Rules;

public record ModAppendRule(int Law, string Text) : Rule
{
    public Value Apply(Value from)
    {
        if (from.Original % Law == 0)
        {
            var str = from.String();
            return str == null
                ? new StringGiven(from.Original, this.Text)
                : new StringGiven(from.Original, $"{str} {this.Text}");
        }
        else
        {
            return from;
        }
    }
}
