using UnityEngine;
using UnityEngine.AI;

public class Enemy : Actor
{
    private Player currentTarget = null;

    private NavMeshAgent m_Agent = null;

    private EnemyScriptableObject m_Data = null;

    private float distanceToShoot = 0f;

    private bool isShooting = false;

    private IShootable shootable = null;

    protected override void Awake()
    {
        base.Awake();

        m_Data = actor as EnemyScriptableObject; //Cast information
        m_Agent = GetComponent<NavMeshAgent>();
        shootable = GetComponent<IShootable>();

        //We are taking the value as a "magnitude" but we are comparing it as a sqrMagnitude
        distanceToShoot = Mathf.Pow(m_Data.distanceToShoot, 2f);
        
        InitializeAgent();
    }

    /// <summary>
    /// Initialize agent component, all the values are taken from scriptable object
    /// </summary>
    private void InitializeAgent()
    {
        m_Agent.speed = m_Data.speed;
        m_Agent.angularSpeed = m_Data.angularSpeed;
        m_Agent.acceleration = m_Data.acceleration;
        m_Agent.stoppingDistance = m_Data.stoppingDistance;
    }

    private void Update()
    {
        if (Time.frameCount % m_Data.framesToUpdateAI == 0)
        {
            //Update AI behavior
            UpdateBehavior();
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            shootable.Shoot(1);
            transform.LookAt(currentTarget.transform); 
        }

        //Update animation
        m_ActorAnimation.SetBlendTree(m_Agent.velocity.normalized.magnitude);
    }

    /// <summary>
    /// Take decisions based on closest enemy
    /// </summary>
    private void UpdateBehavior()
    {
        currentTarget = GetClosestEnemy();

        if (currentTarget != null)
        {
            m_Agent.SetDestination(currentTarget.transform.position);

            float distance = (currentTarget.transform.position - transform.position).sqrMagnitude;

            //The distance is appropriate to start shooting
            if (distance <= distanceToShoot)
            {
                isShooting = true;
                m_ActorAnimation.SetShooting(true);
            }
            else
            {
                isShooting = false;
                m_ActorAnimation.SetShooting(false);
            }
        }
        else 
        {
            //If can't find enemies
            isShooting = false;
            m_ActorAnimation.SetShooting(false);
        }
    }

    /// <summary>
    /// Do a sphere cast and compare hits to return the closest enemy, in this case a Player
    /// </summary>
    /// <returns></returns>
    private Player GetClosestEnemy() 
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, m_Data.radius, transform.position, m_Data.radius, m_Data.enemyLayer);

        if (hits.Length == 0) 
        {
            Debug.LogWarning("No enemies found");
            return null;
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
