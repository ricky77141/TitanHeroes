using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameManagers;
using HeroScripts;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum BossState
{
    GO_TO_PLAYER,
    MOVE_AWAY,
    SEARCH_PLAYER,
    ATTACK_PLAYER
}

public class BossController : MonoBehaviour
{
    private CharacterAnimation bossAnimation;
    private NavMeshAgent navAgent;
    private BossState bossState;
    private Transform playerTarget;
    
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float chasePlayerAfterAttackDis = 1f;
    [SerializeField] private float retreatDistanceRadius = 8f;
    
    private float waitBeforeAttackTime = 2f;
    private float attackTimer;
    private bool firstAttack;
    private Vector3 randomPos;

    private void Awake()
    {
        bossAnimation = GetComponent<CharacterAnimation>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
        bossState = BossState.SEARCH_PLAYER;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossState == BossState.SEARCH_PLAYER)
        {
            if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
            {
                bossState = BossState.GO_TO_PLAYER;
            }
            else
            {
                bossState = BossState.ATTACK_PLAYER;
            }
        }

        if (bossState == BossState.GO_TO_PLAYER)
            GoTowardPlayer();
        

        if (bossState == BossState.ATTACK_PLAYER)
            AttackPlayer();
        
        if (bossState == BossState.MOVE_AWAY)
            MoveAway();
        
    }

    void GoTowardPlayer()
    {
        navAgent.isStopped = false;
        navAgent.SetDestination(playerTarget.position);

        if (navAgent.velocity.sqrMagnitude == 0)
        {
            bossAnimation.Walk(false);
        }
        else
        {
            bossAnimation.Walk(true);
        }

        if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            
            bossAnimation.Walk(false);
            bossState = BossState.ATTACK_PLAYER;
            attackTimer = waitBeforeAttackTime / 2f;
        }

    }

    void AttackPlayer()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > waitBeforeAttackTime)
        {
            attackTimer = 0f;
            if (!firstAttack)
            {
                bossAnimation.NormalAttack();
                firstAttack = true;
            }
            else
            {
                if (Random.Range(0, 5) >= 1f)
                {
                    if (Random.Range(0, 3) > 1f)
                    {
                        bossAnimation.NormalAttack();
                    }
                    else
                    {
                        bossAnimation.SpecialAttack1();
                    }
                }
                else
                {
                    randomPos = transform.position - (transform.forward * retreatDistanceRadius);
                    bossState = BossState.MOVE_AWAY;
                    firstAttack = false;
                }
            }
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttackDis)
        {
            navAgent.isStopped = false;
            bossState = BossState.GO_TO_PLAYER;
        }
    }

    void MoveAway()
    {
        navAgent.SetDestination(randomPos);
        navAgent.isStopped = false;

        if (navAgent.velocity.sqrMagnitude == 0f)
        {
            bossAnimation.Walk(false);
        }
        else
        {
            bossAnimation.Walk(true);
        }

        if (navAgent.remainingDistance <= 0.2f)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            StartCoroutine(WaitThenSearchPlayer());
        }
    }

    IEnumerator WaitThenSearchPlayer()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        bossState = BossState.SEARCH_PLAYER;
    }

    void DeactivateScript()
    {
        EndGameManager.instance.GameOver(true);
        
        navAgent.isStopped = true;
        enabled = false;
    }
}
