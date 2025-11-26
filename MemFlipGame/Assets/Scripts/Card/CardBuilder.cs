using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CardBuilder : MonoBehaviour,IEventBus_Connector
{
    private IEventBus eventBusRef;

    public void InitEventBus(IEventBus eventBus)
    {
        eventBusRef = eventBus;
    }
    
    
    // TODO
    //  Card Prefab - to be changed in to addressabele in future  
    [SerializeField] private GameObject cardPrefab;
    
    // Asset Reference to Card Catalog - type safe AssetReferenceT link via GUID
    [SerializeField] private AssetReferenceT<CardCatalog_ScriptableObject> cardCatalog_GUID_Reference;
    
    
    // Interface reference to addressable loader 
    private IAssetLoader _asyncAddressableLoader;
    
    
    // Card Catalog object loaded from the asset reference using GUID AssetReferenceT
    private CardCatalog_ScriptableObject cardCatalog_SO_Reference;
    [SerializeField] private bool isInitialized;


    [Space(20)] [SerializeField] private GameObject canvasRef;
    public List<int> generatedIndex = new List<int>(); // List of Card Objects loaded from the AssetReferenceT

    async void Start()
    {
        // create the addressable loader
        _asyncAddressableLoader = new AddressableAssetLoader();
        
        // Populate the card catalog from the GUID reference 
        cardCatalog_SO_Reference = await _asyncAddressableLoader.Load(cardCatalog_GUID_Reference);

        if (cardCatalog_SO_Reference != null)
        {
            isInitialized = true;
            
            
            int rowCount = PlayerPrefs.GetInt("RowCount");
            int columnCount = PlayerPrefs.GetInt("ColumnCount");

            int cardCount = rowCount * columnCount;
            
            // If card count is odd
            if (cardCount % 2 != 0)
            {
                cardCount++;
            }
            PlayerPrefs.SetInt("CardCount",cardCount);
            
            spawnCards(cardCount/2);
        }

        Debug.Log(cardCatalog_SO_Reference.cardReferences.Count);
    }


    public async Task spawnCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            await SpawnRandomCard(canvasRef.transform);
        }

        ShuffleCards();
    }
    
    int GenerateRandomNumber()
    {
        int randomIndex = Random.Range(0, cardCatalog_SO_Reference.cardReferences.Count);

        if (generatedIndex.Contains(randomIndex))
        {
            return  GenerateRandomNumber();
        }
        generatedIndex.Add(randomIndex);
        return randomIndex;
    }
    public async Task SpawnRandomCard(Transform parent = null)
    {

        // GetRandomCard
        var cardRef = cardCatalog_SO_Reference.GetCard(GenerateRandomNumber());

       
   
        // Load Card Data
        var cardData = await _asyncAddressableLoader.Load(cardRef);
        if (cardData == null)
        {
            Debug.LogError("CardSpawner: Failed to load CardData.");
        }
        

        // Instantiate the cards - we need two cards per card data
        var cardInstance = Instantiate(cardPrefab, parent);
        var cardInstance_Copy2 = Instantiate(cardPrefab, parent);
       
       
        cardInstance_Copy2.GetComponent<CardData>().SetCardData(cardData.cardName, cardData.cardImage);
        cardInstance.GetComponent<CardData>().SetCardData(cardData.cardName, cardData.cardImage);
        
        cardInstance_Copy2.GetComponent<Card_Interaction>().InitEventBus(eventBusRef);
        cardInstance.GetComponent<Card_Interaction>().InitEventBus(eventBusRef);
        
        if( cardRef!=null)
        {        
            _asyncAddressableLoader.Release(cardRef);
        }
    }

    public void ShuffleCards()
    {
        for (int i = 0; i < canvasRef.transform.childCount; i++)
        {
            int randomIndex = Random.Range(0, canvasRef.transform.childCount);
            canvasRef.transform.GetChild(i).transform.SetSiblingIndex(randomIndex);
        }
        eventBusRef?.Publish(new GameplayEvent_CardsSpawnComplete());
        Debug.Log("ShuffleCards");
        
        // Disable Grid Layout Group as we will be removing the cards in the game and it should not auto adjust 
        Invoke("DisableGridLayoutGroup", 0.2f);
    }
    void DisableGridLayoutGroup()
    {
        canvasRef.GetComponent<GridLayoutGroup>().enabled = false;
    }
    
    public void OnDestroy()
    {
        cardCatalog_GUID_Reference.ReleaseAsset();
    }
}
