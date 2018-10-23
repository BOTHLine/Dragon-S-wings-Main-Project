using UnityEngine;

public abstract class BaseCondition
{
    protected bool _WasTrue;

    [SerializeField] protected GameEvent OnConditionMet;

    public abstract bool IsTrue { get; }

    public abstract void Initialize();
}