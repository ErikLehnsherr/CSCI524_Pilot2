﻿using UnityEngine;
using System.Collections;
using Pathfinding;

public class AstarPlayer : MonoBehaviour {
	Seeker seeker;
	public GameObject target;
	public Path path;
	private CharacterController controller;
	//The AI's speed per second
	public float speed = 10;
	public bool isLogging=false;
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
		seeker=GetComponent<Seeker> ();
		controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			
		}
	}

	public void SetTarget(GameObject obj){
		seeker.StartPath (transform.position, obj.transform.position,OnPathComplete);
	}
    public void SetTarget(Vector3 tra)
    {
        
        seeker.StartPath(transform.position, tra, OnPathComplete);
		if(isLogging)Debug.Log("set target");
    }

	public void FixedUpdate () {
		if (path == null) {
			//We have no path to move after yet
			if(isLogging)Debug.Log("no path");
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if(isLogging)Debug.Log ("End Of Path Reached");
			return;
		}
		
		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		controller.SimpleMove (dir);
		if(isLogging)Debug.Log("moving"+currentWaypoint);
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}

	public void OnPathComplete (Path p) {
		if(isLogging)Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
}
