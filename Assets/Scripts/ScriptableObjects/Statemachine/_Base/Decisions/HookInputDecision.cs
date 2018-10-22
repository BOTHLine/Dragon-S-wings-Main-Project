using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Decisions/Hook Input Decision")]
public class HookInputDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }
}