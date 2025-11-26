using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public interface IAssetLoader
{
    
    // Load the asset reference of type safe card 
    // using task async
    Task<T> Load<T>(AssetReferenceT<T> assetReference) where T :UnityEngine.Object;
     
    // release the addressable
    void Release<T>(AssetReferenceT<T> assetReference) where T :UnityEngine.Object;
}
