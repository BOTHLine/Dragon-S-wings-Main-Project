using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Decisions/Action Finished Decision")]
public class ActionFinishedDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.stateActionFinished;
    }
}