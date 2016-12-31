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
            Vector3 hit = col.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);

            if (Mathf.Approximately(angle, 90))
            {
                // Sides
                Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                if (cross.y > 0 || cross.y < 0)
                    rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
                else rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            }
            
            
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
