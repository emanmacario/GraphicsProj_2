using UnityEngine;
using System.Collections;

public class LightAbility : MonoBehaviour {

    public float radius = 5;
	public float speed = 5;
    public float growFactor = 4;
	public Transform halo;

    private Renderer rend;
    private Shader defaultShader;
    private Shader invisibleShader;
    private bool invisible;
	private float startRad = 0;
    private float shrinkTime, growTime;

    public bool isActivated() { return invisible; }
    public float getRadius() { return radius; }

    public void Start() {
        rend = GetComponent<Renderer>();
        defaultShader = rend.material.shader;
        invisibleShader = Shader.Find("Unlit/Invisible");
        invisible = false;
    }

    public void Update() {
        if (Input.GetKeyDown("r")) {
            rend.material.shader = (invisible) ? defaultShader : invisibleShader;
            invisible = !invisible;
        }
		
		if (invisible) {
            if (growTime < Mathf.PI/2) {
                shrinkTime = 0;
                growTime += Time.deltaTime*speed*growFactor;
                startRad = radius * Mathf.Sin(growTime);
                halo.localScale = Vector3.one * startRad;
            }
        } else if (shrinkTime < Mathf.PI/2) {
            growTime = 0;
            shrinkTime += Time.deltaTime*speed;
            halo.localScale = Vector3.one * startRad * Mathf.Cos(shrinkTime);
        } else {
			halo.localScale = Vector3.zero;
		}
    }

}
