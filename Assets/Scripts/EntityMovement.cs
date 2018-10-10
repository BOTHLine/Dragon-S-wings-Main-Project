using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    // Components
    private Rigidbody2D Rigidbody2D;

    // Variables
    public BoolReference CanMove;
    public FloatReference Speed;

    public Vector2Reference direction;

    // Events
    // Coroutines

    //Methods
    private void Awake() { Rigidbody2D = GetComponentInParent<Rigidbody2D>(); }

    private void FixedUpdate() { Move(); }

    public void Move() { if (CanMove) Rigidbody2D.velocity = direction.Value * Speed; }
}