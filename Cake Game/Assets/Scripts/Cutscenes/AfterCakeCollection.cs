using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCakeCollection : MonoBehaviour
{
    [SerializeField]
    GameObject craftingSystem;

    void Start()
    {
        craftingSystem.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null) {

            if (PlayerPrefs.HasKey("Opening") && FindObjectOfType<Book>().transform.childCount == 5)
            {
                craftingSystem.SetActive(true);
                FindObjectOfType<CraftingSystem>().Buttons.SetActive(true);
                col.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
    }

}
