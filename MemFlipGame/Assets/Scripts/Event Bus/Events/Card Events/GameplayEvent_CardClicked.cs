using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public readonly struct GameplayEvent_CardClicked
{
    public GameObject Clicked_CardReference { get;  }
    
    public GameplayEvent_CardClicked(GameObject clicked_Card)
    {
        Clicked_CardReference = clicked_Card;
    }
}
