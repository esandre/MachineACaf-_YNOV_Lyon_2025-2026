using MachineACafé.Test.Utilities;

namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void AucuneAction()
    {
        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var brewer = new BrewerSpy(new BrewerStub());

        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachine)
            .AyantUnBrewer(brewer)
            .Build();

        // ALORS aucune invocation du Brewer ou de la ChangeMachine n'est effectuée
        Assert.True(changeMachine.Untouched);
        Assert.True(brewer.Untouched);
    }

    [Fact]
    public void CasNominal()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var brewer = new BrewerSpy(new BrewerStub());
        var machine = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachine)
            .AyantUnBrewer(brewer)
            .Build();

        // QUAND on insère 40cts
        machine.Insérer(prixDuCafé);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.Equal(1, brewer.MakeACoffeeInvocations);

        // ET CollectStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyInvocations);

        // ET FlushStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachine.FlushStoredMoneyInvocations);
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

        // ALORS FlushStoredMoney est appelé une fois
        Assert.Equal(1, changeMachine.FlushStoredMoneyInvocations);

        // ET CollectStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachine.CollectStoredMoneyInvocations);
    }

    [Fact]
    public void PasAssezArgent()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var brewer = new BrewerSpy(new BrewerStub());
        var machine = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachine)
            .AyantUnBrewer(brewer)
            .Build();

        // QUAND on insère moins que le prix d'un café
        machine.Insérer(prixDuCafé - 1);

        // ALORS MakeACoffee n'est pas appelé
        Assert.Equal(0, brewer.MakeACoffeeInvocations);

        // ET CollectStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachine.CollectStoredMoneyInvocations);

        // ET FlushStoredMoney est appelé une fois
        Assert.Equal(1, changeMachine.FlushStoredMoneyInvocations);
    }

    [Fact]
    public void TropArgent()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var brewer = new BrewerSpy(new BrewerStub());
        var machine = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachine)
            .AyantUnBrewer(brewer)
            .Build();

        // QUAND on insère plus que le prix d'un café
        machine.Insérer(prixDuCafé + 1);

        // ALORS MakeACoffee est appelé une fois
        Assert.Equal(1, brewer.MakeACoffeeInvocations);

        // ET CollectStoredMoney est appelé une fois
        Assert.Equal(1, changeMachine.CollectStoredMoneyInvocations);

        // ET FlushStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachine.FlushStoredMoneyInvocations);
    }
}