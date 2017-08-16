using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour {
	public void ChangeLevel(){
		LevelManager.instance.NextLevel ();
	}
}
