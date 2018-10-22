using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/Move Action")]
public class MoveAction : Action
{
    public Vector2Reference moveDirection;
    public FloatReference moveSpeed;

    // TODO Vector2Reference moveDirection

    public override void Act(StateController controller)
    {
        controller.rigidbody2D.AddForce(moveDirection.Value * moveSpeed);
    }

    public override void EnterState(StateController controller) { controller.canDash = true; }
    public override void ExitState(StateController controller)
    {
        controller.rigidbody2D.velocity = Vector2.zero;
        // TODO Set LastSavePosition as Vector2Reference;
    }
}