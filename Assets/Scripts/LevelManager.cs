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
