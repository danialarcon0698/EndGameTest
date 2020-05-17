using UnityEngine;

public class Gun : MonoBehaviour, IShootable
{
    [SerializeField] private GunScriptableObject m_Data = null;
    
    [SerializeField] protected Transform m_ReferencePoint = null;

    [SerializeField] private GunView m_GunView = null;

    private Bullet bulletToShoot = null;

    private float elapsedTime = 0f;

    public void Shoot(Vector2 _aim)
    {
        if (_aim.sqrMagnitude > 0)
        {
            elapsedTime += Time.fixedDeltaTime;
        }
        else 
        {
            elapsedTime = 0f;
        }

        if (elapsedTime >= m_Data.shootRate)
        {
            //Things with "View"
            m_GunView.ActivateMuzzleParticles();
            m_GunView.PlayShotSound();

            bulletToShoot = BulletPool.instance.GetPoolItem();
            bulletToShoot.gameObject.SetActive(true);
            bulletToShoot.transform.position = m_ReferencePoint.position;
            bulletToShoot.Rigidbody.velocity = Vector3.zero;
            
            float angle = Mathf.Atan2(_aim.x, _aim.y) * Mathf.Rad2Deg;
            bulletToShoot.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            bulletToShoot.Rigidbody.AddForce(m_ReferencePoint.forward * m_Data.shootForce, ForceMode.Impulse);
            
            elapsedTime = 0f;
        }
    }
}
