using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardingScript : MonoBehaviour {

    public KeyCode inputKey;
    public GameObject bombPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(inputKey))
        {
           GameObject p = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            p.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
	}
}
