using System.Text;

namespace LoanCalculator.Common.ValueObjects;

/// <summary>
/// For Handling of ValueObjectException Messages.
/// </summary>
public enum ValueObjectOperation
{
    Unknown,
    Addition,
    Subtraction,
    Multiplication,
    Division
}

/// <summary>
/// For now it's only used for ValueObject mathematical functions.
/// </summary>
public class ValueObjectException : InvalidOperationException
{
    public string Message { get; init; }

    public ValueObjectException(ValueObjectOperation operationType) : base()
    {
        Message = $"The type of this value cannot be {SetExceptionMessage(operationType)} a PercentageRate.";
    }

    private static string SetExceptionMessage(ValueObjectOperation operationType) => operationType switch
    {
        ValueObjectOperation.Addition => "added to",
        ValueObjectOperation.Subtraction => "subtracted from",
        ValueObjectOperation.Multiplication => "multiplied with",
        ValueObjectOperation.Division => "the divisor of",
        ValueObjectOperation.Unknown => String.Empty,
        _ => String.Empty
    };
}
