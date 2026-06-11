using Hardware;
using LogicielMachineACafé = MachineACafé.Test.Utilities.SoftwareMachineBuilder;

namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void AucuneAction()
    {
        // ETANT DONNE une machine à café
        var machineACafé = LogicielMachineACafé.Default;

        // ALORS aucune invocation du Brewer ou de la ChangeMachine n'est effectuée
        Assert.AucuneAction(machineACafé.ChangeMachine);
        Assert.AucunAppel(machineACafé.Brewer);
    }

    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE une machine à café
        var machineACafé = LogicielMachineACafé.Default;

        // QUAND on insère une somme supérieure ou égale au prix d'un café
        machineACafé.SimulerInsertionPièce(CoinCode.FiftyCents);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.UnCaféServi(machineACafé.Brewer);

        // ET l'argent est encaissé
        Assert.ArgentEncaissé(machineACafé.ChangeMachine);
    }

    [Fact]
    public void CasBrewerDéfaillant()
    {
        // ETANT DONNE une machine à café ayant un brewer défaillant
        var machineACafé = new LogicielMachineACafé()
            .AyantUnBrewerDéfaillant()
            .Build();

        // QUAND on insère une somme supérieure ou égale au prix d'un café
        machineACafé.SimulerInsertionPièce(CoinCode.FiftyCents);

        // ALORS l'argent est restitué
        Assert.ArgentRestitué(machineACafé.ChangeMachine);
    }

    [Fact]
    public void PasAssezArgent()
    {
        // ETANT DONNE une machine à café
        var machineACafé = LogicielMachineACafé.Default;

        // QUAND on insère moins que le prix d'un café
        machineACafé.SimulerInsertionPièce(CoinCode.TwentyCents);

        // ALORS MakeACoffee n'est pas appelé
        Assert.AucunAppel(machineACafé.Brewer);

        // ET l'argent est restitué
        Assert.ArgentRestitué(machineACafé.ChangeMachine);
    }
}