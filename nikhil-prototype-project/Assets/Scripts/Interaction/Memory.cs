using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Memory", menuName = "Notebook/Memory")]
public class Memory : ScriptableObject
{
    new public string name = "";
    public string description = ""; 
    public Sprite icon = null; 
}
