using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/FallCheck Action")]
public class FallCheckAction : Action
{
    public FloatReference checkRadius;

    public FloatReference fallTime;
    private float currentFallTime;

    public GameEvent OnFallCheckFalse;

    public override void Act(StateController controller)
    {
        Collider2D coll = Physics2D.OverlapCircle(controller.transform.position, controller.circleCollider2D.radius, LayerList.FallCheck.LayerMask);
        if (!coll)
        {
            OnFallCheckFalse.Raise();
            return;
        }

        currentFallTime += Time.deltaTime;
        if (currentFallTime >= fallTime)
        {
            OnFallCheckFalse.Raise();
        }
    }

    public override void EnterState(StateController controller) { currentFallTime = 0.0f; }
    public override void ExitState(StateController controller) { }
}