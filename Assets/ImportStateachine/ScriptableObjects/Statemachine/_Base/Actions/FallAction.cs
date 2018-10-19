﻿using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/Fall Action")]
public class FallAction : Action
{
    public float fallTime;
    private float currentFallTime;

    public override void Act(StateController controller)
    {
        currentFallTime += Time.deltaTime;
        if (currentFallTime >= fallTime)
            controller.stateActionFinished = true;
    }

    public override void EnterState(StateController controller) { currentFallTime = 0.0f; }
    public override void ExitState(StateController controller) { }
}