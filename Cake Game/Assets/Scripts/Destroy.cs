using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Clock clock;
    public string timeToDestroy;

    void Start()
    {
        clock = FindObjectOfType<Clock>();
    }

    void Update()
    {
        if (clock.time.text == timeToDestroy)
        {
            Destroy(gameObject);
        }
    }


    
}
