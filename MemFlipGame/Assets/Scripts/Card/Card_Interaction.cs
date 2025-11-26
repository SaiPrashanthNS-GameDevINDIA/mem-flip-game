using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card_Interaction : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover ON");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover OFF");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Card Clicked via UI!");
        
    }
    
    
    
}
