using UnityEngine;

public class Player : Actor, IMovable, IRotable
{
    private PlayerScriptableObject playerData = null;

    protected override void OnAwake()
    {
        playerData = actor as PlayerScriptableObject;
        playerData.SetPlayer(this, this);
    }

    public void Move(Vector2 _direction)
    {
        m_Rigidbody.MovePosition(transform.position + new Vector3(_direction.x, 0f, _direction.y) * actor.velocity * Time.fixedDeltaTime);
    }

    public void Rotate(Vector2 _direction)
    {
        Debug.Log("Rotate");
    }
}
