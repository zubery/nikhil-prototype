using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    private bool isFocus = false;
    private bool hasInteracted = false; 
    private Transform playerTransform;

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(playerTransform.position, transform.position); 

            if(distance <= radius)
            {
                //Todo: INTERACT
                Interact(); 
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {

    }

    public void OnFocus(Transform newTransform)
    {
        isFocus = true;
        playerTransform = newTransform;
        hasInteracted = false;  
    }

    public void OnDefocus()
    {
        isFocus = false;
        playerTransform = null;
        hasInteracted = false; 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}
