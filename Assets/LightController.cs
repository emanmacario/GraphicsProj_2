using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public Renderer rend;
	private Shader defaultShader;
	private Shader invisibleShader;
	public bool isInvisible = false;
	
	public void Start() {
		rend = GetComponent<Renderer>();
		defaultShader = rend.material.shader;
		invisibleShader = Shader.Find("Unlit/Invisible");
	}

	public void Update() {
		if (Input.GetKeyDown("r")){
			if (rend.material.shader == defaultShader){
				rend.material.shader = invisibleShader;
				isInvisible = true;
			} else {
				rend.material.shader = defaultShader;
				isInvisible = false;
			}
		}
	}

}
