using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    public float moveSpeed = 0;
    public float turnSpeed = 0;

    // Use this for initialization
    void Start() {

    }
    void OnCollisionExit(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update() {
        moove();
    }


    void moove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetFloat("speed", 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetFloat("speed", 10);
        }

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -turnSpeed* Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, turnSpeed* Time.deltaTime);


        if (Input.GetKeyUp(KeyCode.W))
            GetComponent<Animator>().SetFloat("speed", 0);
        if (Input.GetKeyUp(KeyCode.S))
            GetComponent<Animator>().SetFloat("speed", 0);

    }


}
