using Hardware;

namespace MachineACafé;

public class SoftwareMachine
{
    private readonly IBrewer _brewer;
    private readonly IChangeMachine _changeMachine;

    public SoftwareMachine(IBrewer brewer, IChangeMachine changeMachine)
    {
        _brewer = brewer;
        _changeMachine = changeMachine;
    }

    public void Insérer(ushort montantEnCentimes)
    {
        _changeMachine.FlushStoredMoney();
        _changeMachine.CollectStoredMoney();

        try
        {
            _brewer.MakeACoffee();
        }
        catch
        {
        }
    }
}