using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {

	public Button Play;
	public Button Exit;

	// Use this for initialization
	void Start () {
	
		Play = Play.GetComponent<Button> ();
		Exit = Exit.GetComponent<Button> ();

	}
	
	// Update is called once per frame
	 void Update () {

	}

	public void StartGame()
	{
		SceneManager.LoadScene ("main");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
