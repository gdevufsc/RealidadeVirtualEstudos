﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	void Update () {
        transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime);
	}
}
