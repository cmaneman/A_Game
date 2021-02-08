using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentAI : MonoBehaviour
{
    //enum EnemyStates {IDLE, ATTACK, RESET}//Spin or Search
    //These enums will be used to access or activate different functions/methods...
    //int Stateholder;//The door keeper to allow or prevent particular methods to do what they were created to do...
    //These are no uses for these that I can think of at the moment...

    public GameObject enemyTurrent;
    public GameObject enemyTurrentProjectile;
    public GameObject player;

    //public Collider playerColl;

    public Transform playerLocation;
    //public Vector3 enemySightDistance;

    public AudioSource projectileShotSound;

    public bool playerInSight;
    //public bool obstacleCheck;
    public bool alreadyAttacked; //If the turrent attacks, there will be a break inbetween those attacks...

    public float EnemySightRange;
    //public float attackCooldown;
    public float idleSpinSpeed_Yaxis;

    public LayerMask theGround, thePlayer; /// <summary>
    /// LayerMask Obstacle was removed because of the lack of understanding of detecting a wall/obstacle to prevent the turret from shooting.
    /// </summary>

    void Awake()
    {
        enemyTurrent = GameObject.FindGameObjectWithTag("turrent");
        player = GameObject.FindGameObjectWithTag("player"); 
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }
    void FixedUpdate()
    {
        playerLocation = player.transform;
        playerInSight = Physics.CheckSphere(transform.position, EnemySightRange, thePlayer);

        if (playerInSight == true)
        {
            FireOnSight();
        }

        else if (playerInSight == false)
        {
            Searching();
        }
    }

    private void FireOnSight()
    {
        //If there is a wall structure in the way, the turrent will continue to search for the player like before
        
         //Debug.Log("Target Aquired...");
        transform.LookAt(playerLocation); ///I want to rotate it to look at the player over time in the future...

        StartCoroutine(LoadAmmo());

        if (alreadyAttacked == false)
         {
              alreadyAttacked = true;
              GameObject ball = Instantiate(enemyTurrentProjectile, transform.position, Quaternion.identity);
              ball.GetComponent<Rigidbody>().AddForce(transform.forward * 8f, ForceMode.Impulse);
              projectileShotSound.Play();
              StartCoroutine(ResetAttack(ball));

         }
        
    }
    private void Searching() //Rotate around the x axis until player enters range...
    {
        
        ///If the player is out of range, the turrent should return to its IDLE state by standing up straight and not bent over...
        if (alreadyAttacked == true)
        {
            enemyTurrent.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            alreadyAttacked = false;

            if (gameObject.CompareTag("turrent"))
            {
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
        }
        transform.Rotate(new Vector3(0f, idleSpinSpeed_Yaxis, 0f * Time.deltaTime));
        //Debug.Log("Searching....");
    }
    void RA()
    {
        alreadyAttacked = false;
        //Debug.Log("Shot");
    }

    private IEnumerator ResetAttack(GameObject ball)
    {
        Invoke(nameof(RA), 1.5f);
        Destroy(ball, 2);
        yield return new WaitForSeconds(2);
    }

    private IEnumerator LoadAmmo()
    {
        yield return new WaitForSeconds(2);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, EnemySightRange);
    }
    
}