using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Transform spawns;
	Camera eyes;
	bool canSummonHeli = false;
	bool summonedHeli = false;
	bool isHeli=false;

	[Range(1,100)]
	public float defaultFOV = 60f;
	public AudioClip heliSummonAudio;
	public Text actionText;

	public void Die(){
		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = false;
	}

	// Use this for initialization
	void Awake () {
		eyes = GetComponentInChildren<Camera> ();
		Respawn ();
	}

	public void Respawn(){
		spawns = GameObject.FindGameObjectWithTag ("PlayerSpawn").transform;
		Transform spawn = spawns.GetChild (Random.Range (0, spawns.childCount - 1));
		transform.position = spawn.position;
	}

	void CallHeli(){
		GetComponentInChildren<Radio> ().CallHeli ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Zoom") != 0) {
			eyes.fieldOfView = defaultFOV / 1.5f;
		} else {
			eyes.fieldOfView = defaultFOV;
		}
		if (Input.GetAxis ("Call Heli") != 0 && canSummonHeli && !summonedHeli) {
			summonedHeli = true;
			actionText.text = "";
			CallHeli ();
		}
		if (Input.GetAxis ("Fire1") != 0 && canSummonHeli && summonedHeli && isHeli) {
			LevelManager.instance.GotoLevel (3);
		}
	}

	void OnTriggerExit(Collider other){
		switch (other.tag) {
		case "Finish":
			canSummonHeli = false;
			break;
		default:
			Debug.LogError ("Trigger Exit");
			break;
		}
		actionText.text = "";

	}

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "Finish":
			canSummonHeli = true;
			if (!summonedHeli) {
				actionText.text = "Press 'H' to call Helicopter";
				GetComponentInChildren<Radio> ().PlayAudio (heliSummonAudio);
			}
			break;
		case "Helicopter":
			actionText.text = "Press 'Ctrl' to Escape";
			isHeli = true;
			break;
		default:
			Debug.LogError ("Trigger Enter");
			break;
		}
	}
}
