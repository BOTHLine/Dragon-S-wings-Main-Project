using UnityEngine;

public interface BaseCondition
{
    bool IsTrue { get; }
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