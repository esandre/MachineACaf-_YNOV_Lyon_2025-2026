using MachineACafé.Test.Utilities.TestDoubles;

#pragma warning disable IDE0130
namespace Xunit;
#pragma warning restore IDE0130

// ReSharper disable once ClassNeverInstantiated.Global
partial class Assert
{
    internal static void ArgentRestitué(ChangeMachineSpy changeMachineSpy)
    {
        Equal(0, changeMachineSpy.CollectStoredMoneyInvocations);
        Equal(1, changeMachineSpy.FlushStoredMoneyInvocations);
    }

    internal static void ArgentEncaissé(ChangeMachineSpy changeMachineSpy)
    {
        Equal(1, changeMachineSpy.CollectStoredMoneyInvocations);
        Equal(0, changeMachineSpy.FlushStoredMoneyInvocations);
    }
}