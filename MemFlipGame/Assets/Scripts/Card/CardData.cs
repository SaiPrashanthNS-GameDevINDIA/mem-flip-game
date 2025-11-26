using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    [SerializeField] private string cardName;
    [SerializeField] private Sprite cardImage;
    public void SetCardData(string name, Sprite image)
    {
        cardName = name;
        cardImage = image;
        
        GetComponent<Image>().sprite = cardImage;
        this.gameObject.name = cardName;
        
    }
   
}
