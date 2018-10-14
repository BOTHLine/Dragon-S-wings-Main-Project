using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    // Components
    private Rigidbody2D Rigidbody2D;

    // Variables
    [SerializeField] private FloatReference _MoveSpeed;

    [SerializeField] private BoolReference _CanMove;
    [SerializeField] private Vector2Reference _MoveDirection;

    // Events
    // Coroutines

    //Methods
    private void Awake() { Rigidbody2D = GetComponentInParent<Rigidbody2D>(); }

    private void FixedUpdate() { Move(); }

    public void Move() { if (_CanMove) Rigidbody2D.velocity = _MoveDirection.Value * _MoveSpeed; }
}