using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    [HideInInspector] public float speed = 6f;
    public override void EnterState(StateManager state)
    {
        state.speed = this.speed;
        state.motionAnimator.SetBool("Run", true);
    }

    public override void UpdateState(StateManager state)
    {
       /* if (state.xInput == 0 && state.yInput == 0)
            state.SwitchState(state.idleState);
        else
        { */
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
            state.motionAnimator.SetBool("Run", false);
            state.SwitchState(state.walkState);
            }
        //}
    }
    public override void ExitState(StateManager state)
    {

    }
}
