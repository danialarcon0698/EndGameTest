using UnityEngine;

[RequireComponent(typeof(ActorAnimation))]
public abstract class Actor : MonoBehaviour, IDamagable
{
    [SerializeField] protected ActorScriptableObject actor = null;//Data from scriptable object

    protected Rigidbody m_Rigidbody = null;

    protected ActorAnimation m_ActorAnimation = null;

    protected float currentVelocity = 0;
    protected float smooth = 0;

    private int health = 0;

    protected virtual void Awake()
    {
        m_ActorAnimation = GetComponent<ActorAnimation>();
        m_Rigidbody = GetComponent<Rigidbody>();
        
        health = actor.health;
    }

    /// <summary>
    /// Take damage and check if actor has died.
    /// </summary>
    /// <param name="_damage"></param>
    public void DoDamage(int _damage) 
    {
        health -= _damage;
        health = (health <= 0) ? health = 0 : health;

        actor.OnTakeDamage?.Invoke(health);
        
        if (health <= 0)
        {
            AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.angryCharacter, 1f, false);
            gameObject.SetActive(false);
        }
    }
}
