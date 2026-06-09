using Hardware;

namespace MachineACafé;

public class SoftwareMachine
{
    public SoftwareMachine(IBrewer brewer, IChangeMachine changeMachine)
    {
        changeMachine.FlushStoredMoney();
        changeMachine.CollectStoredMoney();
    }

    public void Insérer(ushort montantEnCentimes)
    {
    }

    public ushort NombreCafésServis => 1;
}