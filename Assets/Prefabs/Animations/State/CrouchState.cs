using UnityEngine;

public class CrouchState : BaseState
{
    [HideInInspector] public float speed = 3f;
    public override void EnterState(StateManager state)
    {
        state.speed = this.speed;
        state.motionAnimator.SetBool("Crouch", true);
    }

    public override void UpdateState(StateManager state)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            state.motionAnimator.SetBool("Crouch", false);
            state.SwitchState(state.runState);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            state.motionAnimator.SetBool("Crouch", false);
            state.SwitchState(state.walkState);
        }
    }
    public override void ExitState(StateManager state)
    {

    }
}
