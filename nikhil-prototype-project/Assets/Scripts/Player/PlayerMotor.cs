using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public NavMeshAgent agent;

    private Transform target;
    private float smooth = 5f; 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    //Todo: Could be changed into a coroutine for better performance
    private void Update()
    {
        if(target != null)
        {
            MoveToPoint(target.position);
            FaceTarget(); 
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point); 
    }

    public void FollowToInteractable(Interactable newTarget)
    {
        target = newTarget.transform;
        agent.stoppingDistance = newTarget.radius * 0.75f;
        agent.updateRotation = false; 
    }

    public void StopFollowInteractable()
    {
        target = null;
        agent.stoppingDistance = 0.0f;
        agent.updateRotation = true; 
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, smooth * Time.deltaTime); 
    }
}
