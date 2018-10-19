using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/Move Action")]
public class MoveAction : Action
{
    public float movementSpeed;

    // TODO Vector2Reference moveDirection

    public override void Act(StateController controller)
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        controller.rigidbody2D.velocity = movement.normalized * movementSpeed;
    }

    public override void EnterState(StateController controller) { controller.canDash = true; }
    public override void ExitState(StateController controller)
    {
        controller.rigidbody2D.velocity = Vector2.zero;
        // TODO Set LastSavePosition as Vector2Reference;
    }
}