using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour,IEventBus_Connector
{
    private IEventBus eventBusRef;

    [SerializeField] private Transform cardSpawn_ParentTransform;
    [SerializeField] private List<GameObject> spawnedCards = new List<GameObject>();

    [SerializeField] private int totalCardCount;
    [SerializeField] private int correctAnswerCount;

    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        Debug.Log("Level Manager Initiated");
        eventBusRef?.Subscribe<GameplayEvent_LevelStarted>(HideCards);
        eventBusRef?.Subscribe<GameplayEvent_CardsSpawnComplete>(GetSpawnedCards);
        eventBusRef?.Subscribe<GameplayEvent_CardClicked>(CheckClickedCards);

    }
    private void OnDestroy()
    {
        eventBusRef?.Unsubscribe<GameplayEvent_LevelStarted>(HideCards);
        eventBusRef?.Unsubscribe<GameplayEvent_CardsSpawnComplete>(GetSpawnedCards);
        eventBusRef?.Unsubscribe<GameplayEvent_CardClicked>(CheckClickedCards);

    }







    [SerializeField] private int clickCount;
     private int maxClickCount = 2;
     [SerializeField] private List<GameObject> receivedCards = new List<GameObject>();

    
    // Process the clicked cards
    void CheckClickedCards(GameplayEvent_CardClicked x)
    {
        
        Debug.Log("CheckClickedCards");
        clickCount++;
        receivedCards.Add(x.Clicked_CardReference);
        
        if (clickCount >= maxClickCount)
        {
            if (receivedCards[0].name == receivedCards[1].name)
            {
                // Cards Match
                Debug.Log("Cards Match");
                
                eventBusRef.Publish(new GameplayEvent_CorrectCard_Sequence());

                
                Invoke(nameof(CorrectSequence_Activated),0.1f);
                Invoke(nameof(ResetClickCount),0.1f);
                correctAnswerCount++;

                
                // All the cards tapped correctly, then level ended
                if (correctAnswerCount == totalCardCount / 2)
                {
                    eventBusRef.Publish(new GameplayEvent_LevelEnded());
                }

            }
            else
            {
                // Cards Dont Match
                Debug.Log("Cards Dont Match");
                
                
                eventBusRef.Publish(new GameplayEvent_WrongCard_Sequence());
                
                Invoke(nameof(WrongSequence_Activated),0.1f);
                Invoke(nameof(ResetClickCount),0.1f);
            }
        }
        Debug.Log("CheckClickedCards");
    }

    private void WrongSequence_Activated()
    {
        foreach (GameObject xCard in receivedCards)
        {
            xCard.GetComponent<CardData>().SetCardHiddenState();
        }
    }

    private void CorrectSequence_Activated()
    {
        foreach (GameObject xCard in receivedCards)
        {
            xCard.GetComponent<CardData>().DisableCard();
        }
    }

    void ResetClickCount()
    {
        clickCount = 0;
        receivedCards.Clear();
    }
    // Get the spawned cards 
    void GetSpawnedCards(GameplayEvent_CardsSpawnComplete x)
    {
        Debug.Log("GetSpawnedCards");

        for (int i = 0; i < cardSpawn_ParentTransform.childCount; i++)
        {
            spawnedCards.Add(cardSpawn_ParentTransform.GetChild(i).gameObject);
        }
        
        totalCardCount = spawnedCards.Count;
    }
    
    // Hide the cards
    private void HideCards(GameplayEvent_LevelStarted x)
    {
        Debug.Log("Cards Hidden");
        
        foreach(GameObject xCard in spawnedCards)
        {
            xCard.GetComponent<CardData>().SetCardHiddenState();
        }
    }
    
}
