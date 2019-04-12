using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public LayerMask playerLayer;
    public LayerMask interactableLayer;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Destroyed duplicate game manager"); 
            Destroy(gameObject);
            return; 
        }

        instance = this; 
    }
}
