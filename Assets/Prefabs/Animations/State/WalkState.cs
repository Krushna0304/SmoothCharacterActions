using UnityEngine;

public class WalkState : BaseState
{

    [HideInInspector] public float speed = 4f;
    public override void EnterState(StateManager state)
    {
        state.speed = this.speed;
        state.motionAnimator.SetBool("Walk",true);
    }

    public override void UpdateState(StateManager state)
    {
        /* if (state.xInput == 0 && state.yInput == 0)
         {
             state.SwitchState(state.idleState);
         }

         else 
         {*/
        if (Input.GetKey(KeyCode.LeftShift))
        {
            state.motionAnimator.SetBool("Walk", false);
            state.SwitchState(state.runState);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            state.motionAnimator.SetBool("Walk", false);
            state.SwitchState(state.crouchState);
        }
        //}
    }
    public override void ExitState(StateManager state)
    {

    }
}
