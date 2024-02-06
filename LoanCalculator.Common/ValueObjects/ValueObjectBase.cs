namespace LoanCalculator.Common.ValueObjects;

public abstract class ValueObjectBase : IEquatable<ValueObjectBase>
{
    public abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? otherObject)
        => otherObject is ValueObjectBase valueObject && Equals(valueObject);

    public bool Equals(ValueObjectBase? otherObject)
        => otherObject is not null && ValuesAreEqual(otherObject);

    public override int GetHashCode()
        => GetAtomicValues().Aggregate(default(int), HashCode.Combine);

    private bool ValuesAreEqual(ValueObjectBase? otherObject)
        => otherObject is not null
            && GetAtomicValues().SequenceEqual(otherObject.GetAtomicValues());
}
