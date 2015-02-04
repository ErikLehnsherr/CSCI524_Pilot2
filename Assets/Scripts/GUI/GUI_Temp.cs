using UnityEngine;
using System.Collections;

public class GUI_Temp : MonoBehaviour {

    public GameObject hero;
    public GameObject choosedObj;
    public string lossTeam;
	private string msg;
	// Use this for initialization
	void Start () {
        choosedObj = hero;
        lossTeam = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void MessageToWorld(string m)
	{
		msg = m;
		//vanish after several seconds

	}


    void OnGUI()
    {
        if (choosedObj == hero)
        {
            if (GUI.Button(new Rect(20, 40, 80, 20), "Create Pet"))
            {
                hero.GetComponent<HeroPet>().CreatePet();
            }
        }
        else 
        {
            if (GUI.Button(new Rect(20, 40, 80, 20), "Wander"))
            {
                
            }
            if (GUI.Button(new Rect(20, 100, 80, 20), "Stay"))
            {

            }
            if (GUI.Button(new Rect(20, 160, 80, 20), "Follow"))
            {

            }
        }
        if (lossTeam!=null)
        {
            GUI.Label(new Rect(10, 10, 100, 90), lossTeam + " loss");
            Time.timeScale = 0;
        }

		GUI.Label(new Rect(400, 10, 100, 90), "money: ");
		GUI.Label(new Rect(400, 50, 100, 90), "Captured: ");
		GUI.Label(new Rect(100, 10, 100, 90), msg);
        
        
    }
}
