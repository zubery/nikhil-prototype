using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public static Notebook instance; 

    public List<Memory> memories = new List<Memory>();

    public delegate void OnRemembrance();
    public OnRemembrance onRemembranceCallback; 

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Destroyed duplicate notebook");
            Destroy(gameObject);
            return;
        }

        instance = this; 
    }

    public void Add(Memory memory)
    {
        if(!memories.Contains(memory))
        {
            memories.Add(memory);

            if(onRemembranceCallback != null)
            {
                onRemembranceCallback.Invoke();
            }
        }
    }
}
