using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ActorAnimation))]
public abstract class Actor : MonoBehaviour, IDamagable
{
    [SerializeField] protected ActorScriptableObject actor = null;

    protected Rigidbody m_Rigidbody = null;

    protected ActorAnimation m_ActorAnimation = null;

    protected float currentVelocity = 0;
    protected float smooth = 0;

    private int health = 0;

    protected virtual void Awake()
    {
        m_ActorAnimation = GetComponent<ActorAnimation>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        health = actor.health;
    }

    public void DoDamage(int _damage) 
    {
        health -= _damage;
        health = (health <= 0) ? health = 0 : health;

        Debug.Log(health);
        actor.OnTakeDamage?.Invoke(health);
    }
}
