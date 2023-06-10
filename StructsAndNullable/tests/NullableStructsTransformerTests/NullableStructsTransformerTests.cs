using Xunit;
using FluentAssertions;

namespace Transformers.Tests;

public class NullableStructsTransformerTests
{
    private const string TestSuffix = "Test";

    [Fact]
    public void Transform_IfNotNullReference_AppliesTransformation()
    {
        const string source = nameof(source);
        NullableStructsTransformer.Transform(source, x => x + TestSuffix).Should().Be(source + TestSuffix);
    }

    [Fact]
    public void Transform_IfNullReference_ReturnsNull()
    {
        const string? source = null;
        NullableStructsTransformer.Transform(source, x => x + TestSuffix).Should().BeNull();
    }

    [Fact]
    public void Transform_IfNotNullStruct_AppliesTransformation()
    {
        DateTime source = DateTime.Now;
        NullableStructsTransformer.Transform(source, x => x.AddDays(1))
            .Should().Be(source.AddDays(1));
    }

    [Fact]
    public void Transform_IfNullStruct_ReturnsNull()
    {
        DateTime? source = null;
        DateTime? result = NullableStructsTransformer.Transform(source, x => x.AddDays(1));
        result.Should().BeNull();
    }

    [Fact]
    public void TransformFixed_IfNullStruct_ReturnsNull()
    {
        DateTime? source = null;
        DateTime? result = NullableStructsTransformer.TransformFixed(source, x => x.AddDays(1));
        result.Should().BeNull();
    }
}
