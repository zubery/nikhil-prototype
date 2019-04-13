using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixMemory : MonoBehaviour
{
    public bool gyro;
    public bool repair;

    public Transform ring1;
    public Transform ring2;
    public Transform ring3; 

    public void Update()
    {

        Debug.Log("In"); 

        if(gyro && !Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
            Debug.Log("Gyro enabled");
        }

        if(Input.gyro.enabled)
        {
            Debug.Log("Rotating?");

            ring1.Rotate(0.0f, Input.gyro.rotationRateUnbiased.x, 0.0f);
            ring2.Rotate(0.0f, Input.gyro.rotationRateUnbiased.y, 0.0f);
            ring3.Rotate(0.0f, Input.gyro.rotationRateUnbiased.z, 0.0f);

            if(Mathf.Approximately(ring1.transform.eulerAngles.y, 0.0f) &&
                Mathf.Approximately(ring2.transform.eulerAngles.y, 0.0f) &&
                Mathf.Approximately(ring3.transform.eulerAngles.y, 0.0f))
            {
                Debug.Log("FIXED!!"); 
            }
        }
    }
}
