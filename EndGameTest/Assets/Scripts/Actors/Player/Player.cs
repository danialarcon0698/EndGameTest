using UnityEngine;

public class Player : Actor, IMovable, IRotable
{
    private PlayerScriptableObject m_Data = null;

    private bool isAiming = false;

    protected override void Awake()
    {
        base.Awake();
        m_Data = actor as PlayerScriptableObject;
    }

    public void Move(Vector2 _direction)
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + new Vector3(_direction.x, 0f, _direction.y) * actor.speed * Time.fixedDeltaTime * _direction.magnitude);
        
        m_ActorAnimation.SetBlendTree(_direction.magnitude);
        
        if (!isAiming) Rotate(_direction);
    }

    public void Rotate(Vector2 _direction)
    {
        isAiming = (_direction == Vector2.zero) ? isAiming = false : isAiming = true;

        if (_direction == Vector2.zero)
        {
            return;
        } 

        float angle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
        smooth = Mathf.SmoothDampAngle(smooth, angle, ref currentVelocity, actor.turnSmooth);
        m_Rigidbody.MoveRotation(Quaternion.Euler(0, smooth, 0));
    }
}
