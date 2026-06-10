#pragma warning disable IDE0130
using MachineACafé.Test.Utilities.TestDoubles;

namespace Xunit;
#pragma warning restore IDE0130

// ReSharper disable once ClassNeverInstantiated.Global
partial class Assert
{
    internal static void UnCaféServi(BrewerSpy brewerSpy)
    {
        Equal(1, brewerSpy.MakeACoffeeInvocations);
    }
}