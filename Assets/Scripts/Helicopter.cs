using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Helicopter : MonoBehaviour {

	public AudioClip audioClip;

	AudioSource player;

	public static Helicopter singleton;

	// Use this for initialization
	void Start () {

		if (singleton != null && singleton != this) {
			Destroy (this.gameObject);
		} else {
			singleton = this;
			player = GetComponent<AudioSource> ();
			player.clip = audioClip;
			player.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

}
