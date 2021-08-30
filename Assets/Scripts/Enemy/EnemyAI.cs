using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseRange = 30f;
    [SerializeField] float turnSpeed = .5f;
 
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;
    bool spawnActive;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) 
        {
            navMeshAgent.enabled = false;
            enabled = false;
            return; 
        } 
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked && !spawnActive)
        {
            spawnActive = true;
            BroadcastMessage("SpawnMinions");
        }

        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    private void AttackTarget()
    {
        if (!GetComponent<Animator>().GetBool("attack"))
        {
            GetComponent<Animator>().SetBool("attack", true);
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken() // String Referenced in EnemyHealth
    {
        isProvoked = true;
    }

    public void EnemyDeath()
    {
        dead = true;
    }

}
