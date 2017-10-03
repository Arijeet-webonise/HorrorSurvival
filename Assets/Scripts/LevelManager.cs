using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;

	// Use this for initialization
	void Start () {
		if (instance == null || instance == this) {
			instance = this;		
			DontDestroyOnLoad (instance.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	void Update(){
		DayNightCycle timeManager = FindObjectOfType<DayNightCycle> ();
		if (timeManager.isDay ()) {
			zombie[] zoms = FindObjectsOfType<zombie> ();
			foreach (zombie zom in zoms) {
				zom.gameObject.SetActive (false);
			}
			FindObjectOfType<Player> ().Flash (false);
			RenderSettings.fog = false;
		} else {
			zombie[] zoms = FindObjectsOfType<zombie> ();
			foreach (zombie zom in zoms) {
				zom.gameObject.SetActive (true);
			}
			FindObjectOfType<Player> ().Flash (true);
			RenderSettings.fog = true;
		}
	}

	public void GotoLevel(int level){
		Application.LoadLevel (level);
	}

	public void GotoLevel(string level){
		Application.LoadLevel (level);
	}

	public void NextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void EndGame(){
		Application.Quit ();
	}
}
