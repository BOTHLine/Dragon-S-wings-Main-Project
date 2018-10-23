using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public FloatReference aimRange;
    public Vector2Reference aimDirection;
    public Vector2Reference aimPosition;

    private void Update()
    {
        transform.localPosition = aimDirection.Value * aimRange;
        aimPosition.Variable.Value = transform.position;
    }
}