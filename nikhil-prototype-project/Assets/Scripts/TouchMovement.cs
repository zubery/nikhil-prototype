using UnityEngine;
using UnityEngine.AI; 

public class TouchMovement : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent; 

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Debug.Log("touch"); 

            Ray touchRay = cam.ScreenPointToRay(Input.touches[i].position);
            RaycastHit hit; 

            if(Physics.Raycast(touchRay, out hit))
            {
                agent.SetDestination(hit.point); 
            }

            //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            //Debug.DrawLine(Vector3.zero, touchPosition, Color.red); 
        }
    }
}
