using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 2f; 
    void Update()
    {
        transform.Rotate(0f, 0f, speed);
    }
    
    
}
