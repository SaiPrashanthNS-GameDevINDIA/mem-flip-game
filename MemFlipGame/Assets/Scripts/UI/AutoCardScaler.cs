using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AutoCardScaler : MonoBehaviour
{

    [SerializeField] private int received_RowCount;

    [SerializeField] private GridLayoutGroup gridLayoutReference;

    public void Awake()
    {
        received_RowCount = PlayerPrefs.GetInt("RowCount");
        gridLayoutReference = GetComponent<GridLayoutGroup>();
        SetRowLength();
    }


    [ContextMenu("Set Row Length")]
    public void SetRowLength()
    {
        gridLayoutReference.constraintCount = received_RowCount;

        float adjusted_CellSize = -12.5f * received_RowCount + 165;
        float adjusted_Spacing = -18.75f * received_RowCount + 237.5f;

        gridLayoutReference.cellSize = new Vector2(adjusted_CellSize, adjusted_CellSize);
        gridLayoutReference.spacing = new Vector2(adjusted_Spacing, adjusted_Spacing);
        
        
    }

    
}


