using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {
    public Vector3 angle;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(angle);
	}
}
