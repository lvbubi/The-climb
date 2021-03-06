﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
    public bool load = false;
    public bool exit = false;
	public Button Play;
	public Button Exit;
	public Button Credits;
	public Button Continue;
	// Use this for initialization
	void Start () {
	
		Play = Play.GetComponent<Button> ();
		Exit = Exit.GetComponent<Button> ();
		Credits = Credits.GetComponent<Button> ();
		Continue = Continue.GetComponent<Button> ();

	}
	
	// Update is called once per frame
	 void Update () {

	}

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public bool IsContinue()
    {
        return load;
    }
    public void StartGame()
	{
		SceneManager.LoadScene ("main");
        load = false;
	}

	public void ExitGame()
	{
        exit = true;
		Application.Quit();
	}

	public void RollCredits()
	{
		SceneManager.LoadScene ("GameOver");
	}

    public void ContinueGame()
    {
        SceneManager.LoadScene("main");
        load = true;
    }
}
