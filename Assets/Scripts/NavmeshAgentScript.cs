using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentScript : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    public Vector3 startPos;




    // Use this for initialization
	void Awake () 
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = agent.transform.position;
        Debug.Log(agent.transform.position);

        //Debug.Log("START POS = " + startPos);
    }
	
	// Update is called once per frame
	void Update () 
    {
        agent.SetDestination(target.position);
        Debug.Log("START POS = " + startPos);
    }

    public void TargetPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TargetSelf()
    {
        target = gameObject.transform;
        agent.SetDestination(target.position);
    }

}
