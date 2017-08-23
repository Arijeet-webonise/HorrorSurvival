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
	[Range(0,100)]
	public float stamina = 100;
	[Range(0,100)]
	public float staminaDropRate = 10;
	[Range(0,100)]
	public float staminaRecoverRate = 2;
	[Range(1,100)]
	public float defaultFOV = 60f;
	public AudioClip heliSummonAudio;
	public Text actionText;
	public Slider staminaBar;

	public void Die(){
		GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = false;
	}

	// Use this for initialization
	void Awake () {
		eyes = GetComponentInChildren<Camera> ();
		staminaBar.maxValue = 100;
		staminaBar.minValue = 0;
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

	void SetStamina(float newstamina){
		staminaBar.value=newstamina;
	}

	void StaminaInput(){
		#if !MOBILE_INPUT
		// On standalone builds, walk/run speed is modified by a key press.
		// keep track of whether or not the character is walking or running
		if(Input.GetKey(KeyCode.LeftShift)){
			if(stamina>0){
				GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().hasStamina=true;
				stamina-=staminaDropRate;
			}else{
				GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().hasStamina=false;
				stamina+=staminaRecoverRate;
			}
		}else{
			stamina+=staminaRecoverRate;
			GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().hasStamina=false;
		}
		#endif
		SetStamina(stamina);

	}

	// Update is called once per frame
	void Update () {

		StaminaInput ();

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
			LevelManager.instance.GotoLevel ("Win");
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
