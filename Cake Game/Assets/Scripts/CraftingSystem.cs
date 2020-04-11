using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public Sprite[] topLayer;
    public Sprite[] middleLayer;
    public Sprite[] bottomLayer;

    int arrowID;
    int arrowID_2;
    int arrowID_3;

    public Image topImage;
    public Image middleImage;
    public Image bottomImage;

    void Start()
    {
        LoadSprites();
    }

    void Update()
    {
       topImage.sprite = topLayer[arrowID];

       middleImage.sprite = middleLayer[arrowID_2];

       bottomImage.sprite = bottomLayer[arrowID_3];

    }

    void LeftArrow(int id)
    {
        
    }

    void RightArrow(int id)
    {
        
    }


    public void LoadSprites()
    {
        object[] topSprites = Resources.LoadAll<Sprite>("TopLayer");
        topLayer = new Sprite[topSprites.Length];

        object[] middleSprites = Resources.LoadAll<Sprite>("MiddleLayer");
        middleLayer = new Sprite[middleSprites.Length];

        object[] bottomSprites = Resources.LoadAll<Sprite>("BottomLayer");
        bottomLayer = new Sprite[bottomSprites.Length];

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


    }




}
