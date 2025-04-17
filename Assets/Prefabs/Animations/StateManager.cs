using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    [HideInInspector]public Animator motionAnimator;

    BaseState currentstate;
    [HideInInspector] public IdleState idleState = new IdleState();
    [HideInInspector] public WalkState walkState = new WalkState();
    [HideInInspector] public RunState runState = new RunState();
    [HideInInspector] public CrouchState crouchState = new CrouchState();


    [HideInInspector] public float xInput,yInput;

    PlayerController controller;

    [HideInInspector]public float speed;
    void Start()
    {

        xInput = 0;
        yInput = 0;
        controller = GetComponent<PlayerController>();

        motionAnimator = GetComponent<Animator>();
        currentstate = walkState;
        currentstate.EnterState(this);

    }

    
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        currentstate.UpdateState(this);

        CheckJump();
    }

    public void SwitchState(BaseState state)
    {
        currentstate = state;
        currentstate.EnterState(this);
        controller.UpdateSpeed(speed);
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            motionAnimator.SetBool("Jump",true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            motionAnimator.SetBool("Jump", false);
        }
    }
}
