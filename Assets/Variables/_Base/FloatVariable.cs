using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable", fileName = "New Float Variable")]
public class FloatVariable : BaseVariable<float>
{
    public void ApplyChange(float amount) { Value += amount; }
    public void ApplyChange(FloatVariable amount) { Value += amount.Value; }
}