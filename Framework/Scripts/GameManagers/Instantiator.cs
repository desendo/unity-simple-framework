using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    
    

    public GameObject FromPrefab(GameObject obj, Transform parent)
    {
        return Instantiate(obj, parent);
    }

    
    
}
