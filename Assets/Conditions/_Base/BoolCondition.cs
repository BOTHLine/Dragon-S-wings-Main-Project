using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Bool Condition", fileName = "New Bool Condition")]
public class BoolCondition : ScriptableObject, BaseCondition
{
    public BoolReference _Value;
    public BoolReference _ComparisonValue;

    public bool IsTrue { get { return _Value.Value == _ComparisonValue.Value; } }
}