using UnityEngine;

public class EntityDash : MonoBehaviour
{
    // Components
    private Rigidbody2D Rigidbody2D;

    // Variables
    public Vector2Reference PlayerPosition;

    public Vector2Reference Target;

    public BoolReference CanDash;

    public FloatReference Speed;

    public bool EndDash { get; set; } = false;

    // Events
    public GameEvent OnDashStart;
    public GameEvent OnDashEnd;

    // Coroutines
    private System.Collections.IEnumerator _DashRoutine;

    // Methods
    private void Awake() { Rigidbody2D = GetComponentInParent<Rigidbody2D>(); }

    public void TryDash()
    {
        if (CanDash)
        {
            _DashRoutine = DashRoutine();
            StartCoroutine(_DashRoutine);
        }
    }

    private System.Collections.IEnumerator DashRoutine()
    {
        CanDash.Variable.Value = false;

        Vector2 start = PlayerPosition;
        Vector2 destination = Target;
        Vector2 direction = (destination - start).normalized;

        

        OnDashStart.Raise();

        do
        {
            Rigidbody2D.velocity = direction * Speed;
            yield return new WaitForFixedUpdate();
        } while ((destination - start).sqrMagnitude > (PlayerPosition - start).sqrMagnitude);

        OnDashEnd.Raise();
        CanDash.Variable.Value = true;
    }
}