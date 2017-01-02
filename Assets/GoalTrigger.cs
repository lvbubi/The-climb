using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Box")
        {
            if (Mathf.Abs(col.gameObject.transform.position.x - transform.position.x) < 1 && Mathf.Abs(col.gameObject.transform.position.z - transform.position.z) < 1)
                col.gameObject.GetComponent<BoxScript>().BoxInGoal = true;
            else
                col.gameObject.GetComponent<BoxScript>().BoxInGoal = false;
        }
    }
}