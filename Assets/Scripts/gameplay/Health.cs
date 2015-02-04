using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float HEALTH;
	private float health;
	// Use this for initialization
	void Start () {
		health = HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			die ();
	}
	void die(){
		//Destroy (gameObject);
		if(tag==Tags.Building)
		{
			GetComponent<Team>().team=PublicInfo.TEAM.TeamA;//hard code, need change
			GetComponent<TowerCaptured>().Capture();
		}
//		if (HEALTH==200) {
//			Debug.Log("building die");
//			GetComponentInParent<TeamInfo>().targetBuildings.Remove(GetComponentInParent<TeamInfo>().targetBuildings[0]);
//            
//		}
//        if (HEALTH == 100) //inhabitor
//        {
//            Camera.main.GetComponent<GUI_Temp>().lossTeam = GetComponent<Team>().team.ToString();
//           
//        }

	}
	public void BeAttack(float hp)
	{
		//Debug.Log (gameObject+ " lost health "+hp);
		health -= hp;
	}
}
