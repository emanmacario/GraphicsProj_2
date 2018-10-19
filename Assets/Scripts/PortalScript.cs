using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {
	
	private Material mat;
	private Light light;

	// Use this for initialization
	void Start () {
		mat = this.gameObject.GetComponent<MeshRenderer>().material;
		light = this.gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		light.color = mat.GetColor("_Base");
	}
}
