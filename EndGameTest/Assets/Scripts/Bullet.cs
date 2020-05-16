using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletScriptable bulletScriptable = null; 

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.DoDamage(bulletScriptable.damage);
        }
    }
}