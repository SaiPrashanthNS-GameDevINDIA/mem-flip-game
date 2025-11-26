using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private Image cardImage;
    
    public void SetCardData(string name, Sprite image)
    {
        cardName.text = name;
        cardImage.sprite = image;
    }
    
}
