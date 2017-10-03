using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	/// <summary>
	/// How many seconds per min
	/// </summary>
	[Tooltip("How many seconds per min")]
	public float timeScale = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Time.deltaTime / 360 * timeScale;
		transform.RotateAround (transform.position, transform.right, angle);
	}

	public bool isDay(){
		return transform.rotation.eulerAngles.x >= 0 && transform.rotation.eulerAngles.x < 180;
	}
}
