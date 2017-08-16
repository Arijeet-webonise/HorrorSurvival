using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class zombie : MonoBehaviour {

	public AudioClip zombieCall;
	AudioSource player;

	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player> ().Die ();
			LevelManager.instance.GotoLevel ("JumpScareOver");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			player.clip = zombieCall;
			player.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
