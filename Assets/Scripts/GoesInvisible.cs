﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoesInvisible : MonoBehaviour {
	
	public LightController player;
	private float startRad = 0;
	
	private float shrinkTime, growTime, curRad = 0;
	public float speed = 5;
	public float growFactor = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		if (this.player.isInvisible) {
			renderer.material.SetVector("_invPla", this.player.transform.position);
			
			if (growTime < Mathf.PI/2) {
				shrinkTime = 0;
				growTime += Time.deltaTime*speed*growFactor;
				startRad = this.player.radius * Mathf.Sin(growTime);
				renderer.material.SetFloat("_invRad", startRad);
			}
		} else if (shrinkTime < Mathf.PI/2) {
			growTime = 0;
			renderer.material.SetVector("_invPla", this.player.transform.position);
			shrinkTime += Time.deltaTime*speed;
			renderer.material.SetFloat("_invRad", startRad * Mathf.Cos(shrinkTime));
		}
		
	}
}
