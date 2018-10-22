using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class StateController : MonoBehaviour
{
    // Components
    [HideInInspector] new public Rigidbody2D rigidbody2D;
    [HideInInspector] public CircleCollider2D circleCollider2D;

    // Variables
    public State currentState;
    public State remainState;

    public bool stateActionFinished = false;

    [HideInInspector] public bool canDash = true;

    // Methods
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState == remainState)
            return;

        currentState.ExitState(this);
        currentState = nextState;
        currentState.EnterState(this);
    }

    public void Respawn()
    {
        // TODO Set Position to LastSavePosition Vector2Reference;
    }
}