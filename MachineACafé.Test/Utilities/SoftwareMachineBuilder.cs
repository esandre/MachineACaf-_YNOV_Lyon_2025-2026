using Hardware;
using MachineACafé.Test.Utilities.TestDoubles;
using Moq;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineBuilder
{
    private Mock<IBrewer> _brewer = BrewerTestDoubles.FactoryStub();
    private readonly Mock<ChangeMachineFake> _changeMachine = new () { CallBase = true };

    public static (SoftwareMachine Instance, IBrewer Brewer, IChangeMachine ChangeMachine) Default 
        => new SoftwareMachineBuilder().Build();

    public (SoftwareMachine Instance, IBrewer Brewer, IChangeMachine ChangeMachine) Build()
    {
        return (new SoftwareMachine(_brewer.Object, _changeMachine.Object), _brewer.Object, _changeMachine.Object);
    }

    public SoftwareMachineBuilder AyantUnBrewerDéfaillant()
    {
        _brewer = BrewerTestDoubles.FactoryDummy();
        return this;
    }
}