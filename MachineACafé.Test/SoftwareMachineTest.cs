namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE une machine à café
        var machine = new SoftwareMachine();

        // QUAND on insère 40cts
        machine.InsérerCentimes(40);

        // ALORS un café coule
        Assert.Equal(1, machine.NombreCafésServis);

        // ET l'argent est encaissé
        Assert.Equal(40, machine.MontantEncaisséEnCentimes);
    }
}