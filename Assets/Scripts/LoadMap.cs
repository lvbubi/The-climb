using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadMap : MonoBehaviour {
    public GameObject box;
    public GameObject floor;
    public GameObject goal;
    public GameObject wall;
    public GameObject ladder;
    public GameObject wallWithoutLight;
    public Text BoxCounter;

    private GameObject MainCam;
    private GameLevels gamelevels;
    private GameObject[] boxes;
    private int BoxesBack = 0;
    private int CurrentLevelIdx = 0;
    
    void Start () {
        List<string> PathOfLevels = new List<string>();
        PathOfLevels.Add("Palya0.txt");
        PathOfLevels.Add("Palya.txt");
        PathOfLevels.Add("Palya2.txt");
        //add path for games
        MainCam = GameObject.Find("Main Camera");
        gamelevels = new GameLevels(PathOfLevels, floor, wall, box, goal, wallWithoutLight);

        gamelevels.LoadLevel(CurrentLevelIdx);
        boxes = GameObject.FindGameObjectsWithTag("Box");
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        for (i = 0; i < boxes.Length; i++)
        {
            if (!boxes[i].GetComponent<BoxScript>().BoxInGoal)
                BoxesBack++;
        }
        if (BoxesBack == 0)
        {
                MainCam.GetComponent<CameraController>().enabled = false;
            MainCam.GetComponent<ThirdPersonCamera>().enabled = false;
            MainCam.GetComponent<NewLevelCamera>().enabled = true;

            if (MainCam.GetComponent<NewLevelCamera>().timeleft < 5)
            {
                deleteGamebjects();
                gamelevels.LoadLevel(++CurrentLevelIdx);
                //átvezetés másik scenera
                boxes = GameObject.FindGameObjectsWithTag("Box");
            }
        }



        BoxCounter.text = "Boxes Back: " + BoxesBack;
        BoxesBack = 0;

        ReloadGame();
    }

    void ReloadGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            deleteGamebjects();
            gamelevels.LoadLevel(CurrentLevelIdx);
            boxes = GameObject.FindGameObjectsWithTag("Box");
        }
    }



    private void deleteGamebjects()
    {
        var AllGameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject gameobject in AllGameObjects)
        {
            if (gameobject.tag == "Wall" || gameobject.tag == "Box" || gameobject.tag == "Goal" || gameobject.tag == "Floor")
                DestroyImmediate(gameobject);
        }
        DestroyImmediate(GameObject.Find("SteelLadder B(Clone)"));
    }
}

class GameLevels
{
    private List<Level> levels = new List<Level>();
    private int CountOfLevels = 0;
    public GameLevels(List<string> paths, GameObject floor, GameObject wall, GameObject box, GameObject goal, GameObject wall2=null)
    {
        foreach (string path in paths)
        {
            string input = File.ReadAllText(@path);
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
            levels.Add(new Level(result, i, j, floor, wall, box, goal,wall2));
            CountOfLevels++;
        }
    }
    public void LoadLevel(int idx)
    {
        if (idx < CountOfLevels)
            levels[idx].GenerateMap();
        else
			SceneManager.LoadScene ("GameOver");
    }
}

class Level
{
    public Level(int[,] level, int rows, int cols, GameObject floor, GameObject wall, GameObject box, GameObject goal, GameObject wall2=null)
    {
        this.level = level;
        this.rows = rows;
        this.cols = cols;
        this.floor = floor;
        this.box = box;
        this.goal = goal;
        this.wall = wall;
        this.wall2 = wall2;
    }
    private int[,] level = new int[100, 100];
    private int rows;
    private int cols;
    private GameObject floor, wall, box, goal,wall2;
    public void GenerateMap()
    {
        int a, k;
        for (a = 0; a < rows; a++)
        {
            for (k = 0; k < cols; k++)
            {
                switch (level[a, k])
                {
                    case 0:
                        GameObject.Instantiate(floor, new Vector3(5 * a, -2.42f, 5 * k), new Quaternion(0, 0, 0, 0));
                        break;
                    case 1:
                        if((k==0 && a%2==1) || ((k==cols-1) && a%2==1 ) || k%2==0 && a==rows-1 || k%2 ==0 && a==0)
                            GameObject.Instantiate(wall, new Vector3(5 * a, 0, 5 * k), new Quaternion(0, 0, 0, 0));
                        else
                            GameObject.Instantiate(wall2, new Vector3(5 * a, 0, 5 * k), new Quaternion(0, 0, 0, 0));
                        break;
                    case 2:
                        GameObject.Instantiate(box, new Vector3(5 * a, 0.13f, 5 * k), new Quaternion(0, 0, 0, 0));
                        GameObject.Instantiate(floor, new Vector3(5 * a, -2.42f, 5 * k), new Quaternion(0, 0, 0, 0));

                        break;
                    case 3:
                        GameObject.Instantiate(goal, new Vector3(5 * a, -2.42f, 5 * k), new Quaternion(0, 0, 0, 0));
                        break;
                    case 9:
                        GameObject.FindWithTag("Player").transform.position = new Vector3(5 * a, -2.25f, 5 * k);
                        GameObject.Instantiate(floor, new Vector3(5 * a, -2.42f, 5 * k), new Quaternion(0, 0, 0, 0));
                        break;
                }

            }
        }
    }
}
