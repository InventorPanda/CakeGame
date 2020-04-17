using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public Transform telePoint;
    public GameObject Panel;

    void Start()
    {
        Panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            StartCoroutine(Move());
        }
        else {
            return;
        }
    }

    IEnumerator Move()
    {
        Panel.SetActive(true);

        yield return new WaitForSeconds(1);

        FindObjectOfType<Player>().transform.position = telePoint.position;

        yield return new WaitForSeconds(1);

        Panel.SetActive(false);

        yield return null;
    }
}
