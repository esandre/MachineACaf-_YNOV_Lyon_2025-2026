using Hardware;

namespace MachineACafé;

public class SoftwareMachine
{
    public SoftwareMachine(IBrewer brewer)
    {
    }

    public void Insérer(ushort montantEnCentimes)
    {
        MontantEncaisséEnCentimes += montantEnCentimes;
    }

    public ushort NombreCafésServis => 1;
    public ushort MontantEncaisséEnCentimes { get; private set; }
}