using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CapturePanorama;

public class CaptureTodoFrame : MonoBehaviour {

    public CapturePanorama.CapturePanorama capturePanorama;
    public string baseFileName;
    int num = 0;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            num++;
            capturePanorama.CaptureScreenshotAsync( baseFileName + num );
        }
	}
}
