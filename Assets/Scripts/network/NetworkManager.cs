using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	public  GameObject StandByCamera;
	spawnspot[] spawnstuff;
	Vector3 dog=new Vector3(-2,-2,0);
	// Use this for initialization
	void Start () {
		spawnstuff=GameObject.FindObjectsOfType<spawnspot>();
		
		Connect ();
	}
	void Connect()
	{
		PhotonNetwork.ConnectUsingSettings ("1.0.0");
		//PhotonNetwork.offlineMode="True";
	}
	void OnGUI()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
	void OnJoinedLobby()
	{
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
		//PhotonNetwork.JoinRandomRoom ();
	}
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
		
	}
	void OnJoinedRoom()
	{
		
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer();
	}
	void SpawnMyPlayer()
	{
	
		if (spawnstuff == null) {
			Debug.LogError("NO CLUE");
			return;
		}
		spawnspot myspot = spawnstuff [Random.Range (0, spawnstuff.Length)];
		GameObject myplayer = (GameObject)PhotonNetwork.Instantiate("Viking",myspot.transform.position,myspot.transform.rotation,0);
		//new
		GameObject doggie = (GameObject)PhotonNetwork.Instantiate("Golden_Retriever@sniff_3",myspot.transform.position+dog,myspot.transform.rotation,0);
		StandByCamera.SetActive(false);
		myplayer.gameObject.SetActive (true);
		//((MonoBehaviour)myplayer.GetComponent("ThirdPersonController")).enabled=true;
		
		//		((MonoBehaviour)myplayer.GetComponent("ThirdPersonCamera")).enabled=true;
		
		((MonoBehaviour)myplayer.GetComponent("FPSInputController")).enabled=true;
	//	((MonoBehaviour)myplayer.GetComponent("MouseLook")).enabled=true;
		((MonoBehaviour)myplayer.GetComponent("CharacterMotor")).enabled=true;
	
		myplayer.transform.FindChild ("Main Camera").gameObject.SetActive (true);
	//	myplayer.transform = myplayer.transform;
	}
}