using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/State", fileName = "New State")]
public class StatemachineState : ScriptableObject
{
    public GameEvent OnStateEnter;
    public GameEvent OnStateExit;

    public void EnterState()
    {
        OnStateEnter.Raise();
    }

    public void ExitState()
    {
        OnStateExit.Raise();
    }
}