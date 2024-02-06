using System.Text.Json.Serialization;

namespace LoanCalculator.Common.ValueObjects;

/// <summary>
/// Strongly typed PercentageRate. Value is decimal.
/// ***Note: Calculations SHOULD divide the Value by 100, where required.***
/// </summary>
[JsonSerializable(typeof(PercentageRate))]
public sealed class PercentageRate : ValueObjectBase
{
    //[]
    public decimal Value { get; private set; }

    public PercentageRate() { }

    public PercentageRate(decimal value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString()
        => Value.ToString("#,###.00") + '%';

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="percentageRate"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool operator ==(PercentageRate percentageRate, object value)
        => percentageRate.Equals(value);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="percentageRate"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool operator !=(PercentageRate percentageRate, object value)
        => !percentageRate.Equals(value);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="percentageRate"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static PercentageRate operator +(PercentageRate percentageRate, object value)
        => (value is PercentageRate valuePercent) ? new(percentageRate.Value + valuePercent.Value) 
            : (value is decimal valueDecimal) ? new(percentageRate.Value + valueDecimal)
            : (value is int valueInt) ? new(percentageRate.Value + valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Addition);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="percentageRate"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static PercentageRate operator -(PercentageRate percentageRate, object value)
        => (value is PercentageRate valuePercent) ? new(percentageRate.Value - valuePercent.Value)
            : (value is decimal valueDecimal) ? new(percentageRate.Value - valueDecimal)
            : (value is int valueInt) ? new(percentageRate.Value - valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Subtraction);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="percentageRate"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static PercentageRate operator *(PercentageRate percentageRate, object value)
        => (value is PercentageRate valuePercent) ? new(percentageRate.Value * valuePercent.Value)
            : (value is decimal valueDecimal) ? new(percentageRate.Value * valueDecimal)
            : (value is int valueInt) ? new(percentageRate.Value * valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Subtraction);

    /// <summary>
    /// Value can be of type PercentageRate, decimal or int.
    /// </summary>
    /// <param name="percentageRate"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static PercentageRate operator /(PercentageRate percentageRate, object value)
        => (value is PercentageRate valuePercent) ? new(percentageRate.Value / valuePercent.Value)
            : (value is decimal valueDecimal) ? new(percentageRate.Value / valueDecimal)
            : (value is int valueInt) ? new(percentageRate.Value / valueInt)
            : throw new ValueObjectException(ValueObjectOperation.Subtraction);

    //TODO: Review; quite messy.
    public PercentageRate ToThePowerOf(int rateInt)
        => new(Math.Round(Convert.ToDecimal(Math.Pow(Decimal.ToDouble(this.Value), rateInt)), 
            2, MidpointRounding.ToEven));
}
