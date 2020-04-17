using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CraftingSystem : MonoBehaviour
{
    public Sprite[] topLayer;
    public Sprite[] middleLayer;
    public Sprite[] bottomLayer;

    public Sprite[] displayTopLayer;
    public Sprite[] displayMiddleLayer;
    public Sprite[] displayBottomLayer;


    public int[] arrowID;


    public Image topImage;
    public Image middleImage;
    public Image bottomImage;

    public Image displayTopImage;
    public Image displayMiddleImage;
    public Image displayBottomImage;

    public bool cakePoision;

    public PlayableDirector winPose;
    public PlayableDirector losePose;

    
    public GameObject Buttons;

    public GameObject blackPanel;
    public Text blackPanelText;

    void Start()
    {
        if (PlayerPrefs.GetInt("Day") == 1)
        {
            LoadSprites();
        }
      

    }

    void Update()
    {
       topImage.sprite = topLayer[arrowID[0]];

       middleImage.sprite = middleLayer[arrowID[1]];

       bottomImage.sprite = bottomLayer[arrowID[2]];

        displayTopImage.sprite = displayTopLayer[arrowID[0]];
        displayMiddleImage.sprite = displayMiddleLayer[arrowID[1]];
        displayBottomImage.sprite = displayBottomLayer[arrowID[2]];

    }

    public void Finish()
    {
        StartCoroutine(CakeFinish());
      
        FindObjectOfType<Player>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        FindObjectOfType<Player>().GetComponent<Transform>().localRotation = new Quaternion(0f,0f,0f,0f);
        FindObjectOfType<Player>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


    }

    IEnumerator CakeFinish()
    {
        var c = (int)Random.Range(0,6);
        var a = (int)Random.Range(0, 5);
        var b = arrowID[0] + arrowID[1] + arrowID[2];

        /*  for (int i = 0; i < transform.childCount; i++)
          {
              GetComponentsInChildren<GameObject>()[i].SetActive(false);
          }
          */

        Buttons.SetActive(false);



        if (c == b || c == a)
        {
            cakePoision = true;
            StartCoroutine(Lose());
        }
        else {
            cakePoision = false;
            StartCoroutine(Win());
        }

        yield return null;
    }

    public void RightArrow(int id)
    {
        if (arrowID[id] < 4) {
            int i = arrowID[id] + 1;
            arrowID[id] = i;
        }
    }

    IEnumerator Win()
    {

        winPose.enabled = true;

        yield return new WaitForSeconds(11);

        winPose.enabled = false;
            
        StartCoroutine(NewDay());

        yield return null;
    }

    IEnumerator Lose()
    {
        losePose.enabled = true;

        if (losePose.state == PlayState.Playing)
        {
            yield return null;
        }
        else {
            losePose.enabled = false;
            StartCoroutine(NewDay());
        }

        yield return null;
    }

    IEnumerator NewDay()
    {
        Time.timeScale = 0;

        var x = PlayerPrefs.GetInt("Day") + 1;

        PlayerPrefs.SetInt("Day", x);

        blackPanelText.text = "Day " + PlayerPrefs.GetInt("Day");

        foreach (Transform child in FindObjectOfType<Book>().transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        blackPanel.SetActive(true);

        yield return new WaitForSeconds(4);

        Time.timeScale = 1;

        Debug.Log(PlayerPrefs.GetInt("Day"));

        blackPanel.SetActive(false);

        LoadSpritesTwo();

        yield return null;
    }

    public void LeftArrow(int id)
    {
        if (arrowID[id] > 0) { 
            int i = arrowID[id] - 1;
            arrowID[id] = i;
        }
    }

    public void LoadSprites()
    {
        object[] topSprites = Resources.LoadAll<Sprite>("TopLayer");
        topLayer = new Sprite[topSprites.Length];

        object[] middleSprites = Resources.LoadAll<Sprite>("MiddleLayer");
        middleLayer = new Sprite[middleSprites.Length];

        object[] bottomSprites = Resources.LoadAll<Sprite>("BottomLayer");
        bottomLayer = new Sprite[bottomSprites.Length];

        object[] displayTopSprites = Resources.LoadAll<Sprite>("Cakes/Top");
        displayTopLayer = new Sprite[displayTopSprites.Length];

        object[] displayMiddleSprites = Resources.LoadAll<Sprite>("Cakes/Middle");
        displayMiddleLayer = new Sprite[displayMiddleSprites.Length];

        object[] displayBottomSprites = Resources.LoadAll<Sprite>("Cakes/Bottom");
        displayBottomLayer = new Sprite[displayBottomSprites.Length];


        for (int x = 0; x < topSprites.Length; x++)
        {
            topLayer[x] = (Sprite)topSprites[x];
        }

        for (int x = 0; x < middleSprites.Length; x++)
        {
            middleLayer[x] = (Sprite)middleSprites[x];
        }

        for (int x = 0; x < bottomSprites.Length; x++)
        {
            bottomLayer[x] = (Sprite)bottomSprites[x];
        }

        //----------------------------------------------//

        for (int x = 0; x < displayTopSprites.Length; x++)
        {
            displayTopLayer[x] = (Sprite)displayTopSprites[x];
        }

        for (int x = 0; x < displayMiddleSprites.Length; x++)
        {
            displayMiddleLayer[x] = (Sprite)displayMiddleSprites[x];
        }

        for (int x = 0; x < displayBottomSprites.Length; x++)
        {
            displayBottomLayer[x] = (Sprite)displayBottomSprites[x];
        }


    }

    public void LoadSpritesTwo()
    {
        object[] topSprites2 = Resources.LoadAll<Sprite>("TopLayer2");
        topLayer = new Sprite[topSprites2.Length];

        object[] middleSprites2 = Resources.LoadAll<Sprite>("MiddleLayer2");
        middleLayer = new Sprite[middleSprites2.Length];

        object[] bottomSprites2 = Resources.LoadAll<Sprite>("BottomLayer2");
        bottomLayer = new Sprite[bottomSprites2.Length];

        object[] displayTopSprites2 = Resources.LoadAll<Sprite>("Cakes/Top2");
        displayTopLayer = new Sprite[displayTopSprites2.Length];

        object[] displayMiddleSprites2 = Resources.LoadAll<Sprite>("Cakes/Middle2");
        displayMiddleLayer = new Sprite[displayMiddleSprites2.Length];

        object[] displayBottomSprites2 = Resources.LoadAll<Sprite>("Cakes/Bottom2");
        displayBottomLayer = new Sprite[displayBottomSprites2.Length];


        for (int x = 0; x < topSprites2.Length; x++)
        {
            topLayer[x] = (Sprite)topSprites2[x];
        }

        for (int x = 0; x < middleSprites2.Length; x++)
        {
            middleLayer[x] = (Sprite)middleSprites2[x];
        }

        for (int x = 0; x < bottomSprites2.Length; x++)
        {
            bottomLayer[x] = (Sprite)bottomSprites2[x];
        }

        //----------------------------------------------//

        for (int x = 0; x < displayTopSprites2.Length; x++)
        {
            displayTopLayer[x] = (Sprite)displayTopSprites2[x];
        }

        for (int x = 0; x < displayMiddleSprites2.Length; x++)
        {
            displayMiddleLayer[x] = (Sprite)displayMiddleSprites2[x];
        }

        for (int x = 0; x < displayBottomSprites2.Length; x++)
        {
            displayBottomLayer[x] = (Sprite)displayBottomSprites2[x];
        }


    }



}
