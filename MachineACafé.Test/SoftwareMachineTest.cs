namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void CasNominal()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var machine = new SoftwareMachine();

        // QUAND on insère 40cts
        machine.Insérer(prixDuCafé);

        // ALORS un café coule
        Assert.Equal(1, machine.NombreCafésServis);

        // ET l'argent est encaissé
        Assert.Equal(prixDuCafé, machine.MontantEncaisséEnCentimes);
    }
}