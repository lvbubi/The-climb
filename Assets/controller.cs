using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    public float movementSpeed = 10;
    public float turningSpeed = 60;
    private int a = 0;
    // Use this for initialization
    void Start() {

    }
    void OnCollisionExit(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        a = 0;
    }
    void OnCollisionEnter(Collision col)
    {
        a = 1;
    }
    // Update is called once per frame
    void Update() {
        moove();
    }


    void moove()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        if (a == 0)
            transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        Vector3 offset = new Vector3(horizontal, 0.0f, vertical) * movementSpeed;
        GetComponent<Animator>().SetFloat(
              "speed", offset.magnitude
          );

    }

   
}
