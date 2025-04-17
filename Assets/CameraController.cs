using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]Cinemachine.AxisState xAxis, yAxis;

    public Transform followPoint;

    [HideInInspector] public static Vector3 direction;
    private void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            direction = followPoint.forward;
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            followPoint.localEulerAngles = new Vector3(followPoint.localEulerAngles.x, xAxis.Value, followPoint.localEulerAngles.z);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            followPoint.forward = direction;
        }
        else
        {
            direction = followPoint.forward;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
        }

          followPoint.localEulerAngles = new Vector3(yAxis.Value, followPoint.localEulerAngles.y, followPoint.localEulerAngles.z);
    }
}
