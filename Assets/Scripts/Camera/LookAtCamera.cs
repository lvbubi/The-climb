using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
    public GameObject target;
    // Use this for initialization
    void Start()
    {

    }

    void LateUpdate()
    {
        Vector3 pos= GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = new Vector3(pos.x, 5, pos.z);
        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
