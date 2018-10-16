using UnityEngine;

[System.Serializable]
public struct StatemachineTransitionList
{
    public StatemachineState State;
    public StatemachineTransition[] Transitions;
}