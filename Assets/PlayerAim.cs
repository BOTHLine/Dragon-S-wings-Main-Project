using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;

    public FloatReference aimRange;
    public Vector2Reference aimDirection;
    public Vector2Reference aimPosition;

    public FloatReference aimHelpRadius;

    private bool hasTarget;
    private Vector2 targetPosition;

    private ColliderDistance2D closestColliderDistance2D;

    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        transform.localPosition = aimDirection.Value * aimRange;
        aimPosition.Variable.Value = transform.position;

        FindClosestHookable();
    }

    private void FindClosestHookable()
    {
        hasTarget = false;

        if ((Vector2)transform.localPosition == Vector2.zero)
            return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, aimHelpRadius, LayerList.Hook.LayerMask);
        if (colliders.Length >= 1)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                Hookable hookable = colliders[i].GetComponent<Hookable>();
                if (hookable != null)
                {
                    if (!hasTarget)
                    {
                        closestColliderDistance2D = circleCollider2D.Distance(colliders[i]);
                        if (closestColliderDistance2D.isValid)
                        {
                            targetPosition = closestColliderDistance2D.pointB;
                            hasTarget = true;
                        }
                    }
                    else
                    {
                        ColliderDistance2D newColliderDistance2D = circleCollider2D.Distance(colliders[i]);
                        if (newColliderDistance2D.isValid && newColliderDistance2D.distance < closestColliderDistance2D.distance)
                        {
                            closestColliderDistance2D = newColliderDistance2D;
                            targetPosition = closestColliderDistance2D.pointB;
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if ((Vector2)transform.localPosition == Vector2.zero)
            UnityEditor.Handles.color = Color.red;
        else if (!hasTarget)
            UnityEditor.Handles.color = Color.yellow;
        else
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawLine(aimPosition.Value, targetPosition);
        }
        UnityEditor.Handles.DrawWireDisc(aimPosition.Value, Vector3.forward, aimHelpRadius);
    }
}