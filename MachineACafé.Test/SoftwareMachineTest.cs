using Hardware;
using MachineACafé.Test.Utilities.TestDoubles;
using LogicielMachineACafé = MachineACafé.Test.Utilities.SoftwareMachineBuilder;

namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void AucuneAction()
    {
        // ETANT DONNE une machine à café
        var (_, brewer, changeMachine) = LogicielMachineACafé.Default;

        // ALORS aucune invocation du Brewer ou de la ChangeMachine n'est effectuée
        Assert.AucuneAction(changeMachine);
        Assert.AucunAppel(brewer);
    }

    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE une machine à café
        var (_, brewer, changeMachine) = LogicielMachineACafé.Default;

        // QUAND on insère une somme supérieure ou égale au prix d'un café
        changeMachine.SimulerInsertionPièce(CoinCode.FiftyCents);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.UnCaféServi(brewer);

        // ET l'argent est encaissé
        Assert.ArgentEncaissé(changeMachine);
    }

    [Fact]
    public void CasBrewerDéfaillant()
    {
        // ETANT DONNE une machine à café ayant un brewer défaillant
        var (_, _, changeMachine) = new LogicielMachineACafé()
            .AyantUnBrewerDéfaillant()
            .Build();

        // QUAND on insère une somme supérieure ou égale au prix d'un café
        changeMachine.SimulerInsertionPièce(CoinCode.FiftyCents);

        // ALORS l'argent est restitué
        Assert.ArgentRestitué(changeMachine);
    }

    [Fact]
    public void PasAssezArgent()
    {
        // ETANT DONNE une machine à café
        var (_, brewer, changeMachine) = LogicielMachineACafé.Default;

        // QUAND on insère moins que le prix d'un café
        changeMachine.SimulerInsertionPièce(CoinCode.TwentyCents);

        // ALORS MakeACoffee n'est pas appelé
        Assert.AucunAppel(brewer);

        // ET l'argent est restitué
        Assert.ArgentRestitué(changeMachine);
    }
}