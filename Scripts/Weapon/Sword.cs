using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    public int CurrentDamage { get ; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
    public void PerformSpecialAttack()
    {
        
    }
}
