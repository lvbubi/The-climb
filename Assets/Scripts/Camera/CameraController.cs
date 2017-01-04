using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private Quaternion currentrot;
    private Vector3 currentpos;
    private GameObject MainCam;
    private int a = 0; //Tesco value trigger
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


        LookAtLadderCamera();
    }

    void LookAtLadderCamera()
    {
        
        if (GameObject.Find("SteelLadder B(Clone)") != null && a==0)
        {
            
            MainCam.GetComponent<ThirdPersonCamera>().enabled = false;
            MainCam.GetComponent<LookAtCamera>().enabled = true;
            

            if (GameObject.Find("SteelLadder B(Clone)").GetComponent<LadderAnimation>().currentY <= 0.1f)
            {
                MainCam.GetComponent<ThirdPersonCamera>().enabled = true;
                MainCam.GetComponent<LookAtCamera>().enabled = false;
                a++;
            }
        }
    }
}
