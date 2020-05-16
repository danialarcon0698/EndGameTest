using UnityEngine;

public class ActorAnimation : MonoBehaviour
{
    private Animator m_Animator = null;

    private readonly int speedHash = Animator.StringToHash("Speed"); 
    private readonly int shootingHash = Animator.StringToHash("Shooting"); 

    private void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void SetBlendTree(float _speed) 
    {
        m_Animator.SetFloat(speedHash, _speed);
    }

    public void SetShooting(bool _value) 
    {
        m_Animator.SetBool(shootingHash, _value);
    }
}
