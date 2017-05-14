using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalManager : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		print(collision.gameObject);
		print(this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		print(this.gameObject);
	}
}
