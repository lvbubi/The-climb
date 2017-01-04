using UnityEngine;
using System.Collections;

public class LadderAnimation : MonoBehaviour {
    public float currentY;

	// Use this for initialization
	void Start () {
        currentY = transform.position.y;
        GameObject.Find("Main Camera").GetComponent<LookAtCamera>().target = transform.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        if (currentY >= 0)
            currentY = currentY - 0.1f;
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 10)
        {
            Debug.Log("FUCKYEAH");
            GetComponent<LadderAnimation>().enabled = false;
        }
	}
}
