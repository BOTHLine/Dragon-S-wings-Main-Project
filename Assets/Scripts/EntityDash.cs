using UnityEngine;

public class EntityDash : MonoBehaviour
{
    // Components
    private Rigidbody2D Rigidbody2D;

    // Variables
    [SerializeField] private FloatReference _DashSpeed;

    [SerializeField] private BoolReference _CanDash;

    [SerializeField] private Vector2Reference _StartPosition;
    [SerializeField] private Vector2Reference _TargetPosition;

    [SerializeField] private bool EndDash { get; set; } = false;

    // Events
    public GameEvent OnDashStart;
    public GameEvent OnDashEnd;

    // Coroutines
    private System.Collections.IEnumerator _DashRoutine;

    // Methods
    private void Awake() { Rigidbody2D = GetComponentInParent<Rigidbody2D>(); }

    public void TryDash()
    {
        if (_CanDash)
        {
            _DashRoutine = DashRoutine();
            StartCoroutine(_DashRoutine);
        }
    }

    private System.Collections.IEnumerator DashRoutine()
    {
        _CanDash.Variable.Value = false;

        Vector2 start = _StartPosition;
        Vector2 destination = _TargetPosition;
        Vector2 direction = (destination - start).normalized;



        OnDashStart.Raise();

        do
        {
            Rigidbody2D.velocity = direction * _DashSpeed;
            yield return new WaitForFixedUpdate();
        } while ((destination - start).sqrMagnitude > (_StartPosition - start).sqrMagnitude);

        OnDashEnd.Raise();
        _CanDash.Variable.Value = true;
    }
}