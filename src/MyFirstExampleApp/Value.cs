namespace MyFirstExampleApp
{
    public interface Value
    {
        public int Original { get; }

        public string AsString();

        public string? String();
    }

    namespace Values
    {
        public readonly struct PureNumber : Value
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
    }
}