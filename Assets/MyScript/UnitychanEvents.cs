using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UnitychanEvents : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		print(collision.gameObject);
		print(this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Cube (1)") {
			SceneManager.LoadScene("MainScene");
		}
	}
}
