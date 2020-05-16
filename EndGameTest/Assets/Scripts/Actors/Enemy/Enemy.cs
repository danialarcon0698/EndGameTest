using UnityEngine;
using UnityEngine.AI;

public class Enemy : Actor
{
    private Player currentTarget = null;

    private NavMeshAgent m_Agent = null;

    private EnemyScriptableObject m_Data = null;

    private void Awake()
    {
        m_Data = actor as EnemyScriptableObject;
        m_Agent = GetComponent<NavMeshAgent>();

        InitializeAgent();
    }

    private void InitializeAgent()
    {
        m_Agent.speed = actor.speed;
    }

    private void Update()
    {
        if (Time.frameCount % m_Data.framesToUpdateAI == 0)
        {
            UpdateBehavior();
        }
    }

    private void UpdateBehavior()
    {
        currentTarget = GetClosestEnemy();

        if (currentTarget != null)
        {
            m_Agent.SetDestination(currentTarget.transform.position);
        }
    }

    private Player GetClosestEnemy() 
    {
        Player result = null;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, m_Data.radius, transform.position, m_Data.radius, m_Data.enemyLayer);

        if (hits.Length == 0) 
        {
            Debug.LogWarning("No enemies found");
            return result;
        }

        RaycastHit closestHit = default;

        float currentDistance = Mathf.Infinity;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].distance <= currentDistance)
            {
                closestHit = hits[i];
                currentDistance = hits[i].distance;
            }
        }

        return closestHit.collider.GetComponent<Player>();

    }
}
