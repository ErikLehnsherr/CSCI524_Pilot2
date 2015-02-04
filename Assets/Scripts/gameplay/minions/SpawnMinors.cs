using UnityEngine;
using System.Collections;

public class SpawnMinors : MonoBehaviour {
	public GameObject minor;
    public float StartSpawnTime;
    public float SpawnIntervalTime;
	private MinorClass minorClass;
	public PublicInfo.TEAM team;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnMinor", StartSpawnTime , SpawnIntervalTime);
		//minorClass = GetComponent<MinorClass> ();

		team = GetComponentInParent<TeamInfo> ().team;
	}
	void SpawnMinor()
	{
        GameObject newMinor = Instantiate(minor, transform.position + transform.up, transform.transform.rotation) as GameObject;
		newMinor.GetComponent<MinorInfo> ().SetInfo ();
		newMinor.GetComponent<Team> ().team = team;
		//newMinor.GetComponent<MinorMove> ().MoveTarget = GetComponentInParent<TeamInfo> ().targetBuilding;
		//newMinor.GetComponent<MinorMove> ().TeamObject = gameObject.GetComponentInParent<TeamInfo> ();
		for (int i=0; i<2; i++) {
						newMinor.GetComponent<astart> ().target = GetComponentInParent<TeamInfo> ().targetBuildings [i];
			if(newMinor.GetComponent<astart> ().target !=null)break;
				}
		newMinor.transform.parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
