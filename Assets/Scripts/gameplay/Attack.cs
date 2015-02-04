using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public float AttackTime;//rate of attack, 
    public float damage;
    public GameObject attackee;// the obj that being attacked. minions will follow the attackee until out of sight range

    private float attackTime;

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
        if (attackTime > 0)
            attackTime--;

	}
    public void AttackSimple(GameObject obj)//for minions
    {
        attackee = obj;
        if(attackTime<=0)//attack cool down
        {
            doAttack();
            attackTime = AttackTime;
        }
    
    }
    void doAttack()
    {
        attackee.GetComponent<Health>().BeAttack(damage);//need to consider attackee's armor later
        //there should be animation;
        //transform.rigidbody.AddForce(new Vector3(0, 1, 0));

            
    }

}
