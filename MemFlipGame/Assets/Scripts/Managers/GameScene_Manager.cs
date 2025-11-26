using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene_Manager : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseMenuUI;
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PauseGame()
    {
        pauseMenuUI.gameObject.SetActive(true);
        Debug.Log("Game Paused");
    }
    
    public void ResumeGame()
    {
        pauseMenuUI.gameObject.SetActive(false);
        Debug.Log("Game Resumed");
    }

    public void RestartGame()
    {
        Application.LoadLevel("GameScene");
    }
    
    public void QuitGame()
    {
        
        
        
        Application.LoadLevel("StartMenu");

    }
}
