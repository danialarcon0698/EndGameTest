using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Actor Data", fileName = "ActorData")]
public class ActorScriptableObject : ScriptableObject
{
    public string playerName = "player_name";
    public int health = 3;

    #region Movement
    public float velocity = 1f;
    public float turnSmooth = 0.15f;
    #endregion

    public Action<int> OnTakeDamage = null;
}
