//Code by Dave / GameDevelopment with small modifications...Purpose: used as a reference but will not actually be used...
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class EnemySeekAttack : MonoBehaviour
{
   public NavMeshAgent EnemyAgent;

    public GameObject player;
    public Transform playerTransform;
    public GameObject projectileBall;

    //public GameObject Enemy;

    public LayerMask theGround, thePlayer;

    public int damageCount = 0;

    //Patroling
    public Vector3 walkpoint;
    bool walkpointSet;
    public float walkpointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

   

    private void Awake()
    {
        playerTransform = GameObject.Find("TestPlayer").transform;
        EnemyAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Checking for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, thePlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, thePlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.transform.gameObject.GetComponent<GameObject>();
        if(player)
        {
            Damage();
        }
    }

    private void Patroling()
    {
        if (!walkpointSet)
        {
            SearchWalkPoint();
        }
        if (walkpointSet)
        {
            EnemyAgent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkpointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //Choose or Calculate random point within range
        float RandomZDestination = Random.Range(-walkpointRange, walkpointRange);
        float RandomXDestination = Random.Range(-walkpointRange, walkpointRange);

        walkpoint = new Vector3(transform.position.x + RandomXDestination, transform.position.y, transform.position.z + RandomZDestination);

        if (Physics.Raycast(walkpoint, -walkpoint, 2f, theGround)) /// check the int layermask: 2f
        {
            walkpointSet = true;
        }
    }

    private void ChasePlayer()
    {
        EnemyAgent.SetDestination(playerTransform.position);
    }
    private void AttackPlayer()
    {
        EnemyAgent.SetDestination(transform.position);

        transform.LookAt(playerTransform);

        if (!alreadyAttacked)
        {
            Rigidbody projectile = Instantiate(projectileBall, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            projectile.AddForce(transform.forward * 32f, ForceMode.Impulse);
            projectile.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Damage()
    {
        damageCount++;
        if( damageCount >= 3)
        {
            StartCoroutine(GameOverTest());
        }
    }

    IEnumerator GameOverTest()
    {
        Destroy(player);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }



}
