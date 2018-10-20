using UnityEngine;
using System;
using System.Collections;

public class ShootAbility : MonoBehaviour {

    public GameObject typeA;
    public GameObject typeB;
    public float recoilForceA = 5;
    public float recoilForceB = 40;
    public float fireDelayA = 0.5f;
    public float fireDelayB = 2.0f;

    private Camera cam;
    private Transform tf;
    private Rigidbody rb;
    private AudioManager am;
    private float timeFiredAgoA;
    private float timeFiredAgoB;

    private void fireA(Vector3 target) {
        GameObject g = Instantiate(typeA, tf.position, Quaternion.identity);
        ProjectileBehaviour p = g.GetComponent<ProjectileBehaviour>();
        Vector3 dir = target - tf.position;
        p.setDir(dir);
        rb.AddForce(recoilForceA * -dir);
        am.Play("RadAFire");
        timeFiredAgoA = 0;
    }

    private void fireB(Vector3 target) {
        GameObject g = Instantiate(typeB, tf.position, Quaternion.identity);
        ProjectileBehaviour p = g.GetComponent<ProjectileBehaviour>();
        Vector3 dir = target - tf.position;
        p.setDir(dir);
        rb.AddForce(recoilForceB * -dir);
        am.Play("RadBFire");
        timeFiredAgoB = 0;
    }

    public void Start() {
        cam = Camera.main;
        tf = this.gameObject.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        am = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        timeFiredAgoA = 0;
        timeFiredAgoB = 0;
    }

    public void Update() {
        timeFiredAgoA += Time.deltaTime;
        timeFiredAgoB += Time.deltaTime;
        bool L = Input.GetMouseButton(0);
        bool R = Input.GetMouseButton(1);
        if (L || R) {
            Vector2 mouse = Input.mousePosition;
            Vector3 target = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, -cam.gameObject.transform.position.z));
            if (L && timeFiredAgoA > fireDelayA) fireA(target);
            if (R && timeFiredAgoB > fireDelayB) fireB(target);
        }
        // Debugging hack, remove later
        if (Input.GetKeyDown("s")) recoilForceA = 100;
    }

}
