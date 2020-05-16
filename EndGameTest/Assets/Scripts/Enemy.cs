using UnityEngine;

public class Enemy : Actor
{
    private Player currentTarget = null;

    private void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            CheckAI();
        }
    }

    private void CheckAI()
    {

    }

    private Player GetClosestEnemy() 
    {
        Player result = null;
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 10f, transform.position, out hit, 20, PlayerUtilities.PlayerLayer))
        {
            if (hit.collider.GetComponent<Player>())
            {
                Debug.Log("Hit player");
                result = hit.collider.GetComponent<Player>();
                return result;
            }
        }
        return result;
    }
}
