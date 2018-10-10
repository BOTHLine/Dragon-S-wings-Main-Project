using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBrain : MonoBehaviour
{
    // Components

    // Variables
    public Vector2Reference PlayerPosition;

    public Vector2Reference MoveDirection;

    public Vector2Reference AimTarget;

    // Events
    public GameEvent OnDashInput;

    // Coroutines

    // Methods
    private void Update()
    {
        PlayerPosition.Variable.Value = transform.position;

        MoveDirection.Variable.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        AimTarget.Variable.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space)) OnDashInput.Raise();
    }
}