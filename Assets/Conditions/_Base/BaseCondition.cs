using UnityEngine;

public abstract class BaseCondition<TReference, TVariable, TDatatype> : ScriptableObject
    where TReference : BaseReference<TVariable, TDatatype>
    where TVariable : BaseVariable<TDatatype>
{
    public TReference _Value;

    public ComparisonOperator _ComparisonOperator;

    public TReference _ComparisonValue;

    public abstract bool IsTrue { get; }

}

public enum ComparisonOperator
{
    Equals,
    NotEquals,
    Less,
    Greater,
    LessEquals,
    GreaterEquals
}