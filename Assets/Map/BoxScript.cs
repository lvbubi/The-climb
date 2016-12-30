using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
    private new Rigidbody rigidbody;
    public bool BoxInGoal = false;
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (col.gameObject.name == "troll")
        {
            rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
        if (col.gameObject.name.Contains("Goal"))
        {
            if (Vector3.Distance(transform.position, col.transform.position) < 2.7)
                BoxInGoal = true;
            else
                BoxInGoal = false;
        }
    }

    void OnCollisionExit(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (col.gameObject.name == "troll")
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll; 
        }
    }

}
