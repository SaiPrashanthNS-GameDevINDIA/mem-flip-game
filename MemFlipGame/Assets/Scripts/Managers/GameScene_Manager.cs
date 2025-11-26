using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene_Manager : MonoBehaviour,IEventBus_Connector
{
    [SerializeField] private CanvasGroup pauseMenuUI;
    [SerializeField] private CanvasGroup levelCompleteUI;

    [SerializeField] private TextMeshProUGUI gameStartTimer_Text;

    private IEventBus eventBusRef;

    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
        eventBusRef.Subscribe<GameplayEvent_LevelEnded>(LevelComplete_UI);
    }
    private void OnDestroy()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartGame_Sequence());
    }

    IEnumerator StartGame_Sequence()
    {
        // Wait for timer to finish
        yield return StartCoroutine(GameStartTimer(4));
        
        // Send event - Notifying level started 
        eventBusRef?.Publish(new GameplayEvent_LevelStarted());

        
    }

    

    IEnumerator GameStartTimer(int startValue)
    {
      
            int timer = startValue;
            while (timer > 0)
            {
                gameStartTimer_Text.text = "Game Starts In " + timer + "...";
                yield return new WaitForSeconds(1f);
                timer--;
            }

            gameStartTimer_Text.text = "Go!";
            yield return new WaitForSeconds(1f);
            gameStartTimer_Text.text = "";
            yield break;

    }

    void LevelComplete_UI(GameplayEvent_LevelEnded x)
    {
        levelCompleteUI.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.gameObject.SetActive(true);
        Debug.Log("Game Paused");
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        pauseMenuUI.gameObject.SetActive(false);
        Debug.Log("Game Resumed");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

    
}
