using Xunit.Internal;

namespace MachineACafé.Test;

public class CoinTest
{
    private static readonly ushort[] PiècesValides = [1, 2, 5, 10, 20, 50, 100, 200];

    public static TheoryData<ushort> CasValidCoinValues() 
        => new(PiècesValides);

    [Theory]
    [MemberData(nameof(CasValidCoinValues))]
    public void ValidCoinValues(ushort valueInCents)
    {
        Assert.Equal(valueInCents, new Coin(valueInCents).ValueInCents);
    }

    public static TheoryData<ushort> CasInvalidCoinValues()
    {
        var validValues = new HashSet<ushort>(PiècesValides);

        var invalidValuesToTest = new HashSet<ushort>();
        invalidValuesToTest.AddRange(validValues.Select(valid => (ushort) (valid + 1)));
        invalidValuesToTest.AddRange(validValues.Select(valid => (ushort) (valid - 1)));

        invalidValuesToTest.Remove(0);
        invalidValuesToTest.RemoveWhere(validValues.Contains);

        ushort randomValue;

        do
        {
            randomValue = (ushort)Random.Shared.Next(0, ushort.MaxValue);
        } while (validValues.Contains(randomValue) || invalidValuesToTest.Contains(randomValue));

        invalidValuesToTest.Add(randomValue);
        invalidValuesToTest.Add(ushort.MaxValue);

        return new TheoryData<ushort>(invalidValuesToTest);
    }

    [Theory]
    [MemberData(nameof(CasInvalidCoinValues))]
    public void InvalidCoinValues(ushort valueInCents)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Coin(valueInCents));
    }
}