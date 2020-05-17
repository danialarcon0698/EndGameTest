using UnityEngine;

public class Gun : MonoBehaviour, IShootable
{
    [SerializeField] private GunScriptableObject m_Data = null;
    
    [SerializeField] protected Transform m_ReferencePoint = null;

    [SerializeField] private GunView m_GunView = null;

    private Bullet bulletToShoot = null;

    private float elapsedTime = 0f;

    /// <summary>
    /// Shoot a bullet depending on shoot rate
    /// </summary>
    /// <param name="_sqrMagnitude">If it is greater than 0, will start counting time</param>
    public void Shoot(float _sqrMagnitude)
    {
        if (_sqrMagnitude > 0)
        {
            elapsedTime += Time.fixedDeltaTime;
        }
        else 
        {
            elapsedTime = 0f;
        }

        if (elapsedTime >= m_Data.shootRate)
        {
            //Stuff with "View"
            m_GunView.ActivateMuzzleParticles();
            m_GunView.PlayShotSound();

            //Get a bullet and set it to be shot
            bulletToShoot = BulletPool.instance.GetPoolItem();
            bulletToShoot.gameObject.SetActive(true);
            
            bulletToShoot.transform.position = m_ReferencePoint.position;
            bulletToShoot.transform.rotation = m_ReferencePoint.rotation;
            
            bulletToShoot.Rigidbody.velocity = Vector3.zero;
            bulletToShoot.Rigidbody.AddForce(m_ReferencePoint.forward * m_Data.shootForce, ForceMode.Impulse);
            
            elapsedTime = 0f;
        }
    }
}
