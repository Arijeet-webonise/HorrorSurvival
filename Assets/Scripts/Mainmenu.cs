using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour {

	public void StartGame(){
		LevelManager.instance.NextLevel ();
	}

	public void ExitGame(){
		LevelManager.instance.EndGame ();
	}
}
