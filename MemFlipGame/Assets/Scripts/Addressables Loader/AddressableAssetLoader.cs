using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAssetLoader : IAssetLoader
{
    
    public async Task<T> Load<T>(AssetReferenceT<T> assetReference) where T : Object
    {
        if (assetReference == null)
        {
            return null; 
            Debug.LogError("Asset Reference is null");
        }

        var loadTask = assetReference.LoadAssetAsync<T>();
        await loadTask.Task;

        if (loadTask.Status == AsyncOperationStatus.Failed)
        {
            return null;
            Debug.LogError("Asset Load Failed");
        }
        
        return loadTask.Result;
    }

    public void Release<T>(AssetReferenceT<T> assetReference) where T : Object
    {
        assetReference?.ReleaseAsset();
    }
    
    
}
