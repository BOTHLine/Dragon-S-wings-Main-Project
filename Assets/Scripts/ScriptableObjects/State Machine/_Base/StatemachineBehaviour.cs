using UnityEngine;

public abstract class StatemachineBehaviour : MonoBehaviour
{
    public abstract void StartBehaviour();
    public abstract void Behave();
    public abstract void EndBehaviour();
}