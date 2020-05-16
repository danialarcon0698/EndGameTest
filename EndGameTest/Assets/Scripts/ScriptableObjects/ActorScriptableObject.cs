using System;
using UnityEngine;

public abstract class ActorScriptableObject : ScriptableObject
{
    [Header("Id")]
    public string playerName = "player_name";
    
    [Header("Health")]
    public int health = 3;

    [Header("Movement Paramenters")]
    public float speed = 1f;

    public Action<int> OnTakeDamage = null;
}
