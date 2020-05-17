using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Actors/Enemy Data", fileName = "EnemyData")]
public class EnemyScriptableObject : ActorScriptableObject
{
    public float angularSpeed = 150f;
    public float acceleration = 8f;
    public float stoppingDistance = 3f;

    [Header("AI paramenters")]

    [Tooltip("AI distance to start shooting (Magnitude)")]
    public float distanceToShoot = 4f;
    
    [Tooltip("Spherecast will be checked in this layer")]
    public LayerMask enemyLayer = 0;

    [Tooltip("Each x frames AI will be updated")]
    public float framesToUpdateAI = 60;
    
    [Tooltip("Radius of spherecast")]
    public float radius = 10f;
}
