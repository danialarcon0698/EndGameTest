using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Actors/Player Data", fileName = "Player")]
public class PlayerScriptableObject : ActorScriptableObject
{
    public float turnSmooth = 0.05f;
}
