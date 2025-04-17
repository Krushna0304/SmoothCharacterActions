
using UnityEngine;

public class IdleState : BaseState
{
    [HideInInspector] public float speed = 3f;
    public override void EnterState(StateManager state)
    {
        state.speed = this.speed;
        state.motionAnimator.SetTrigger("Idle");
    }

    public override void UpdateState(StateManager state)
    {
        if (state.xInput > 0 || state.yInput > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                state.SwitchState(state.runState);
            else if(Input.GetKey(KeyCode.LeftControl))
                state.SwitchState(state.crouchState);
            else
                state.SwitchState(state.walkState);
        }
    }
    public override void ExitState(StateManager state)
    {

    }

}
