using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float yInput;
    CharacterController player;
    Animator animator;
    public float speed;

    private Vector3 velocity;
    private float gravity = -7.81f;
    public float offset;
    public LayerMask ground;

    public Transform followPoint;

    private Vector3 direction;
    private void Start()
    {
        velocity = Vector3.zero;
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            animator.SetTrigger("Run");
        animator.SetFloat("xInput", xInput);
        animator.SetFloat("yInput", yInput);

        Vector3 dir = CameraController.direction * yInput + followPoint.right * xInput;

        player.Move(Time.deltaTime * speed * dir);

        ApplyGravity();
    }

    void ApplyGravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
            player.Move(Time.deltaTime * velocity);
        } 
        else if (velocity.y < 0)
        { 
            velocity.y = -2;
           
        }

    }

    bool IsGrounded()
    {
        Debug.Log("Done");
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
           if(Physics.CheckSphere(pos,player.radius - 0.05f,ground)) return true;
        return false;
    }


    //change speed According to state from stateManager
    public void UpdateSpeed(float speed)
    {
        this.speed = speed;
    }

    
}
