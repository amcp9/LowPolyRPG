using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 玩家类，控制玩家的属性、金币、生命值与魔法值
/// </summary>
public class Player : MonoBehaviour {
    
    public CharacterStats characterStats;           //玩家属性

    public int Coins = 0;                           //玩家金币
    public float currentHealth;         
    public float maxHealth;

    public float currentMagic;
    public float maxMagic;

    private bool isReCover = false;                 //魔法值恢复状态

	private void Awake()
	{
        this.currentHealth = this.maxHealth;
        this.currentMagic = this.maxMagic;
        characterStats = new CharacterStats(10, 10, 10);
	}

	private void Update()
	{
        if(currentMagic < maxMagic && !isReCover)   //是否需要恢复魔法值
        {
            InvokeRepeating("ReCoverMagic", 1f,1f);
        }
        if(currentMagic >= maxMagic)                //停止恢复魔法值
        {
            CancelInvoke("ReCoverMagic");
            isReCover = false;
        }
	}

    /// <summary>
    /// 恢复魔法值，每执行一次，魔法值+1
    /// </summary>
    private void ReCoverMagic()
    {
        isReCover = true;
        currentMagic = currentMagic + 1;
    }
    /// <summary>
    /// 受伤函数
    /// </summary>
    /// <param name="amount">Amount.</param>
	public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }
    /// <summary>
    /// 魔法值消耗,攻击时执行
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void TakeMagic(int amount)
    {
        if (currentMagic > amount)
        {
            currentMagic -= amount;
        }else
        {
            Debug.Log("Not Enough Magic Point!");
        }

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Die()
    {
        Debug.Log("Player dead. Reset health");
        this.currentHealth = maxHealth;
    }
}
