using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string cakeID;
    bool inRange;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            inRange = true;
            StartCoroutine(Collect());
        }
    }

    IEnumerator Collect()
    {

        PlayerPrefs.SetString("cakeToBake", cakeID);

        FindObjectOfType<Book>().AddCake(PlayerPrefs.GetString("cakeToBake"));

        audio.Play();

        inRange = false;

        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(1);

        Destroy(gameObject);

        yield return null;
    }

}
