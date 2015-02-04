using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			Camera.main.GetComponent<MobaCamera>().ChangeLockOnHero();
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			Camera.main.GetComponent<MobaCamera>().returnToHero();
		}
	}
}
