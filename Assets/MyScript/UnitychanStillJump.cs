using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanStillJump : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveDirection;

	void Jump() {
		moveDirection.y = 10;
	}

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	void Update () {
		Animator myAnimator = GetComponent<Animator>();

		if (Input.GetKey (KeyCode.Space) || Input.GetButton("Submit")) {
			if (controller.isGrounded) {
				myAnimator.SetBool ("StillJump", true);
			}
		}

		AnimatorStateInfo state = myAnimator.GetCurrentAnimatorStateInfo(0);
		if (state.IsName ("Locomotion.StillJump")) {
			myAnimator.SetBool ("StillJump", false);
		}


	}
}
