using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card_Interaction : MonoBehaviour, IPointerClickHandler, IEventBus_Connector
{
    private IEventBus eventBusRef;

    [SerializeField] private bool isCardInteractable = false;
    
    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        eventBusRef.Subscribe<GameplayEvent_LevelStarted>(OnLevelStarted);
    }
    
    
    
    private void OnDestroy()
    {
        eventBusRef.Unsubscribe<GameplayEvent_LevelStarted>(OnLevelStarted);
    }

    void OnLevelStarted(GameplayEvent_LevelStarted x)
    {
        isCardInteractable = true;
    }
    
    
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCardInteractable)
        {
            GetComponent<CardData>().SetCardVisibleState();

            eventBusRef?.Publish(new GameplayEvent_CardClicked(this.gameObject));
        }
    }


   
}
