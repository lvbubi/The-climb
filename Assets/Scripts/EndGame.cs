using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	void Start() {
		StartCoroutine(Example());
	}

	IEnumerator Example() {
		
		yield return new WaitForSeconds(25);
		SceneManager.LoadScene("MainMenu");
	}

}
