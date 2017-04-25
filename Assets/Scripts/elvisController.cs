using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class elvisController : MonoBehaviour {
    public Transform goal;
    NavMeshAgent agent;
    RaycastHit hit = new RaycastHit();
    static Animator anim;
    Ray r;
    float coolOff;
    float coolOffPeriod = 0.5F;
    menus m;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        coolOff = Time.time - coolOffPeriod;
        m = Camera.main.GetComponent<menus>();
    }
	
	// Update is called once per frame
	void Update () {
        if (m.isStarted() && !m.hasLost)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (coolOff <= Time.time)
                {
                    coolOff = Time.time + coolOffPeriod;
                    r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(r.origin, r.direction, out hit, 100))
                    {
                        agent.destination = hit.point;
                    }
                }
            }
        }
        if (m.hasLost)
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
	}
}
