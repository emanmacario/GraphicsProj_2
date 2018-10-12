using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoesInvisible : MonoBehaviour {
	
	public GameObject player;
    private LightController lightController;
	private float startRad = 0;
	
	private float shrinkTime, growTime;
	public float speed = 5;
	public float growFactor = 4;

    void Start() {
        lightController = player.GetComponent<LightController>();
    }

	// Update is called once per frame
	void Update () {
		MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
		if (lightController.isInvisible) {
			renderer.material.SetVector("_invPla", lightController.transform.position);
			if (growTime < Mathf.PI/2) {
				shrinkTime = 0;
				growTime += Time.deltaTime*speed*growFactor;
				startRad = lightController.radius * Mathf.Sin(growTime);
				renderer.material.SetFloat("_invRad", startRad);
			}
		} else if (shrinkTime < Mathf.PI/2) {
			growTime = 0;
			renderer.material.SetVector("_invPla", lightController.transform.position);
			shrinkTime += Time.deltaTime*speed;
			renderer.material.SetFloat("_invRad", startRad * Mathf.Cos(shrinkTime));
		}
		
	}
}
