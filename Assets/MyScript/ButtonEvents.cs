using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonEvents : MonoBehaviour {

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clickButtonToStart() {
		jumpToMainScene();
	}

	void jumpToMainScene() {
		SceneManager.LoadScene("MazeScene");
	}
}
