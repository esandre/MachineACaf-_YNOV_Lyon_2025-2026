using Hardware;
using Moq;

namespace MachineACafé.Test.Utilities.TestDoubles;

internal static class BrewerTestDoubles
{
    public static Mock<IBrewer> FactoryStub()
    {
        var mock = new Mock<IBrewer>();
        mock.Setup(m => m.MakeACoffee()).Returns(true);
        mock.Setup(m => m.TryPullWater()).Returns(true);
        mock.Setup(m => m.PourMilk()).Returns(true);
        mock.Setup(m => m.PourWater()).Returns(true);
        mock.Setup(m => m.PourSugar()).Returns(true);
        mock.Setup(m => m.PourChocolate()).Returns(true);
        return mock;
    }

    public static Mock<IBrewer> FactoryDummy()
    {
        var mock = new Mock<IBrewer>(MockBehavior.Strict);
        return mock;
    }
}