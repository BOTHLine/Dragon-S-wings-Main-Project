using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Variables
    public FloatReference deadValue;

    public Vector2Reference moveDirection;
    public Vector2Reference aimDirection;

    private System.Collections.Generic.Dictionary<string, bool> isAxisInUse;

    // Events
    public GameEvent OnHookInput;

    // Mono Behaviour
    private void Awake()
    {
        isAxisInUse = new System.Collections.Generic.Dictionary<string, bool>();
    }

    private void Update()
    {
        moveDirection.Variable.Value = GetAxis2D("AxisX", "AxisY");
        aimDirection.Variable.Value = GetAxis2D("Axis4", "Axis5");

        if (GetAxisDown("Axis10")) { OnHookInput.Raise(); }
    }

    // Methods
    private float GetAxis(string name, float dead)
    {
        float value = Input.GetAxisRaw(name);
        if (Mathf.Abs(value) < dead)
        {
            isAxisInUse.Remove(name);
            return 0.0f;
        }
        else
        {
            isAxisInUse[name] = true;
            return value;
        }
    }

    private float GetAxis(string name)
    {
        return GetAxis(name, deadValue);
    }

    private Vector2 GetAxis2D(string nameX, string nameY)
    {
        Vector2 Axis2D = new Vector2(GetAxis(nameX), -GetAxis(nameY));
        float magnitudeFactor = Axis2D.magnitude;
        if (magnitudeFactor > 1)
            return new Vector2(Axis2D.x / magnitudeFactor, Axis2D.y / magnitudeFactor);
        return Axis2D;
    }

    private bool GetAxisDown(string name, float dead)
    {
        bool value = false;
        value = isAxisInUse.TryGetValue(name, out value);

        if (Mathf.Abs(Input.GetAxisRaw(name)) >= dead)
        {
            isAxisInUse[name] = true;
            return (!value);
        }
        else
        {
            isAxisInUse.Remove(name);
        }
        return false;
    }

    private bool GetAxisDown(string name)
    {
        return GetAxisDown(name, deadValue);
    }
}