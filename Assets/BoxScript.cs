using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (col.gameObject.name == "troll")
        {
            
            Debug.Log("Collision");
            

            rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
    }

    void OnCollisionExit(Collision col)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (col.gameObject.name == "troll")
        {
            Debug.Log("Collision");
            rigidbody.constraints = RigidbodyConstraints.FreezeAll; 
        }
    }

}
