using UnityEngine;

[System.Serializable]
public class StatemachineTransition
{
    public bool NeedCondition;
    public BaseCondition Condition;
    public StatemachineState TargetState;
}