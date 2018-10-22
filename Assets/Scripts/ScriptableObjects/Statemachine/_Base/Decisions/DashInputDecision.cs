using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Decisions/Dash Input Decision")]
public class DashInputDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.canDash && Input.GetKeyDown(KeyCode.Space);
    }
}