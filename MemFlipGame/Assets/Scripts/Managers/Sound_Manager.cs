using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour,IEventBus_Connector
{
    private IEventBus eventBusRef;

    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        eventBusRef?.Subscribe<GameplayEvent_CardClicked>(PlayCardFlipSound);
        eventBusRef?.Subscribe<GameplayEvent_CorrectCard_Sequence>(Play_CardMatchSound);
        eventBusRef?.Subscribe<GameplayEvent_WrongCard_Sequence>(Play_CardMisMatchSound);
        eventBusRef?.Subscribe<GameplayEvent_LevelEnded>(Play_gameOverSound);

    }
    private void OnDestroy()
    {
        eventBusRef?.Unsubscribe<GameplayEvent_CardClicked>(PlayCardFlipSound);
        eventBusRef?.Unsubscribe<GameplayEvent_CorrectCard_Sequence>(Play_CardMatchSound);
        eventBusRef?.Unsubscribe<GameplayEvent_WrongCard_Sequence>(Play_CardMisMatchSound);
        eventBusRef?.Unsubscribe<GameplayEvent_LevelEnded>(Play_gameOverSound);

    }
    
    [SerializeField] AudioClip cardFlipSound;
    
    [SerializeField] AudioClip cardMatchSound;
    [SerializeField] AudioClip cardMismatchSound;
    
    [SerializeField] AudioClip gameOverSound;


    void PlayCardFlipSound(GameplayEvent_CardClicked x)
    {
        PlaySound(cardFlipSound);
    }
    void Play_CardMatchSound(GameplayEvent_CorrectCard_Sequence x)
    {
        PlaySound(cardMatchSound);
    }
    void Play_CardMisMatchSound(GameplayEvent_WrongCard_Sequence x)
    {
        PlaySound(cardMismatchSound);
    }
    void Play_gameOverSound(GameplayEvent_LevelEnded x)
    {
        PlaySound(gameOverSound);
    }
    void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
    
    
}
