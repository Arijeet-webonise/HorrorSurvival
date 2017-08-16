using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

	public AudioClip heliInit;
	public AudioClip heliReply;
	public float replyTime = 300;
	public Helicopter copter;

	AudioSource player;

	public void Awake(){
		player = GetComponent<AudioSource> ();

	}

	public void CallHeli(){
		PlayAudio (heliInit);
		Invoke ("CallHeliReply", replyTime);
	}

	public void PlayAudio(AudioClip audio){
		player.Stop ();
		player.clip = audio;
		player.Play ();
	}

	private void CallHeliReply(){
		Instantiate (copter);
		PlayAudio (heliReply);
	}
}
