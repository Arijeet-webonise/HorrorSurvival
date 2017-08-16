using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScare : MonoBehaviour {

	public float time = 500f;

	// Use this for initialization
	void Start () {
		Invoke ("DisableJump", time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DisableJump(){
		gameObject.SetActive (false);
	}
}
