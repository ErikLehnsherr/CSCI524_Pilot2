using UnityEngine;
using System.Collections;

public class HeroPet : MonoBehaviour {

    public GameObject pet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatePet()
    {
		Vector3 newPosition = transform.position - new Vector3 (2, 0, 0);
		GameObject newPet = (GameObject)PhotonNetwork.Instantiate("Golden_Retriever@sniff_3",newPosition,transform.rotation,0);

     //   GameObject newPet=Instantiate(pet, newPosition, Quaternion.identity)as GameObject;
        newPet.transform.parent = transform.parent;
        newPet.GetComponent<Team>().team = GetComponent<Team>().team;
        
    }
}
