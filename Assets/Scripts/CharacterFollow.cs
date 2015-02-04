using UnityEngine;
using System.Collections;

public class CharacterFollow : MonoBehaviour
{
	private Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public Transform myTransform;
	public float range1 = 9.0f;
	public float range2 = 10.0f;
	public float stop = 0.0f;
	private GameObject [] gos=new GameObject[3];
	private float distance;
		private GameObject leader;
    
	void Awake ()
	{
		myTransform = transform;
	}
	// Use this for initialization
	void Start ()
	{
		moveSpeed = 3;
		rotationSpeed = 2;
		//leader=
		target = FindClosestPlayer().transform;
	}
	GameObject FindClosestPlayer() {
		GameObject closest = GameObject.FindGameObjectWithTag("Viking");;
		//GameObject go;

		gos = GameObject.FindGameObjectsWithTag("Viking");
		distance = Mathf.Infinity;
		foreach (GameObject go in gos){

			Vector3 diff = go.transform.position - transform.position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	// Update is called once per frame
	void Update ()
	{
		var distance = Vector3.Distance (myTransform.position, target.position);
		var lookDir = target.position - myTransform.position;
		lookDir.y = 0;
		if (distance <= range2 && distance >= range1) {
						myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
			                                         Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
			}
		else if (distance <=range1 && distance>stop){
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
			                                         Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		else if (distance <= stop) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
			                                         Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
		}
	}
}

