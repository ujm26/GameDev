using UnityEngine;
using System.Collections.Generic;

public class DontDestroy : MonoBehaviour
{
    private static List<GameObject> persistentObjects = new List<GameObject>();  
    public int objectIndex;

    void Awake()
    {
      
        while (persistentObjects.Count <= objectIndex)
        {
            persistentObjects.Add(null); 
        }

      
        if (persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject); 
        }
    }
}
