using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Bool Condition", fileName = "New Bool Condition")]
public class BoolCondition : BaseCondition<BoolReference, BoolVariable, bool>
{
    public override bool IsTrue { get { return _Value.Value == _ComparisonValue.Value; } }
}