namespace MyFirstExampleApp.Tests;

public class MyMatrixTest
{
    private static readonly Func<int?>[] MayLengths =
    {
        () => 257,
        () => null,
        () => 3
    };

    private static readonly string[] Lines =
    {
        "foo",
        "World",
        "Dynamic",
        "bar",
    };

    public static MyMatrixTestData Data = new MyMatrixTestData(MayLengths, Lines);

    [Theory]
    [MemberData(nameof(Data))]
    public void RunTests(MyStruct data)
    {
        Assert.Equal(data.ExpectedLength, data.StringItem.Length);
    }
}

public struct MyStruct
{
    public string StringItem { get; init; }
    public int ExpectedLength { get; init; }
}

public class MyMatrixTestData: TheoryData<MyStruct>
{
    public MyMatrixTestData(IEnumerable<Func<int?>> ifuncs, IEnumerable<string> lines)
    {
        foreach (var ifunc in ifuncs)
        {
            foreach (var line in lines)
            {
                var expectedLength = ifunc();
                Add(new MyStruct { StringItem = line, ExpectedLength = expectedLength ?? line.Length });
            }
        }
    }
}
