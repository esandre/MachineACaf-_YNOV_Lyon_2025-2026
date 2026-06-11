using Hardware;

namespace MachineACafé.Test.Utilities.TestDoubles;

public static class ChangeMachineFakeExtensions 
{
    public static void SimulerInsertionPièce(this IChangeMachine changeMachine, CoinCode fiftyCents)
    {
        var changeMachineFake = changeMachine as ChangeMachineFake 
                                ?? throw new InvalidOperationException("Must be a " + nameof(ChangeMachineFake));

        changeMachineFake.SimulerInsertionPièce(fiftyCents);
    }
}

public class ChangeMachineFake : IChangeMachine
{
    private Action<CoinCode>? _callback;

    public virtual void RegisterMoneyInsertedCallback(Action<CoinCode> callback)
    {
        if (_callback != null) throw new NotSupportedException();
        _callback = callback;
    }

    public virtual void FlushStoredMoney()
    {
    }

    public virtual void CollectStoredMoney()
    {
    }

    public virtual bool DropCashback(CoinCode coinCode)
    {
        throw new NotImplementedException();
    }

    public virtual void SimulerInsertionPièce(CoinCode fiftyCents)
    {
        _callback?.Invoke(fiftyCents);
    }
}