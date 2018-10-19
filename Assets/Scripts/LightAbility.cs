using UnityEngine;
using System.Collections;

public class LightAbility : MonoBehaviour {

    public float radius = 5;
    public float period = 5;

    private Renderer rend;
    private Shader defaultShader;
    private Shader invisibleShader;
    private bool invisible;
    private float waited;

    public bool isActivated() { return invisible; }
    public float getRadius() { return radius; }

    public void Start() {
        rend = GetComponent<Renderer>();
        defaultShader = rend.material.shader;
        invisibleShader = Shader.Find("Unlit/Invisible");
        invisible = false;
        waited = 0;
    }

    public void Update() {
        waited += Time.deltaTime;
        if (waited > period) {
            waited = 0;
            rend.material.shader = (invisible) ? defaultShader : invisibleShader;
            invisible = !invisible;
        }
    }

}
