using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentScript : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    public Transform startPos;




    // Use this for initialization
	void Awake () 
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = gameObject.transform;
        Debug.Log(agent.transform.position);

        Debug.Log("START POS = " + startPos.position);
    }
	
	// Update is called once per frame
	void Update () 
    {
        agent.SetDestination(target.position);
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
