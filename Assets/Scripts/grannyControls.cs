using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://answers.unity3d.com/questions/274809/how-to-make-enemy-chase-player-basic-ai.html
// http://answers.unity3d.com/questions/166666/slow-lookat.html

public class grannyControls : MonoBehaviour {

    Animator anim;
    static GameObject elvis;
    static Camera camera;
    const float triggerDist = 6F;
    const float grannySpeed = 1.55F;
    const float rotSlowFactor = 0.5F;
    bool isChasing;
    bool isFalling;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        elvis = GameObject.Find("elvis");
        camera = Camera.main;
        isChasing = false;
        isFalling = false;
	}
	
	// Update is called once per frame
	void Update () {


        if (!isFalling && transform.position.y < -0.2)
        {
            anim.SetBool("grannyFalling", true);
            isFalling = true;
            camera.GetComponent<menus>().GrannyDied();
        }
        else if (transform.position.y >= -0.2 && ! camera.GetComponent<menus>().hasLost)
        {
            if (elvis.transform.position != null)
            {
                float curDist = Vector3.Distance(transform.position, elvis.transform.position);

                if (!isChasing && (curDist <= triggerDist))
                {
                    anim.SetBool("grannyMoving", true);
                    isChasing = true;
                }
                else if (isChasing && (curDist > triggerDist))
                {
                    anim.SetBool("grannyMoving", false);
                    isChasing = false;
                }
                if (isChasing)
                {
                    var rot = Quaternion.LookRotation(elvis.transform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotSlowFactor);
                    //transform.LookAt(elvis.transform);
                    transform.position += transform.forward * grannySpeed * Time.deltaTime;
                }
            }
        }
        else if (camera.GetComponent<menus>().hasLost)
        {
            anim.SetBool("grannyMoving", false);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "elvis")
        {
            camera.GetComponent<menus>().lost();
        }
    }
}
