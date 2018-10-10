using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

	private Rigidbody rb;
	private bool changeGravity = false;

	public void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
	}


	public void Update() {
		if (Input.GetKeyDown(KeyCode.F))
		{
			changeGravity = !changeGravity;
			/* gameObject.GetComponent<PlayerController>().ReverseJumpDirection(); */
		}
	}


	public void FixedUpdate() {
		if (changeGravity)
		{
			rb.AddForce(-2 * Physics.gravity * rb.mass);
		}
	}
}
