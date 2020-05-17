using UnityEngine;

public class BulletPool : Pool<BulletPool, Bullet> 
{
    protected Bullet bulletToReturn = null;

    /// <summary>
    /// Get a bullet from the pool
    /// </summary>
    /// <returns></returns>
    public override Bullet GetPoolItem()
    {
        for (int i = 0; i < poolItems.Count; i++)
        {
            bulletToReturn = poolItems[i] as Bullet;

            if (!bulletToReturn.gameObject.activeInHierarchy)
            {
                return bulletToReturn;
            }
        }

        GameObject clonedItem = Instantiate(poolScriptableObject.prefab, Vector3.zero, Quaternion.identity);
        clonedItem.SetActive(false);
        bulletToReturn = clonedItem.GetComponent<Bullet>();
        poolItems.Add(bulletToReturn);

        return bulletToReturn;
    }

}
