using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private Quaternion currentrot;
    private Vector3 currentpos;
    private GameObject MainCam;
    // Use this for initialization
    void Start () {
        MainCam = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentrot = MainCam.transform.rotation;
            currentpos = MainCam.transform.position;
            GetComponent<ThirdPersonCamera>().enabled = false;
            GetComponent<TopViewCamera>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            MainCam.transform.position = currentpos;
            MainCam.transform.rotation = currentrot;
            GetComponent<TopViewCamera>().enabled = false;
            GetComponent<ThirdPersonCamera>().enabled = true;
            
        }
    }
}
