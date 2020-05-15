using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData")]
public class PlayerScriptableObject : ActorScriptableObject
{
    public IMovable Movable { get; private set; }
    public IRotable Rotable { get; private set; }

    public void SetPlayer(IMovable _movable, IRotable _rotable) 
    {
        Movable = _movable;
        Rotable = _rotable;
    }
}
