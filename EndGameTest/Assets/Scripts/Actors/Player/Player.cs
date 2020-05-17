using UnityEngine;

public class Player : Actor, IMovable, IRotable
{
    private PlayerScriptableObject m_Data = null;

    private Vector2 moveVector = Vector2.zero;
    private Vector2 aimVector = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        m_Data = actor as PlayerScriptableObject;
    }

    /// <summary>
    /// Move in a direction multiplied by a speed
    /// </summary>
    /// <param name="_direction"></param>
    public void Move(Vector2 _direction)
    {
        moveVector = _direction;

        m_Rigidbody.MovePosition(m_Rigidbody.position + new Vector3(moveVector.x, 0f, moveVector.y) * m_Data.speed * Time.fixedDeltaTime * moveVector.magnitude);
        
        m_ActorAnimation.SetBlendTree(moveVector.magnitude);

        if (!IsAiming()) 
        {
            Rotate();
        }
    }

    /// <summary>
    /// Rotate in the same direction as move vector direction
    /// </summary>
    private void Rotate() 
    {
        if (moveVector == Vector2.zero) return;

        float angle = Mathf.Atan2(moveVector.x, moveVector.y) * Mathf.Rad2Deg;
        smooth = Mathf.SmoothDampAngle(smooth, angle, ref currentVelocity, m_Data.turnSmooth);
        m_Rigidbody.MoveRotation(Quaternion.Euler(0, smooth, 0));
    }

    /// <summary>
    /// Rotate in a direction by a vector given (joystick)
    /// </summary>
    /// <param name="_direction"></param>
    public void Rotate(Vector2 _direction)
    {
        aimVector = _direction;

        if (aimVector == Vector2.zero)
        {
            m_ActorAnimation.SetShooting(false);
            return;
        }

        m_ActorAnimation.SetShooting(true);

        float angle = Mathf.Atan2(aimVector.x, aimVector.y) * Mathf.Rad2Deg;
        smooth = Mathf.SmoothDampAngle(smooth, angle, ref currentVelocity, m_Data.turnSmooth);
        m_Rigidbody.MoveRotation(Quaternion.Euler(0, smooth, 0));
    }

    /// <summary>
    /// Is character using aiming joystick?
    /// </summary>
    /// <returns></returns>
    private bool IsAiming() 
    {
        return aimVector != Vector2.zero;
    }
}
