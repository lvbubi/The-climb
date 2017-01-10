using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
    private new Rigidbody rigidbody;
    public bool BoxInGoal = false;

    private bool collided = false;
    private Collision CollidedTroll;
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (col.gameObject.name == "troll" && col.collider.ToString().Contains("Box"))//Now the box cant moove diagonally
        {
            
            collided = true;
            CollidedTroll = col;
        }

    }

    void Update()
    {
        if (collided && Input.GetKey(KeyCode.Space))
        {
            Vector3 hit = CollidedTroll.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);

            if (Mathf.Approximately(angle, 90))
            {
                // Sides
                CollidedTroll.rigidbody.mass = 2;
                Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y > 0 || cross.y < 0)
                        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
                    else rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;

                
            }
        }
        else
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "troll" && col.collider.ToString().Contains("Box"))
        {
            collided = false;
            CollidedTroll.rigidbody.mass = 0.01f;
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
        }
        
    }

}
