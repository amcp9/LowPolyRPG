using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using EZObjectPools;

public class Slime : MonoBehaviour,IEnemy
{

    public LayerMask aggroLayerMask;
    public float currentHealth;
    public float maxHealth = 100;
    public EZObjectPool eZ;
    private NavMeshAgent navMeshAgent;
    private Collider[] withinAggroColliders;
    private CharacterStats characterStats;
    private Player player;

    private GameObject rwdEffect;

	private void Start()
    {
        rwdEffect = Resources.Load<GameObject>("Effect/RewardEffect");
        navMeshAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(6, 10, 2);
        currentHealth = maxHealth;
        eZ = GameObject.FindWithTag("Pool").GetComponent<EZObjectPool>();
    }

	private void FixedUpdate()
	{
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10,aggroLayerMask);
        if(withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }else CancelInvoke("PerformAttack");
	}
	public void PerformAttack()
    {
        player.TakeDamage(5);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }
    void ChasePlayer(Player player)
    {
        navMeshAgent.SetDestination(player.transform.position);
        this.player = player;
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance &&  (Vector3.Distance(transform.position,player.transform.position)<navMeshAgent.stoppingDistance))
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, .5f);
            }
        }
        else
        {
            CancelInvoke("PerformAttack");
        }
    }
	void Die()
    {
        Instantiate(rwdEffect, transform.position, Quaternion.identity);
        GetComponent<NavMeshAgent>().destination = transform.position;
        gameObject.transform.position = new Vector3(100,100,0);
    }

}
