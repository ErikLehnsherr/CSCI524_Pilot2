using UnityEngine;
using System.Collections;

public class MinorMove : MonoBehaviour {

	public GameObject MoveTarget; 
	public TeamInfo TeamObject;
	public float speed;
	public bool onMove=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (MoveTarget == null) {
			MoveTarget = TeamObject.targetBuilding;
			onMove=true;
		}

		if (onMove) {

			// The step size is equal to speed times frame time.
			float step = speed * Time.deltaTime;
		
			// Move our position a step closer to the target.
			transform.position = Vector3.MoveTowards (transform.position, MoveTarget.transform.position, step);
		}
	}
}
