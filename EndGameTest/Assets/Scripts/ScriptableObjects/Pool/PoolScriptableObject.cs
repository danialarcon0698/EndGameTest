using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Pools/Game Object", fileName = "GameObjectsPool")]
public class PoolScriptableObject : ScriptableObject
{
    public GameObject prefab = default;
    
    public int numberToInstantiate = 10;
}
