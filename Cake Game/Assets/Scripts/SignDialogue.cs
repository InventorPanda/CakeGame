using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public string dialog;
    public Text dialogText;
    public bool playerInRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

}
