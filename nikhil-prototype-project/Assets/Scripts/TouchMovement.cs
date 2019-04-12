﻿using UnityEngine;
using UnityEngine.AI; 

public class TouchMovement : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;

    private Ray touchRay;
    private RaycastHit hit; 
    private Vector3 distance3d;
    private float distance; 

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {

            touchRay = cam.ScreenPointToRay(Input.touches[i].position); 

            if(Physics.Raycast(touchRay, out hit))
            {
                distance3d = transform.position - hit.point;
                distance = distance3d.magnitude;

                if (distance > 2)
                {
                    agent.SetDestination(hit.point);
                }
                else
                {
                    Debug.Log(hit.transform.gameObject.layer);
                    //Debug.Log(); 
                }
                //else if (hit.transform.gameObject.layer == LayerMask.GetMask("Interactive")) 
                //{
                //    Debug.Log("I've been hit"); 
                //}

            }

        }
    }
}
