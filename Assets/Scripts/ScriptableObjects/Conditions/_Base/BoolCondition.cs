using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Bool Condition", fileName = "New Bool Condition")]
public class BoolCondition : BaseCondition
{
    public BoolReference _Value;

    public ComparisonOperator _ComparisonOperator;

    public BoolReference _ComparisonValue;

    public override bool IsTrue
    {
        get
        {
            switch (_ComparisonOperator)
            {
                case ComparisonOperator.Equals: return _Value.Value == _ComparisonValue.Value;
                case ComparisonOperator.NotEquals: return _Value.Value != _ComparisonValue.Value;
                case ComparisonOperator.Less: return _Value < _ComparisonValue;
                case ComparisonOperator.Greater: return _Value > _ComparisonValue;
                case ComparisonOperator.LessEquals: return _Value <= _ComparisonValue;
                case ComparisonOperator.GreaterEquals: return _Value >= _ComparisonValue;
                default: return false;
            }
        }
    }
}