using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Statemachine", fileName = "New Statemachine")]
public class Statemachine : ScriptableObject
{
    public StatemachineTransitionList[] TransitionList;
}