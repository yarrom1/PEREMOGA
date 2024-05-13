using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum State { Patrol, Chase, Attack }

    public State currentState = State.Patrol;
    public Transform[] patrolPoints;
    public Transform playerTarget;
    public float patrolSpeed = 1f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 10f;
 
    public bool isShooting = false; 

    private int currentPatrolPoint = 0;
    private NavMeshAgent agent;
    private float nextAttackTime;

    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f; 
    public float bulletForce = 10f;
    public Transform firePoint;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        agent.destination = patrolPoints[currentPatrolPoint].position;

        
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                ChasePlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
        }

        if (playerTarget != null && Vector3.Distance(transform.position, playerTarget.position) <= attackRange)
        {
            ChangeState(State.Attack);
        }
        else if (patrolPoints.Length > 0 && agent.remainingDistance < 0.5f)
        {
            NextPatrolPoint();
        }
    }

    void Patrol()
    {
        agent.destination = patrolPoints[currentPatrolPoint].position;
    }

    void ChasePlayer()
    {
        agent.destination = playerTarget.position;
        agent.speed = patrolSpeed * 1.5f; 
    }

    void AttackPlayer()
    {
        if (Time.time >= nextAttackTime)
        {
          
            transform.LookAt(playerTarget); // ѕоворачиваем врага в направлении игрока
            Shoot();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

      
        bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

    }
    

   

    void StopShooting()
    {
        isShooting = false;
        CancelInvoke("ShootOnce"); 
    }

    void NextPatrolPoint()
    {
        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
        agent.destination = patrolPoints[currentPatrolPoint].position;
        StopShooting(); 
    }

    void ChangeState(State newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case State.Patrol:
                agent.speed = patrolSpeed;
                StopShooting(); 
                break;
            case State.Chase:
                agent.speed = patrolSpeed * 1.5f; 
                StopShooting(); 
                break;
            case State.Attack:
                agent.speed = 0f;
                break;
        }
    }
}