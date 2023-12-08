using Xunit.Sdk;

namespace MyFirstExampleApp.Tests.Ext;

public partial class AssertExt
{
    public static void Equal<T>(T expected, T actual, string message)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new AssertActualExpectedException(expected, actual, message);
        }
    }
}
