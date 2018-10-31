using UnityEngine;

public class Enemy : MonoBehaviour, Hookable, Aimable
{
    [SerializeField] private Weight weight;
    public Weight Weight { get { return weight; } }

    public GameEvent OnHookHitLightEnemy;
    public GameEvent OnHookHitMediumEnemy;
    public GameEvent OnHookHitHeavyEnemy;

    public void HookHit()
    {
        switch (weight)
        {
            case Weight.Light:
                OnHookHitLightEnemy.Raise();
                break;
            case Weight.Medium:
                OnHookHitMediumEnemy.Raise();
                break;
            case Weight.Heavy:
                OnHookHitHeavyEnemy.Raise();
                break;
        }
    }
}