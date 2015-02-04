using UnityEngine;
using System.Collections;

public class MinorAI : MonoBehaviour {
	public float attackRange;
	public float seeRange;

    public enum State { attack, move };
    public State state;

	private MinorInfo info;
    private GameObject AttackingObj;
	// Use this for initialization
	void Start () {
        state = State.move;
		info = GetComponent<MinorInfo> ();
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] attackable= Physics.OverlapSphere (transform.position, attackRange);
		Collider[] seeable= Physics.OverlapSphere (transform.position, seeRange);
       // state=State.move;
		foreach (Collider col in seeable) {
			if(col.GetComponent<Team>()!=null&&col.GetComponent<Team>().team!=GetComponent<Team>().team)
			{
				//Debug.Log(gameObject+" see "+col.gameObject);
				GetComponent<astart>().target=col.gameObject;
				GetComponent<astart>().ReDirect();
				break;

			}
		}
		foreach (Collider col in attackable) {
            
			if(col.GetComponent<Team>()!=null&&col.GetComponent<Team>().team!=GetComponent<Team>().team)
			{
//				
				//Debug.Log("stop");
                state=State.attack;
                GetComponent<astart>().Stay();
				//Attack(col.gameObject);
                GetComponent<Attack>().AttackSimple(col.gameObject);
                AttackingObj=col.gameObject;
				break;

			}
		}
        if (state == State.attack & AttackingObj == null)
        {
            GetComponent<astart>().RestartMove();
        }
	}
	void Attack(GameObject obj)
	{
		//obj.SendMessage ("BeAttack",info.attack, SendMessageOptions.DontRequireReceiver);
	}
}
