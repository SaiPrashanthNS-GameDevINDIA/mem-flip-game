using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StartMenu_Manager : MonoBehaviour
{
    
    // Switch On to randomize the card count
    [SerializeField] private bool randomize_CardCount;
    
    
    // Slider to change the row and column count - for custom challenges
    [SerializeField] private Slider row_SliderReference;
    [SerializeField] private Slider column_SliderReference;

    [SerializeField] private TextMeshProUGUI row_Value;
    [SerializeField] private TextMeshProUGUI col_Value;


    void Start()
    {
        // Update the slider with minimum card values - 3 for now
        UpdateSlider_MinumumValue_Text();
    }


    
    // Randomize the card count
    public void Randomize_CardCount()
    {
            randomize_CardCount = !randomize_CardCount;
            if (randomize_CardCount)
            {
                RandomizeCard_Row_Column();
            }
    }

    private void RandomizeCard_Row_Column()
    {
        // Minimum is 3 rows and 3 columns
        // Maximum is 6 rows and 8 columns
        int row = Random.Range(3, 6);
        int col = Random.Range(3, 8);
        
        row_SliderReference.value = row;
        column_SliderReference.value = col;
    }

    public void Set_Row()
    {
        row_Value.text = "Rows - " +row_SliderReference.value.ToString();
    }
    public void Set_Column()
    {
        col_Value.text = "Columns - " +column_SliderReference.value.ToString();
    }


    void UpdateSlider_MinumumValue_Text()
    {
        row_Value.text = "Rows - " +row_SliderReference.minValue.ToString();
        col_Value.text = "Columns - " +column_SliderReference.minValue.ToString();
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("RowCount",(int)row_SliderReference.value);
        PlayerPrefs.SetInt("ColumnCount",(int)column_SliderReference.value);

        
        Application.LoadLevel("GameScene");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
