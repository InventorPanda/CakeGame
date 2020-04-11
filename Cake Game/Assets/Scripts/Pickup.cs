using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string cakeID;
    bool inRange;

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetString("cakeToBake", cakeID);
                FindObjectOfType<Book>().AddCake(PlayerPrefs.GetString("cakeToBake"));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            inRange = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;
    }

}
