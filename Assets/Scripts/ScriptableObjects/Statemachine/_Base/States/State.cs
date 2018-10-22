using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/State")]
public class State : ScriptableObject
{
    public int layer;

    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (transitions[i].decision.Decide(controller))
                controller.TransitionToState(transitions[i].trueState);
            else
                controller.TransitionToState(transitions[i].falseState);
        }
    }

    public void EnterState(StateController controller)
    {
        controller.gameObject.layer = layer;
        controller.stateActionFinished = false;

        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].EnterState(controller);
        }
    }

    public void ExitState(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].ExitState(controller);
        }
    }
}