using System.Text.Json.Serialization;

namespace LoanCalculator.Common.ValueObjects;

/// <summary>
/// Strongly typed Money. Value is decimal.
/// </summary>
[JsonSerializable(typeof(Money))]
public sealed class Money : ValueObjectBase
{
    public decimal Value { get; private set; }

    public Money() { }

    public Money(decimal value)
    {
        Value = UseBankersRounding(value);
    }

    public Money(long value)
    {
        Value = UseBankersRounding(Convert.ToDecimal(value));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString()
        => '$' + Value.ToString("#,##0.00");

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ValueObjectException"></exception>
    public static Money operator +(Money money, object value)
        => (value is Money valueMoney) ? new(money.Value + valueMoney.Value)
            : (value is decimal valueDecimal) ? new(money.Value + valueDecimal)
            : (value is int valueInt) ? new(money.Value + valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Addition);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ValueObjectException"></exception>
    public static Money operator -(Money money, object value)
        => (value is Money valueMoney) ? new(money.Value - valueMoney.Value)
            : (value is decimal valueDecimal) ? new(money.Value - valueDecimal)
            : (value is int valueInt) ? new(money.Value - valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Subtraction);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// ***Note: Applies Banker's Rounding to Value.***
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Money operator *(Money money, object value)
        => (value is PercentageRate valuePercent) ? new(money.Value * (valuePercent.Value / 100))
            : (value is decimal valueDecimal) ? new(money.Value * valueDecimal)
            : (value is int valueInt) ? new(money.Value * valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Multiplication);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// ***Note: Applies Banker's Rounding to Value.***
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Money operator /(Money money, object value)
        => (value is PercentageRate valuePercent) ? new(money.Value / (valuePercent.Value / 100))
            : (value is decimal valueDecimal) ? new(money.Value / valueDecimal)
            : (value is int valueInt) ? new(money.Value / valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Multiplication);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// ***Note: Applies Banker's Rounding to Value.***
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool operator >(Money money, object value)
        => (value is Money valueMoney) ? money.Value > valueMoney.Value
            : (value is decimal valueDecimal) ? money.Value > valueDecimal
            : (value is int valueInt) && money.Value > valueInt;

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// ***Note: Applies Banker's Rounding to Value.***
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool operator <(Money money, object value)
        => (value is Money valueMoney) ? money.Value < valueMoney.Value
            : (value is decimal valueDecimal) ? money.Value < valueDecimal
            : (value is int valueInt) && money.Value < valueInt;

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// ***Note: Applies Banker's Rounding to Value.***
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool operator >=(Money money, object value)
        => (value is Money valueMoney) ? money.Value >= valueMoney.Value
            : (value is decimal valueDecimal) ? money.Value >= valueDecimal
            : (value is int valueInt) && money.Value >= valueInt;

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// ***Note: Applies Banker's Rounding to Value.***
    /// </summary>
    /// <param name="money"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool operator <=(Money money, object value)
        => (value is Money valueMoney) ? money.Value <= valueMoney.Value
            : (value is decimal valueDecimal) ? money.Value <= valueDecimal
            : (value is int valueInt) && money.Value <= valueInt;

    /// <summary>
    /// Overly-explicit declaration of rounding rules.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static decimal UseBankersRounding(decimal value)
        => Math.Round(value, 2, MidpointRounding.ToEven);
}
