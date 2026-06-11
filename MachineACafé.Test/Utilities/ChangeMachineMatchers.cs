using Hardware;
using Moq;

#pragma warning disable IDE0130
namespace Xunit;
#pragma warning restore IDE0130

// ReSharper disable once ClassNeverInstantiated.Global
partial class Assert
{
    internal static void ArgentRestitué(IChangeMachine changeMachine)
    {
        var changeMachineSpy = Mock.Get(changeMachine);

        changeMachineSpy.Verify(m => m.CollectStoredMoney(), Times.Never);
        changeMachineSpy.Verify(m => m.FlushStoredMoney(), Times.Once);
    }

    internal static void ArgentEncaissé(IChangeMachine changeMachine)
    {
        var changeMachineSpy = Mock.Get(changeMachine);

        changeMachineSpy.Verify(m => m.CollectStoredMoney(), Times.Once);
        changeMachineSpy.Verify(m => m.FlushStoredMoney(), Times.Never);
    }

    /// <summary>
    /// Vérifie si aucune action n'a été effectuée sur le ChangeMachine.
    /// RegisterCallback ne compte pas comme action.
    /// </summary>
    internal static void AucuneAction(IChangeMachine changeMachine)
    {
        var changeMachineSpy = Mock.Get(changeMachine);

        changeMachineSpy.Verify(m => m.FlushStoredMoney(), Times.Never);
        changeMachineSpy.Verify(m => m.CollectStoredMoney(), Times.Never);
        changeMachineSpy.Verify(m => m.DropCashback(It.IsAny<CoinCode>()), Times.Never);
    }
}