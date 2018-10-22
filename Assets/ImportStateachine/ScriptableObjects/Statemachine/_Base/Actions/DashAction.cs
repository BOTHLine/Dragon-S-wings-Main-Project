using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/Dash Action")]
public class DashAction : Action
{
    public float dashRange;
    public float dashSpeed;

    // TODO Vector2Reference
    public Vector2 startPosition;
    public Vector2 targetPosition;
    public float distanceThreshold = 0.01f;

    private Vector2 start;
    private Vector2 direction;
    private Vector2 destination;

    private float startTime;
    private float trueDashDistance;
    private float totalDashDistance;

    public override void Act(StateController controller)
    {
        /*
        controller.rigidbody2D.velocity = direction * dashSpeed;

        controller.stateActionFinished = ReachedDestination(controller);
        */

        float distanceCovered = (Time.time - startTime) * dashSpeed;
        float fractalDistance = distanceCovered / totalDashDistance;

        controller.rigidbody2D.MovePosition(Vector2.Lerp(start, destination, fractalDistance));

        controller.stateActionFinished = ReachedDestination(controller);
    }

    public override void EnterState(StateController controller)
    {
        start = controller.transform.position;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startTime = Time.time;

        totalDashDistance = (destination - start).magnitude;
        trueDashDistance = Mathf.Min(dashRange, totalDashDistance);

        /*
        controller.canDash = false;

        // TODO Take Vector2Reference
        startPosition = controller.transform.position;
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //

        start = startPosition;
        Vector2 targetVector = targetPosition - startPosition;
        direction = targetVector.normalized;

        if ((dashRange * dashRange) >= targetVector.sqrMagnitude)
            destination = targetPosition;
        else
            destination = start + direction * dashRange;
            */
    }

    public override void ExitState(StateController controller) { controller.rigidbody2D.velocity = Vector2.zero; }

    private bool ReachedDestination(StateController controller) { return ((Vector2)controller.transform.position - start).sqrMagnitude + distanceThreshold >= trueDashDistance * trueDashDistance; }
}