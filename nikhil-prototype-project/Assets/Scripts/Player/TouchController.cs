using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems; 

[RequireComponent(typeof(PlayerMotor))]
public class TouchController : MonoBehaviour
{

    public Camera cam;
    public PlayerMotor motor; 
    public Interactable focus; 

    private Ray touchRay;
    private RaycastHit hit; 
    private Vector3 distance3d;
    private float distance; 

    private void Awake()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>(); 
    }

    private void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {

            touchRay = cam.ScreenPointToRay(Input.touches[i].position);

            if(Physics.Raycast(touchRay, out hit) && !EventSystem.current.IsPointerOverGameObject(i))
            {
                motor.MoveToPoint(hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>(); 
                if(interactable != null)
                {
                    Debug.Log("Found interactable"); 
                    SetFocus(interactable); 
                }
                else
                {
                    RemoveFocus();  
                }

                //distance3d = transform.position - hit.point;
                //distance = distance3d.magnitude;

                //if (distance > 2)
                //{
                //    agent.SetDestination(hit.point);
                //}
                //else
                //{
                //    hit.transform.gameObject.GetComponent<DialogueInteractable>().TriggerInteraction();  
                //}
                //else if (hit.transform.gameObject.layer == LayerMask.GetMask("Interactive")) 
                //{
                //    Debug.Log("I've been hit"); 
                //}

            }

        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocus();
            }

            focus = newFocus;
            motor.FollowToInteractable(newFocus);
        }

        newFocus.OnFocus(transform); 
    }

    private void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDefocus();
        }

        focus = null;
        motor.StopFollowInteractable(); 
    }
}
