using UnityEngine;
using System.Collections;

public class NewLevelCamera : MonoBehaviour {
    public float timeleft = 8.0f;
    private float speed = 0f;
    // Use this for initialization
    void Start () {
        
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = new Vector3(transform.position.x, 40, transform.position.z);
        timeleft -= Time.deltaTime;
        if(timeleft > 0)
        {
            if (timeleft > 5)
            {
                speed += Time.deltaTime;
            }
            else
            {
                speed -= Time.deltaTime;
            }
            transform.rotation = Quaternion.Euler(new Vector3(90, 45 * Mathf.Pow(6,speed), 0));
        }
        else
        {
            GetComponent<CameraController>().enabled = true;
            GetComponent<ThirdPersonCamera>().enabled = true;
            GetComponent<NewLevelCamera>().enabled = false;
            timeleft = 8.0f;
            speed = 0f;
}
        
	}
}
