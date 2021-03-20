using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurrentAI : MonoBehaviour
{
    public GameObject enemyTurrent;
    public GameObject enemyTurrentProjectile;
    public GameObject player;

    [SerializeField] private Collider turrentCollider;

    public Transform playerLocation;

    bool inSight;
    bool attackDelay;
    public bool obstacleHit;

    public float sightRange;
    public float maxDistance;
    public float shotCooldown;
    public float idleSpin_Y;

    RaycastHit hit;

    public LayerMask theGround, thePlayer, Obstacle;


    void Awake()
    {
        enemyTurrent = GameObject.FindGameObjectWithTag("turrent");
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Start()
    {
        turrentCollider = GetComponent<Collider>();
    }

    void Update()
    {
        ;
    }

    void FixedUpdate()
    {
        playerLocation = player.transform;
        inSight = Physics.CheckSphere(transform.position, sightRange, thePlayer);
        obstacleHit = Physics.BoxCast(turrentCollider.bounds.center, transform.localScale, transform.forward, out hit, transform.rotation, maxDistance, Obstacle);

        if (obstacleHit == true)
        {

        }
    }
}
