using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/Pull Action")]
public class PullAction : Action
{
    public FloatReference pullSpeed;
    public Vector2Reference playerPosition;
    public Vector2Reference hookPosition;

    public override void Act(StateController controller)
    {
        controller.rigidbody2D.velocity = (hookPosition - playerPosition).normalized * pullSpeed;
    }

    public override void EnterState(StateController controller)
    {
        controller.rigidbody2D.velocity = (hookPosition - playerPosition).normalized * pullSpeed;
    }

    public override void ExitState(StateController controller) { }
}