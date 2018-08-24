using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    public CharacterStats characterStats;

    public int Coins = 0;
    public float currentHealth;
    public float maxHealth;

    public float currentMagic;
    public float maxMagic;

    private bool isReCover = false;
	private void Awake()
	{
        this.currentHealth = this.maxHealth;
        this.currentMagic = this.maxMagic;
        characterStats = new CharacterStats(10, 10, 10);
	}
	private void Update()
	{
        if(currentMagic < maxMagic && !isReCover)
        {
            InvokeRepeating("ReCoverMagic", 1f,1f);
        }
        if(currentMagic >= maxMagic)
        {
            CancelInvoke("ReCoverMagic");
            isReCover = false;
        }
	}

    private void ReCoverMagic()
    {
        isReCover = true;
        currentMagic = currentMagic + 1;
    }
	public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }
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
    private void Die()
    {
        Debug.Log("Player dead. Reset health");
        this.currentHealth = maxHealth;
    }
}
