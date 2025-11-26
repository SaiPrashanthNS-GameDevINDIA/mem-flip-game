using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card_Interaction : MonoBehaviour, IPointerClickHandler, IEventBus_Connector
{
    private IEventBus eventBusRef;
    
    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;

    }
    
    
    
    private void OnDestroy()
    {
    }
    
    
    
    
    

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Card Clicked via UI!");
        GetComponent<CardData>().SetCardVisibleState();

        eventBusRef?.Publish(new GameplayEvent_CardClicked(this.gameObject));
    }


   
}
