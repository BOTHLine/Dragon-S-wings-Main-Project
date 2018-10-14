using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBrain : MonoBehaviour
{
    // Components

    // Variables
    [SerializeField] private Vector2Reference _PlayerPosition;
    [SerializeField] private Vector2Reference _MoveDirection;
    [SerializeField] private Vector2Reference _AimPosition;

    // Events
    [SerializeField] private GameEvent _OnDashInput;
    [SerializeField] private GameEvent _OnHookInput;

    // Coroutines

    // Methods
    private void Update()
    {
        _PlayerPosition.Variable.Value = transform.position;
        _MoveDirection.Variable.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _AimPosition.Variable.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space)) _OnDashInput.Raise();
        if (Input.GetKeyDown(KeyCode.Mouse0)) _OnHookInput.Raise();
    }
}