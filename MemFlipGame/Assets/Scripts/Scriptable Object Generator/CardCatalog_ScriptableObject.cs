using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


[CreateAssetMenu(menuName = "Card Game/Create Card Catalog")]
public class CardCatalog_ScriptableObject : ScriptableObject
{
    
    // We need AssetReference of type Card
    // Restriction to add only Card Scriptable object type
    public List<AssetReferenceT<Card_ScriptableObject>> cardReferences = new List<AssetReferenceT<Card_ScriptableObject>>();



    // Get Random Card
    public AssetReferenceT<Card_ScriptableObject> GetRandomCard()
    {
        if (cardReferences == null || cardReferences.Count == 0)
        {
            Debug.LogError("Card catalog empty");
        }
        return cardReferences[Random.Range(0, cardReferences.Count)];
    }
    
    
    
    
    
    
    
    
}
    