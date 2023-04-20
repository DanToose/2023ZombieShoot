using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentScript : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent; 

    // Use this for initialization
	void Awake () 
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
