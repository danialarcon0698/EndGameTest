using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletScriptableObject bulletScriptable = null; 

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.DoDamage(bulletScriptable.damage);
        }
    }
}