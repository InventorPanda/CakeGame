using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        LoadSprites();
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
    }

    IEnumerator CakeFinish()
    {
        var c = (int)Random.Range(0,6);
        var b = arrowID[0] + arrowID[1] + arrowID[2];

        if (c == b)
        {
            cakePoision = true;
        }
        else {
            cakePoision = false;
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




}
