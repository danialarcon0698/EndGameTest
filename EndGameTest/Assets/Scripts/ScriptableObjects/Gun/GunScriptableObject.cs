using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Gun", fileName = "Gun")]
public class GunScriptableObject : ScriptableObject
{
    public float shootForce = 3f;
    public float shootRate = 0.25f;
}
