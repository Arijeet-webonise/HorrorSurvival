using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance;

	// Use this for initialization
	void Start () {
		if (instance == null || instance == this) {
			DontDestroyOnLoad (this.gameObject);
			instance = this;		
		} else {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
