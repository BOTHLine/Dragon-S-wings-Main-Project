using UnityEngine;


public class StatemachineManager : MonoBehaviour
{
    public StatemachineState CurrentState;

    public Statemachine Statemachine;

    private void Update()
    {
        //   _CurrentState.CheckTransitions(this);
    }

    public void ChangeState(StatemachineState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void TryTransition(StatemachineState newState)
    {
        for (int i = 0; i < Statemachine.TransitionList.Length; i++)
        {
            if (Statemachine.TransitionList[i].State == CurrentState)
            {
                for (int j = 0; j < Statemachine.TransitionList[i].Transitions.Length; j++)
                {
                    if (!Statemachine.TransitionList[i].Transitions[j].NeedCondition && Statemachine.TransitionList[i].Transitions[j].TargetState == newState)
                        ChangeState(newState);
                }
            }
        }
    }
}