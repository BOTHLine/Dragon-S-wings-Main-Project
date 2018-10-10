using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Float Condition", fileName = "New Float Condition")]
public class FloatCondition : ScriptableObject, BaseCondition
{
    public FloatReference _Value;

    public ComparisonOperator _ComparisonOperator;

    public FloatReference _ComparisonValue;

    public bool IsTrue
    {
        get
        {
            switch (_ComparisonOperator)
            {
                case ComparisonOperator.Equals: return _Value.Value == _ComparisonValue.Value;
                case ComparisonOperator.NotEquals: return _Value.Value != _ComparisonValue.Value;
                case ComparisonOperator.Less: return _Value.Value < _ComparisonValue.Value;
                case ComparisonOperator.Greater: return _Value.Value > _ComparisonValue.Value;
                case ComparisonOperator.LessEquals: return _Value.Value <= _ComparisonValue.Value;
                case ComparisonOperator.GreaterEquals: return _Value.Value >= _ComparisonValue.Value;
                default: return false;
            }
        }
    }
}