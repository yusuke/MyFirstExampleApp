using Xunit.Sdk;

namespace MyFirstExampleApp.Tests.Ext;

public static class StringExtensions
{
    public static void HasSize(this string text, int length)
    {
        AssertExt.Equal(length, text.Length, $"expect { length } is the length of text '{text}'.");
    }
}
