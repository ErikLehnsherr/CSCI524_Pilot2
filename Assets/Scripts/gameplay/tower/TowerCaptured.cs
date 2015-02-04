using UnityEngine;
using System.Collections;

public class TowerCaptured : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void Capture()
	{
		Camera.main.GetComponent<GUI_Temp> ().MessageToWorld ("team a get a tower");
		GetComponent<FogOfWarPlayer> ().enabled = true;
		}
	// Update is called once per frame
	void Update () {
	
	}
}
