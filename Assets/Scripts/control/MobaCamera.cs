using UnityEngine;
using System.Collections;

public class MobaCamera : MonoBehaviour {

    public float moveEdge=10;
    public float moveSpeed = 5;
	public float zoomSpeed=1;
	public float zoomMin=5;
	public float zoomMax=40;
	private bool lockOnHero=true;
	public GameObject player;
	// Use this for initialization
	void Start () {
		//transform.parent = null;
	}
	public void ChangeLockOnHero()
	{
		if(lockOnHero)
		{
			gameObject.transform.parent=null;
		}
		else{
			gameObject.transform.parent=player.transform;
			returnToHero();
		}
		lockOnHero = !lockOnHero;
	}
	public void returnToHero(){
		float scale=transform.position.y/9;
		transform.position=player.transform.TransformPoint(new Vector3(5f,9,-8f)*scale);
	}
	// Update is called once per frame
	void Update () {
		if (lockOnHero) {


		} else {
						if (Input.mousePosition.x < moveEdge) {
								transform.position -= transform.right * Time.deltaTime * moveSpeed;
						} else if (Input.mousePosition.x > Screen.width - moveEdge) {
								transform.position += transform.right * Time.deltaTime * moveSpeed;
						}
						if (Input.mousePosition.y < moveEdge) {
								transform.position -= (transform.up + transform.forward) * Time.deltaTime * moveSpeed / 1.414f;
						}
						if (Input.mousePosition.y > Screen.height - moveEdge) {
								transform.position += (transform.up + transform.forward) * Time.deltaTime * moveSpeed / 1.414f;
						}
			}
		if (Input.GetAxis("Mouse ScrollWheel")<0) // forward
		{
			if(Camera.main.transform.position.y<zoomMax)
				Camera.main.transform.position=(Camera.main.transform.position+new Vector3(zoomSpeed,zoomSpeed,-zoomSpeed));
		}
		if (Input.GetAxis("Mouse ScrollWheel")>0) // forward
		{
			if(Camera.main.transform.position.y>zoomMin)
				Camera.main.transform.position=(Camera.main.transform.position-new Vector3(zoomSpeed,zoomSpeed,-zoomSpeed));
		}
	}
}
