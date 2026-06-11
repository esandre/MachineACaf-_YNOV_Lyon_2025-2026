using System.Collections.Frozen;

namespace MachineACafé;

public record Coin
{
    public static readonly FrozenSet<ushort> ValidValues = [1, 2, 5, 10, 20, 50, 100, 200];

    public Coin(ushort valueInCents)
    {
        if (!ValidValues.Contains(valueInCents)) 
            throw new ArgumentOutOfRangeException(nameof(valueInCents));

        ValueInCents = valueInCents;
    }

    public ushort ValueInCents { get; }
}