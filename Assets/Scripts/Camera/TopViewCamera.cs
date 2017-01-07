using UnityEngine;
using System.Collections;

public class TopViewCamera : MonoBehaviour {
    private float currentX = 16.25f;
    private float currentZ = 18.06f;
    private float currentY = 37.06f;
    private GameObject MainCam;
    // Use this for initialization
    void Start () {
        MainCam = GameObject.Find("Main Camera");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            currentX += -Input.GetAxis("Mouse X");
            currentZ += -Input.GetAxis("Mouse Y");
        }
        MainCam.transform.position = new Vector3(currentX, currentY, currentZ);
            MainCam.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentX = 16.25f;
            currentZ = 18.06f;
            currentY = 37.06f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            currentY -= 3;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            currentY += 3;
    }
}
