using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Effect_start : MonoBehaviour {
    int fps;
	void Start () {
        QualitySettings.vSyncCount = 2;     //VSyncをOFFにする
        //Application.targetFrameRate = 60;   //ターゲットフレームレート
        fps = Application.targetFrameRate;
        Debug.Log(fps);
    }
	
	// Update is called once per frame
	void Update () {
        fps = Application.targetFrameRate;
        Debug.Log(fps);
	}
}
