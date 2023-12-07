using MyFirstExampleApp.Rules;
using MyFirstExampleApp.Values;

namespace MyFirstExampleApp.Tests.Rules;

public class ModAppendRuleTest
{
    public Rule MyRule { get; } = new ModAppendRule(5, "Buzz");
}

[CollectionDefinition("ModAppendRuleFive")]
public class ModAppendRuleFile : ICollectionFixture<ModAppendRuleTest>
{
}

[Collection("ModAppendRuleFive")]
public class ModAppendRuleApplicableTest : IClassFixture<ModAppendRuleTest>
{
    private Rule _rule;

    public ModAppendRuleApplicableTest(ModAppendRuleTest fixture)
    {
        _rule = fixture.MyRule;
    }

    [Fact]
    public void Test3IsNotApplicable()
    {
        Value number = new PureNumber(3);
        Value result = _rule.Apply(number);
        Assert.Equal(number, result);
    }

    [Fact]
    public void Test5IsApplicable()
    {
        Value number = new PureNumber(5);
        Value result = _rule.Apply(number);
        Assert.NotEqual(number, result);
    }

    [Fact]
    public void Test5WithStringIsApplicable()
    {
        Value given = new StringGiven(5, "Test");
        Value result = _rule.Apply(given);
        Assert.NotEqual(given, result);
        Assert.Equal("Test", result.AsString());
    }
}
