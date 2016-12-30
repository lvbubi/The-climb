using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;
    public float ZoomAmount = 0;
    public float MaxToClamp = 10;
    public float ROTSpeed = 10;
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
        MouseWheelZoom();
    }
    
    void MouseWheelZoom()
    {

        ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
        ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
        var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
        transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
        if(Input.GetAxis("Mouse ScrollWheel") > 0.1 || Input.GetAxis("Mouse ScrollWheel") < -0.1)
            offset = target.transform.position - transform.position;
    }
}