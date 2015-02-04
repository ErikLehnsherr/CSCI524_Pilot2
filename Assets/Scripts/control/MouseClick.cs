using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {
    public Texture2D cursorAttack;
    public Texture2D cursorMove;
    public Texture2D cursorPet;
    public CursorMode cursorMode;
    public Vector2 hotSpot;
    public GameObject player;
    public GameObject mouseClickParticle;
	// Use this for initialization
	void Start () {
        hotSpot=Vector2.zero;
       // Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject choosedObj = Camera.main.GetComponent<GUI_Temp>().choosedObj;
        if(Physics.Raycast(ray,out hitInfo))
        {
          //  Debug.Log(hitInfo.collider);
            if (hitInfo.collider.tag == Tags.Building||hitInfo.collider.tag==Tags.Minor)
            {
                if (hitInfo.collider.GetComponent<Team>() != null && choosedObj.GetComponent<Team>() != null && hitInfo.collider.GetComponent<Team>().team != choosedObj.GetComponent<Team>().team)
                {
                    Cursor.SetCursor(cursorAttack, hotSpot, cursorMode);
                    if (Input.GetMouseButtonDown(1))
                    {

                        if (Vector3.Distance(choosedObj.transform.position, hitInfo.collider.gameObject.transform.position) > choosedObj.GetComponent<BasicInfo>().attackRange)
                        choosedObj.GetComponent<AstarPlayer>().SetTarget(hitInfo.collider.gameObject);
                        else
                        choosedObj.GetComponent<Attack>().AttackSimple(hitInfo.collider.gameObject);
                        Debug.Log("hit");
                    }
                }
                
            }
            else if (hitInfo.collider.tag == Tags.Pet)
            {

                Cursor.SetCursor(cursorPet, hotSpot, cursorMode);
                if (Input.GetMouseButtonDown(0))
                {
                    Camera.main.GetComponent<GUI_Temp>().choosedObj = hitInfo.collider.gameObject;
                    Debug.Log("pet");
                }
            }
            else if (hitInfo.collider.tag == Tags.Player)
            {

                Cursor.SetCursor(cursorPet, hotSpot, cursorMode);
                if (Input.GetMouseButtonDown(0))
                {
                    Camera.main.GetComponent<GUI_Temp>().choosedObj = hitInfo.collider.gameObject;
                    Debug.Log("player");
                }
            }
            else
            {
                Cursor.SetCursor(cursorMove, hotSpot, cursorMode);
                if (Input.GetMouseButtonDown(1))
                {
                  //  Instantiate(mouseClickParticle,hitInfo.point+transform.up*4,transform.rotation);
                    choosedObj.GetComponent<AstarPlayer>().SetTarget(hitInfo.point);
                }
            }
        }

	
	}
}
