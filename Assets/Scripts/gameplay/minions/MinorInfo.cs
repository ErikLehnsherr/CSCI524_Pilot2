using UnityEngine;
using System.Collections;

public class MinorInfo : MonoBehaviour {

	//public float health;
	public float attack;
	public float armor;
	public PublicInfo.TEAM team;

	// Use this for initialization
	void Start () {

	}
	public void SetInfo(float health_t,float attack_t,float armor_t)
	{
		attack = attack_t;
		armor = armor_t;
	}
	public void SetInfo()
	{
		attack = MinorClass.attack;
		armor = MinorClass.armor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
