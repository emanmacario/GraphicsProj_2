using UnityEngine;
using System.Collections;

public class LightAbility : MonoBehaviour {

    public float radius = 5;

    private Renderer rend;
    private Shader defaultShader;
    private Shader invisibleShader;
    private bool invisible;

    public bool activated() { return invisible; }

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
