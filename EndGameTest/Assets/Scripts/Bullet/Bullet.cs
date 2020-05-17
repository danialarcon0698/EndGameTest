using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletScriptableObject bulletScriptable = null;

    public Rigidbody Rigidbody { get; private set; } = null;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Register bullet collisions
    /// </summary>
    /// <param name="_collision"></param>
    private void OnCollisionEnter(Collision _collision)
    {
        IDamagable damagable = _collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            //If collision has IDamagable
            damagable.DoDamage(bulletScriptable.damage);
        }

        gameObject.SetActive(false);
    }
}