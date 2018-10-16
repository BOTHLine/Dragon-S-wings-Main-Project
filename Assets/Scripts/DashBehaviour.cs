using UnityEngine;

public class DashBehaviour : StatemachineBehaviour
{
    // Components
    private Rigidbody2D _Rigidbody2D;
    private StatemachineManager _StatemachineManager;

    // Variables
    [SerializeField] private FloatReference _DashSpeed;

    [SerializeField] private Vector2Reference _StartPosition;
    [SerializeField] private Vector2Reference _TargetPosition;

    [SerializeField] private StatemachineState _TargetStateWhenFinished;

    // Events
    public GameEvent OnDashStart;
    public GameEvent OnDashEnd;

    // Coroutines
    private System.Collections.IEnumerator _DashRoutine;

    // Methods
    private void Awake()
    {
        _Rigidbody2D = GetComponentInParent<Rigidbody2D>();
        _StatemachineManager = GetComponentInParent<StatemachineManager>();
    }

    private System.Collections.IEnumerator DashRoutine()
    {
        Vector2 start = _StartPosition;
        Vector2 destination = _TargetPosition;
        Vector2 direction = (destination - start).normalized;


        OnDashStart.Raise();

        do
        {
            _Rigidbody2D.velocity = direction * _DashSpeed;
            yield return new WaitForFixedUpdate();
        } while ((destination - start).sqrMagnitude > (_StartPosition - start).sqrMagnitude);

        OnDashEnd.Raise();
        _StatemachineManager.ChangeState(_TargetStateWhenFinished);
    }

    public override void StartBehaviour()
    {
        _DashRoutine = DashRoutine();
        StartCoroutine(_DashRoutine);
    }

    public override void Behave() { /* Empty  */}

    public override void EndBehaviour() {   /* Empty */ }
}