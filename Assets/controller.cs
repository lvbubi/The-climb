using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    public float speed = 2;
	// Use this for initialization
	void Start () {
	
	}
    void OnCollisionExit(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
        // Update is called once per frame
    void Update () {
        moove();
    }


    void moove()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 offset = new Vector3(x, 0.0f, z) * speed;

        transform.position += offset * Time.deltaTime;


        GetComponent<Animator>().SetFloat(
              "speed", offset.magnitude
          );
        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.LookRotation(offset.normalized);
        }
    }
}
