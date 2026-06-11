using Hardware;
using MachineACafé.Test.Utilities.TestDoubles;
using Moq;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineHarness
{
    private readonly SoftwareMachine _softwareMachine;
    private readonly Mock<IBrewer> _brewer;
    private readonly Mock<ChangeMachineFake> _changeMachine;

    public IBrewer Brewer => _brewer.Object;
    public IChangeMachine ChangeMachine => _changeMachine.Object;

    public SoftwareMachineHarness(
        SoftwareMachine softwareMachine, 
        Mock<IBrewer> brewer,
        Mock<ChangeMachineFake> changeMachine)
    {
        _softwareMachine = softwareMachine;
        _brewer = brewer;
        _changeMachine = changeMachine;
    }

    public static implicit operator SoftwareMachine(SoftwareMachineHarness harness) 
        => harness._softwareMachine;

    public void SimulerInsertionPièce(CoinCode fiftyCents) 
        => _changeMachine.Object.SimulerInsertionPièce(fiftyCents);
}