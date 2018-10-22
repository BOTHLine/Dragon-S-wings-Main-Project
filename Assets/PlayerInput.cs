using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2Reference moveDirection;
    public FloatReference deadValue;

    private void Update()
    {
        moveDirection.Variable.Value = new Vector2(GetAxis("AxisX", deadValue), -GetAxis("AxisY", deadValue));
    }

    private float GetAxis(string name, float dead)
    {
        float value = Input.GetAxisRaw(name);
        if (Mathf.Abs(value) < dead)
            value = 0.0f;
        return value;
    }
}