using UnityEngine;

public class WallTest : MonoBehaviour, Hookable
{
    public GameEvent OnHookHitWall;

    public Weight Weight { get { return Weight.Heavy; } }

    public void HookHit()
    {
        Debug.Log("Test");
        OnHookHitWall.Raise();
    }
}