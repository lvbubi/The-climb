using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LoadMap : MonoBehaviour {
    public GameObject box;
    public GameObject floor;
    public GameObject goal;
    public GameObject wall;
    private GameObject[] boxes;
    public int countOfBoxes = 0;
	// Use this for initialization
	void Start () {
        System.String input = File.ReadAllText(@"Palya.txt");

        int i = 0, j = 0;
        
        int[,] result = new int[100, 100];
        foreach (var row in input.Split('\n'))
        {
            j = 0;
            foreach (var col in row.Trim().Split(' '))
            {
                result[i, j] = int.Parse(col.Trim());
                j++;
            }
            i++;
        }
        int a, k;
        for (a = 0; a < i; a++)
        {
            for (k = 0; k < j; k++)
            {
                switch (result[a, k])
                {
                    case 0:
                        GameObject.Instantiate(floor, new Vector3(5 * a, -2.42f, 5 * k), transform.rotation);
                        break;
                    case 1:
                        GameObject.Instantiate(wall, new Vector3(5 * a, 0, 5 * k), transform.rotation);
                        break;
                    case 2:
                        GameObject.Instantiate(box, new Vector3(5*a, 0.13f, 5*k), transform.rotation);
                        GameObject.Instantiate(floor, new Vector3(5 * a, -2.42f, 5 * k), transform.rotation);
                        countOfBoxes++;
                        break;
                    case 3:
                        GameObject.Instantiate(goal, new Vector3(5 * a, -2.42f, 5 * k), transform.rotation);
                        break;
                    case 9:
                        GameObject.FindWithTag("Player").transform.position = new Vector3(5 * a, -2.25f, 5 * k);
                        GameObject.Instantiate(floor, new Vector3(5 * a, -2.42f, 5 * k), transform.rotation);
                        break;
                }

            }
        }
        boxes = GameObject.FindGameObjectsWithTag("Box");

    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        for (i = 0; i < boxes.Length; i++)
        {
            if (!boxes[i].GetComponent<BoxScript>().BoxInGoal)
                break;
        }
        if (i == boxes.Length)
            Debug.Log("JÁTÉK VÉGE");

	}
}
