#pragma warning disable IDE0130
using Hardware;
using Moq;

namespace Xunit;
#pragma warning restore IDE0130

// ReSharper disable once ClassNeverInstantiated.Global
partial class Assert
{
    internal static void UnCaféServi(IBrewer brewer)
    {
        var brewerSpy = Mock.Get(brewer);

        brewerSpy.Verify(m => m.MakeACoffee(), Times.Once);
    }

    internal static void AucunAppel(IBrewer brewer)
    {
        var brewerSpy = Mock.Get(brewer);

        Empty(brewerSpy.Invocations);
    }
}