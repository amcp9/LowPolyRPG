using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/// <summary>
/// 史莱姆怪物类,控制怪物的基础生命值与AI判定
/// </summary>
public class Slime : MonoBehaviour,IEnemy
{

    public LayerMask aggroLayerMask;
    public float currentHealth;
    public float maxHealth = 100;
    private NavMeshAgent navMeshAgent;
    private Collider[] withinAggroColliders;
    private CharacterStats characterStats;
    private Player player;

    private GameObject rwdEffect;

	private void Start()
    {
        rwdEffect = Resources.Load<GameObject>("Effect/RewardEffect");  //死亡粒子特效
        navMeshAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(6, 10, 2);                  //怪物基础属性
        currentHealth = maxHealth;
    }

	private void FixedUpdate()
	{
        //球形抓取物体
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10,aggroLayerMask);
        if(withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }else CancelInvoke("PerformAttack");
	}
    /// <summary>
    /// 执行攻击
    /// </summary>
	public void PerformAttack()
    {
        player.TakeDamage(5);
    }
    /// <summary>
    /// 执行受伤效果
    /// </summary>
    /// <param name="amount">伤害点数</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }
    /// <summary>
    /// 追逐玩家
    /// </summary>
    void ChasePlayer(Player player)
    {
        navMeshAgent.SetDestination(player.transform.position);
        this.player = player;
        //判断是否进入攻击状态
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
    /// <summary>
    /// 怪物死亡,初始化死亡效果，重新设定NavMesh的目标
    /// </summary>
	void Die()
    {
        Instantiate(rwdEffect, transform.position, Quaternion.identity);
        GetComponent<NavMeshAgent>().destination = transform.position;
        gameObject.transform.position = new Vector3(100,100,0);
    }

}
