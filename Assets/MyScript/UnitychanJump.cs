using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanJump : MonoBehaviour {

	void Start () {
		print("Hello, UnitychanJump!");
	}
	
	void Update () {
		Animator myAnimator = GetComponent<Animator>();
		if (Input.GetKey (KeyCode.Space) || Input.GetButton("Submit")) {
			myAnimator.SetBool ("Jump", true);
		}
		AnimatorStateInfo state = myAnimator.GetCurrentAnimatorStateInfo(0);
		if (state.IsName ("Locomotion.Jump")) {
			myAnimator.SetBool ("Jump", false);
		}
	}
}
