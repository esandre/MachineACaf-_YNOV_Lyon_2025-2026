using Hardware;

namespace MachineACafé;

public class SoftwareMachine
{
    public SoftwareMachine(IBrewer brewer, IChangeMachine changeMachine)
    {
        changeMachine.FlushStoredMoney();
        changeMachine.CollectStoredMoney();

        try
        {
            brewer.MakeACoffee();
        }
        catch
        {
        }
    }

    public void Insérer(ushort montantEnCentimes)
    {
    }
}