using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour,IEventBus_Connector
{
    private IEventBus eventBusRef;

    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private int comboMultiplier = 1;
    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        eventBusRef.Subscribe<GameplayEvent_CorrectCard_Sequence>(IncerementScore);
        eventBusRef.Subscribe<GameplayEvent_WrongCard_Sequence>(DecrementScore);
        eventBusRef.Subscribe<UI_Event_ComboMultiplerUpdate>(multiplierReceiver);

    }

    private void multiplierReceiver(UI_Event_ComboMultiplerUpdate obj)
    {
        comboMultiplier = obj.comboMultiplier;
    }

    private void OnDestroy()
    {
        eventBusRef.Unsubscribe<GameplayEvent_CorrectCard_Sequence>(IncerementScore);
        eventBusRef.Unsubscribe<GameplayEvent_WrongCard_Sequence>(DecrementScore);
        eventBusRef.Unsubscribe<UI_Event_ComboMultiplerUpdate>(multiplierReceiver);
    }
    
    
    void IncerementScore(GameplayEvent_CorrectCard_Sequence x)
    {
        score += 10 * comboMultiplier ;
        scoreText.text = "Score: "+ score.ToString();
    }
    void DecrementScore(GameplayEvent_WrongCard_Sequence x)
    {
        score -= 25;
        scoreText.text = "Score: "+ score.ToString();
    }
    
    
    
    
}
