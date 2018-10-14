using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Hook : MonoBehaviour
{
    public class AnchorPoint
    {
        public Transform ParentTransform;
        public Vector2 Position { get { return ((Vector2)ParentTransform.position + LocalPosition); } }
        public Vector2 LocalPosition;
        public float RequiredRopeLength;
        public bool Angle;

        public AnchorPoint(Transform parentTransform, Vector2 localPosition, Vector2 lastPosition, bool angle)
        {
            ParentTransform = parentTransform;
            LocalPosition = localPosition;
            RequiredRopeLength = Vector2.Distance(Position, lastPosition);
            Angle = angle;
        }

        public AnchorPoint(Transform parentTransform, Vector2 localPosition)
        {
            ParentTransform = parentTransform;
            LocalPosition = localPosition;
        }
    }

    private SpriteRenderer _SpriteRenderer;
    private Rigidbody2D _Rigidbody2D;
    private PolygonCollider2D _PolygondCollider2D;

    [SerializeField] private FloatReference _MaxHookRange;
    [SerializeField] private FloatReference _MaxRopeLength;
    [SerializeField] private FloatReference _HookSpeed;

    [SerializeField] private BoolReference _CanHook;
    [SerializeField] private Vector2Reference _StartPosition;
    [SerializeField] private Vector2Reference _TargetPosition;

    [SerializeField] private BoolReference _IsHookFlying;
    [SerializeField] private BoolReference _IsHookClipped;

    //    [SerializeField] private LayerMask _LayerMask;

    [SerializeField] private GameEvent _OnHookShoot;
    [SerializeField] private GameEvent _OnHookHit;

    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _PolygondCollider2D = GetComponent<PolygonCollider2D>();
        //    CreateLayerMask();

        _SpriteRenderer.enabled = false;
        _PolygondCollider2D.enabled = false;
    }

    private void FixedUpdate()
    {
        if (_IsHookFlying && Vector2.Distance(_TargetPosition, _StartPosition) > _MaxHookRange)
            ResetHook();
    }

    /*
    private void CreateLayerMask()
    {
        _LayerMask = 0;
        int layer = gameObject.layer;

        //   for (int i = 0)
    }
    */

    public void Shoot()
    {
        if (!_CanHook)
            return;

        _CanHook.Variable.Value = false;
        _OnHookShoot.Raise();

        LookAt(_TargetPosition);

        _PolygondCollider2D.enabled = true;
        _SpriteRenderer.enabled = true;

        _Rigidbody2D.MovePosition(_StartPosition);
        _Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _Rigidbody2D.velocity = (_TargetPosition - _StartPosition).normalized * _HookSpeed;
    }

    private void ResetHook()
    {
        _PolygondCollider2D.enabled = false;
        _SpriteRenderer.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _OnHookHit.Raise();
        _Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _Rigidbody2D.velocity = Vector2.zero;
        _Rigidbody2D.angularVelocity = 0.0f;
    }

    private void LookAt(Vector2 targetPosition)
    {
        Vector2 targetDirection = (targetPosition - (Vector2)transform.position).normalized;
        float zRotation = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, zRotation - 90.0f);
    }
}