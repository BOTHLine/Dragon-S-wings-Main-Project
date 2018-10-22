using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Actions/Respawn Action")]
public class RespawnAction : Action
{
    public Vector2Reference lastSavePosition;
    public Vector2Reference health;

    public override void Act(StateController controller) { }

    public override void EnterState(StateController controller)
    {
        // TODO Set Position to LastSavePosition Vector2Reference;
    }

    public override void ExitState(StateController controller) { }
}