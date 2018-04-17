using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderScript : MonoBehaviour {

	private int lockPos = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, lockPos, lockPos); // locks the rotation
	}
}
