using Hardware;
using MachineACafé.Test.Utilities.TestDoubles;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineBuilder
{
    private IBrewer _brewer = new BrewerStub();
    private IChangeMachine _changeMachine = new ChangeMachineStub();

    public SoftwareMachine Build()
    {
        return new SoftwareMachine(_brewer, _changeMachine);
    }

    public SoftwareMachineBuilder AyantUnBrewer(IBrewer brewer)
    {
        _brewer = brewer;
        return this;
    }

    public SoftwareMachineBuilder EspionnantLeBrewer(out BrewerSpy spy)
    {
        var brewerSpy = new BrewerSpy();
        spy = brewerSpy;
        _brewer = spy;

        return this;
    }

    public SoftwareMachineBuilder AyantUneChangeMachine(IChangeMachine changeMachine)
    {
        _changeMachine = changeMachine;
        return this;
    }
}