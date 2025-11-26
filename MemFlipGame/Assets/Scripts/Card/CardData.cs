using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    [SerializeField] private string cardName;
    [SerializeField] private Sprite cardImage;

    [Space(20)] [SerializeField] private Sprite cardHiddenState_Image;
    
    public void SetCardData(string name, Sprite image)
    {
        cardName = name;
        cardImage = image;

        GetComponent<Image>().sprite = cardImage;
        this.gameObject.name = cardName;

    }

    public void SetCardHiddenState()
    {
        GetComponent<Image>().sprite = cardHiddenState_Image;   
    }

    public void SetCardVisibleState()
    {
        GetComponent<Image>().sprite = cardImage;   
    }
    
    public void DisableCard()
    {
        this.gameObject.SetActive(false);
    }
    
}
