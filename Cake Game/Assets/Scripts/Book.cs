using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Book : MonoBehaviour
{
    GridLayout grid;
    public int maxCakes = 5;

    public bool enable;

    Animator anim;

    public Text text;

   
   // public AnimationClip openBookPage;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        text.text = transform.childCount + "/" + maxCakes;

        Debug.Log(PlayerPrefs.GetString("cakeToBake"));
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enable =! enable;
        }

        anim.SetBool("openBook", enable);

        if (enable && anim.GetCurrentAnimatorStateInfo(0).IsName("Open_Book_Page"))
        {
            
            for (int i = 0; i < GetComponentsInChildren<Image>().Length; i++)
            {
                GetComponentsInChildren<Image>()[i].enabled = true;
            }
        }
        else if(!enable) {

            
            for (int i = 0; i < GetComponentsInChildren<Image>().Length; i++)
            {
                GetComponentsInChildren<Image>()[i].enabled = false;
            }

        }

    }

    public void AddCake(string id)
    {
       
        var CakeToAdd = Resources.Load<GameObject>(id);
        if (transform.childCount < maxCakes)
        {

            StartCoroutine(CakeSpawn(CakeToAdd));

        }
        else
        {
            Debug.Log("Collection is full!");
        }
   }

    IEnumerator CakeSpawn(GameObject cakeToAdd)
    {
        Instantiate(cakeToAdd, transform.position, transform.rotation, this.transform);
        PlayerPrefs.DeleteKey("cakeToBake");
        Debug.Log("Child Count:" + transform.childCount);
        PlayerPrefs.DeleteKey("cakeToBake");
        yield return null;
    }

 }
