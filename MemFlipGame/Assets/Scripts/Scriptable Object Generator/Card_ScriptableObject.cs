using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Card Game/Create Card")]
public class Card_ScriptableObject : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
}
