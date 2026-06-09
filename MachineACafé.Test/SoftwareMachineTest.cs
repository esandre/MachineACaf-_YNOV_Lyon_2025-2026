using Hardware;
using MachineACafé.Test.Utilities;

namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void CasNominal()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var machine = new SoftwareMachineBuilder().AyantUneChangeMachine(changeMachine).Build();

        // QUAND on insère 40cts
        machine.Insérer(prixDuCafé);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.Equal(1, machine.NombreCafésServis);

        // ET CollectStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyInvocations);
    }

    [Fact]
    public void CasBrewerDéfaillant()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café ayant un brewer défaillant
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());

        var machine = new SoftwareMachineBuilder()
            .AyantUnBrewer(new BrewerDummy())
            .AyantUneChangeMachine(changeMachine)
            .Build();

        // QUAND on insère 40cts
        machine.Insérer(prixDuCafé);

        // ALORS FlushStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.FlushStoredMoneyInvocations);
    }

    [Fact]
    public void TropArgent()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var machine = new SoftwareMachineBuilder().AyantUneChangeMachine(changeMachine).Build();

        // QUAND on insère plus que le prix d'un café
        machine.Insérer(prixDuCafé + 1);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.Equal(1, machine.NombreCafésServis);

        // ET CollectStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyInvocations);
    }
}