using FsCheck;
using FsCheck.Fluent;
using FsCheck.Xunit;

namespace MachineACafé.Test;

public class CoinTest
{
    private static Gen<ushort> ValidCoinValueGen =>
        Gen.Elements(Coin.ValidValues.ToArray());

    [Property]
    public Property ValidValuesDoNotThrow() =>
        Prop.ForAll(ValidCoinValueGen.ToArbitrary(), value =>
        {
            _ = new Coin(value);
            return true;
        });

    private static readonly Gen<ushort> InvalidCoinValueGenerator = Gen.Choose(0, ushort.MaxValue)
        .Select(i => (ushort)i)
        .Where(x => !Coin.ValidValues.Contains(x));

    [Property]
    public Property InvalidValuesThrows() =>
        Prop.ForAll(InvalidCoinValueGenerator.ToArbitrary(), value =>
        {
            try
            {
                _ = new Coin(value);
                return false;
            }
            catch
            {
                return true;
            }
        });
}