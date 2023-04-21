using System;
using System.Collections;
using System.Collections.Generic;
using GameManagers;
using HeroScripts;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private NavMeshAgent navAgent;
    private EnemyState enemyState;

    private float patrolRadius = 30f;
    private float patrolTime = 10f;
    [SerializeField] private float rotationSpeed = 1f;
    private float timerCount;

    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float runSpeed = 5f;
    
    private Transform playerTarget;
    private GameObject player;
    private Rigidbody myBody;
    [SerializeField] private float chaseDistance = 7f;
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float chasePlayerAfterAttackDistance = 1f;
    [SerializeField] private float waitBeforeAttack = 3f;
    [SerializeField] private float attackTimer;
    [SerializeField] private bool enemyDied;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerCount = patrolTime;
        enemyState = EnemyState.PATROL;
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        playerTarget = player.transform;
        attackTimer = waitBeforeAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDied)
            return;

       
        
        if (enemyState == EnemyState.PATROL)
        {
            Patrol();
        }

        if (enemyState != EnemyState.CHASE && enemyState != EnemyState.ATTACK)
        {
            if (Vector3.Distance(transform.position, playerTarget.position) <= chaseDistance)
            {
                enemyState = EnemyState.CHASE;
                enemyAnim.StopAnimation();
            }
        }
        
        if (enemyState == EnemyState.CHASE)
            ChasePlayer();
        
        if (enemyState == EnemyState.ATTACK)
            AttackPlayer();
    }

    void Patrol()
    {
        timerCount += Time.deltaTime;
        navAgent.speed = moveSpeed;

        if (timerCount > patrolTime)
        {
            SetRandomDestination();
            timerCount = 0f;
        }

        if (navAgent.remainingDistance <= 0.5f)
            navAgent.velocity = Vector3.zero;


        enemyAnim.Walk(navAgent.velocity.sqrMagnitude != 0);
    }

    void SetRandomDestination()
    {
        Vector3 newDestination = RandomNavSphere(transform.position, patrolRadius, -1);
        navAgent.SetDestination(newDestination);
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask)
    {
        Vector3 ranDir = Random.insideUnitSphere * distance;
        ranDir += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(ranDir, out navHit, distance, layerMask);
        
        return navHit.position;
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        Vector3 dir = playerTarget.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        navAgent.speed = runSpeed;

        enemyAnim.Run(navAgent.velocity.sqrMagnitude != 0);

        if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        } else if (Vector3.Distance(transform.position, playerTarget.position) > chaseDistance)
        {
            timerCount = patrolTime;
            enemyState = EnemyState.PATROL;
            enemyAnim.Run(false);
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.angularSpeed = 0f;
        navAgent.isStopped = true;
        myBody.angularVelocity = Vector3.zero;
        
        enemyAnim.Run(false);
        enemyAnim.Walk(false);

        attackTimer += Time.deltaTime;

        if (attackTimer > waitBeforeAttack)
        {
            enemyAnim.NormalAttack();
            attackTimer = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) >
            attackDistance + chasePlayerAfterAttackDistance)
        {
            navAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }
    }

    void DeactivateScript()
    {
        this.GetComponent<Collider>().enabled = false;
        GamePlayController.instance.EnemyDied();
        enemyDied = true;
        StartCoroutine(DeactivateEnemy());
    }

    IEnumerator DeactivateEnemy()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

}
