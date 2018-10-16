using UnityEngine;

public abstract class BaseCondition : ScriptableObject
{
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