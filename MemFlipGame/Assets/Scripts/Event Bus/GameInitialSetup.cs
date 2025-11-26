using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialSetup : MonoBehaviour
{
    
    private EventBus gameplay_EventBus;

    [SerializeField] private List<GameObject> managerReferences = new List<GameObject>();

    private void Awake()
    {
        // Event bus that will carry gameplay events across systems.
        gameplay_EventBus = new EventBus();

        
        // Get all the game objects and load the gameplay event bus
        // using the interface to get them
        foreach (var managerRef in managerReferences)
        {
            if (managerRef.TryGetComponent<IEventBus_Connector>(out var connector))
            {
                connector.InitEventBus(gameplay_EventBus);
            }
        }


    }
    
}
