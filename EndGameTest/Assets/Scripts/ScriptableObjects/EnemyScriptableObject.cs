using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Actors/Enemy Data", fileName = "EnemyData")]
public class EnemyScriptableObject : ActorScriptableObject
{
    [Header("AI paramenters")]
    
    [Tooltip("Spherecast will be checked in this layer")]
    public LayerMask enemyLayer = 0;

    [Tooltip("Each x frames AI will be updated")]
    public float framesToUpdateAI = 60;
    
    [Tooltip("Radius of spherecast")]
    public float radius = 10f;
    public float maxDistance = 20f;
}
