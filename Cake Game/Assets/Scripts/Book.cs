using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Book : MonoBehaviour
{
    GridLayout grid;
    public int maxCakes = 5;

    string addcake = "2";

    void Update()
    {

        if (transform.childCount < maxCakes)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AddCake(addcake);
            }
        }
        else {
            Debug.Log("Collection is full!");
        }

    }

    public void AddCake(string id)
    {
        var CakeToAdd = Resources.Load<GameObject>(id);
        StartCoroutine(CakeSpawn(CakeToAdd));
    }

    IEnumerator CakeSpawn(GameObject cakeToAdd)
    {
        Instantiate(cakeToAdd, transform.position, transform.rotation, this.transform);
        Debug.Log("Child Count:" + transform.childCount);
        yield return null;
    }

 }
