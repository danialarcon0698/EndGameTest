using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic class to create pools
/// </summary>
/// <typeparam name="T1">Instance to convert to singleton</typeparam>
/// <typeparam name="T2">Pool item type</typeparam>
public abstract class Pool<T1, T2> : MonoBehaviour where T1 : Pool<T1, T2> where T2 : class 
{
    [SerializeField] protected PoolScriptableObject poolScriptableObject = null;

    protected List<T2> poolItems = new List<T2>();

    public static T1 instance = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T1;
        }
        else 
        {
            Debug.LogError($"Another instance of {GetType()} already exists. Destroying.");
            Destroy(this as T1);
        }

        InitializePool();
    }

    /// <summary>
    /// Initialize pool with T2 type
    /// </summary>
    private void InitializePool()
    {
        poolItems.Clear();

        for (int i = 0; i < poolScriptableObject.numberToInstantiate; i++)
        {
            GameObject clonedItem = Instantiate(poolScriptableObject.prefab, Vector3.zero, Quaternion.identity);
            clonedItem.SetActive(false);
            poolItems.Add(clonedItem.GetComponent<T2>());
        }
    }

    /// <summary>
    /// Get Pool Item
    /// </summary>
    /// <returns></returns>
    public abstract T2 GetPoolItem(); 
}
