using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboManager : MonoBehaviour,IEventBus_Connector
{
    [SerializeField] private int comboMultiplier = 1;
    [SerializeField] private TextMeshProUGUI comboText;

    private IEventBus eventBusRef;
    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        eventBusRef.Subscribe<GameplayEvent_CorrectCard_Sequence>(IncrementCombo);
        eventBusRef.Subscribe<GameplayEvent_WrongCard_Sequence>(ResetCombo);

    }
    private void OnDestroy()
    {
        eventBusRef.Unsubscribe<GameplayEvent_CorrectCard_Sequence>(IncrementCombo);
        eventBusRef.Unsubscribe<GameplayEvent_WrongCard_Sequence>(ResetCombo);
    }

    
    void IncrementCombo(GameplayEvent_CorrectCard_Sequence x)
    {
        comboMultiplier++;
        comboText.text = "Combo "+ comboMultiplier.ToString()+"x";
        eventBusRef.Publish(new UI_Event_ComboMultiplerUpdate(comboMultiplier));
    }
    void ResetCombo(GameplayEvent_WrongCard_Sequence x)
    {
        comboMultiplier = 1;
        comboText.text = "";

        eventBusRef.Publish(new UI_Event_ComboMultiplerUpdate(comboMultiplier));

    }
    
}
