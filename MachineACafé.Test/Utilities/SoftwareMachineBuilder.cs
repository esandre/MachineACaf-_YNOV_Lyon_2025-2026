using Hardware;
using MachineACafé.Test.Utilities.TestDoubles;
using Moq;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineBuilder
{
    private Mock<IBrewer> _brewer = BrewerTestDoubles.FactoryStub();
    private readonly Mock<ChangeMachineFake> _changeMachine = new () { CallBase = true };

    public static SoftwareMachineHarness Default 
        => new SoftwareMachineBuilder().Build();

    public SoftwareMachineHarness Build()
    {
        return new SoftwareMachineHarness(
            new SoftwareMachine(_brewer.Object, _changeMachine.Object), 
            _brewer, 
            _changeMachine);
    }

    public SoftwareMachineBuilder AyantUnBrewerDéfaillant()
    {
        _brewer = BrewerTestDoubles.FactoryDummy();
        return this;
    }
}