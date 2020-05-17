using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletScriptableObject bulletScriptable = null;

    public Rigidbody Rigidbody { get; private set; } = null;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.DoDamage(bulletScriptable.damage);
        }

        gameObject.SetActive(false);
    }
}