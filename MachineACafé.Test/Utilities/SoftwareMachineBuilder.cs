using Hardware;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineBuilder
{
    private IBrewer _brewer = null;

    public SoftwareMachine Build()
    {
        return new SoftwareMachine(_brewer);
    }

    public SoftwareMachineBuilder AyantUnBrewerDéfaillant()
    {
        _brewer = new BrewerDéfaillant();
        return this;
    }
}