using UnityEngine;

[System.Serializable]
public class BoolCondition : BaseCondition
{
    public BoolReference _Value;

    public CompareOperator _ComparisonOperator;

    public BoolReference _ComparisonValue;

    public override bool IsTrue
    {
        get
        {
            switch (_ComparisonOperator)
            {
                case CompareOperator.Equals: return _Value.Value == _ComparisonValue.Value;
                case CompareOperator.NotEquals: return _Value.Value != _ComparisonValue.Value;
                case CompareOperator.Less: return _Value < _ComparisonValue;
                case CompareOperator.Greater: return _Value > _ComparisonValue;
                case CompareOperator.LessEquals: return _Value <= _ComparisonValue;
                case CompareOperator.GreaterEquals: return _Value >= _ComparisonValue;
                default: return false;
            }
        }
    }

    public override void Initialize()
    {
        _Value.Variable.OnValueChange += CheckCondition;
        _ComparisonValue.Variable.OnValueChange += CheckCondition;
    }

    public void CheckCondition(bool newValue) { if (_WasTrue && IsTrue) { OnConditionMet.Raise(); } }
}