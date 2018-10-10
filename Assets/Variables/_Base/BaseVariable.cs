using UnityEngine;

public abstract class BaseVariable<TDatatype> : ScriptableObject, ISerializationCallbackReceiver
{
    public TDatatype InitialValue;
    public TDatatype Value;

    public void SetValue(TDatatype value) { Value = value; }
    public void SetValue(BaseVariable<TDatatype> value) { Value = value.Value; }

    public void OnAfterDeserialize() { Value = InitialValue; }
    public void OnBeforeSerialize() { }
}