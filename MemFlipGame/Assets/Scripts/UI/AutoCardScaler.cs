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
        gridLayoutReference = GetComponent<GridLayoutGroup>();
    }


    [ContextMenu("Set Row Length")]
    public void SetRowLength()
    {
        //received_RowCount = length;
        gridLayoutReference.constraintCount = received_RowCount;

        float adjusted_CellSize = -12.5f * received_RowCount + 145;
        float adjusted_Spacing = -18.75f * received_RowCount + 237.5f;

        gridLayoutReference.cellSize = new Vector2(adjusted_CellSize, adjusted_CellSize);
        gridLayoutReference.spacing = new Vector2(adjusted_Spacing, adjusted_Spacing);
        
        
    }

    
}


