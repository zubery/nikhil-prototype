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

    private Ray touchRay;
    private RaycastHit hit;
    public float lambda; 
    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        lambda = 15.0f;

        StartCoroutine("GyroPuzzle"); 
    }

    IEnumerator GyroPuzzle()
    {
        bool solved = false;

        if(gyro && !Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
        }

        while(!solved)
        {
            ring1.Rotate(0.0f, Input.gyro.rotationRateUnbiased.x * 10.0f, 0.0f);
            ring2.Rotate(0.0f, Input.gyro.rotationRateUnbiased.y * 5.0f, 0.0f);
            ring3.Rotate(0.0f, Input.gyro.rotationRateUnbiased.z * 2.5f, 0.0f);

            int angleEqual = AnglesEqual(ring1.transform.eulerAngles.y, 
                ring2.transform.eulerAngles.y, 
                ring3.transform.eulerAngles.y); 

            if(angleEqual != -1)
            {
                Debug.Log("FIXED!! " + angleEqual);



                ring1.rotation = Quaternion.Euler(0.0f, angleEqual, 0.0f);
                ring2.rotation = Quaternion.Euler(0.0f, angleEqual, 0.0f);
                ring3.rotation = Quaternion.Euler(0.0f, angleEqual, 0.0f);

                solved = true; 
            }

            yield return null; 
        }
    }

    public int AnglesEqual(float angle1, float angle2, float angle3)
    {
        float deltaOneTwo;
        float deltaOneThree;
        float deltaTwoThree; 

        if(angle1 < 0)
        {
            angle1 = 360.0f + angle1; 
        }

        if (angle2 < 0)
        {
            angle2 = 360.0f + angle2;
        }

        if(angle3 < 0)
        {
            angle3 = 360.0f + angle3;
        }

        deltaOneTwo = Mathf.Abs(angle1 - angle2);
        deltaOneThree = Mathf.Abs(angle1 - angle3);
        deltaTwoThree = Mathf.Abs(angle2 - angle3); 

        if(deltaOneTwo < lambda && deltaOneThree < lambda && deltaTwoThree < lambda)
        {
            return (int)((angle1 + angle2 + angle3) / 3.0f); 
        }
        else
        {
            return -1;
        }
    }
}
