using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public Renderer rend;
	private Shader shader1;
	private Shader shader2;
	
	public void Start() {
		rend = GetComponent<Renderer>();
		shader1 = rend.material.shader;
		shader2 = Shader.Find("Unlit/Invisible");
	}

	public void Update() {
		if (Input.GetKeyDown("r")){
			if (rend.material.shader == shader1){
				rend.material.shader = shader2;
			} else {
				rend.material.shader = shader1;
			}
		}
	}

}
