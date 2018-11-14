using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectPlay : MonoBehaviour {

    public GameObject Eff;
	
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Eff.GetComponent<ParticleSystem>().Play();
        }
	}
}
