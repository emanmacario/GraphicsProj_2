using UnityEngine;
using System.Collections;

public class LightAbility : MonoBehaviour {

    public float radius = 5;

    private Renderer rend;
    private Shader defaultShader;
    private Shader invisibleShader;
    private bool invisible;

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
    }

}
