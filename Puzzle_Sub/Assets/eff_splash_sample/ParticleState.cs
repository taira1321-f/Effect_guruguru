using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleState : MonoBehaviour {
    public GameObject eff_splash;
	void Start () {
		
	}
	
	void Update () {
        GetButton();
	}
    void GetButton() {
        if (Input.GetKey(KeyCode.Space)) eff_splash.GetComponent<ParticleSystem>().Play();
    }
}
