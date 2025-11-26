using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour,IEventBus_Connector
{
    private IEventBus eventBusRef;

    
    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        Debug.Log("Level Manager Initiated");
        eventBusRef?.Subscribe<GameplayEvent_LevelStarted>(HideCards);
    }
    private void OnDestroy()
    {
        eventBusRef?.Unsubscribe<GameplayEvent_LevelStarted>(HideCards);

    }


    private void HideCards(GameplayEvent_LevelStarted x)
    {
        Debug.Log("Cards Hidden");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
