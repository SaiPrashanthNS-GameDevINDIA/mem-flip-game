using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct UI_Event_ScoreUpdate
{
    public int ScoreValue { get; }

    public UI_Event_ScoreUpdate(int scoreValue)
    {
        ScoreValue = scoreValue;
    }
}
