using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon , IProjectileWeapon
{
    private Animator animator;


    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }
    public Transform ProjectlitSpawn { get; set; }

    GameObject fireBall;


    private void Start()
    {
        fireBall = Resources.Load<GameObject>("Weapons/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }


    public void CastProjectile()
    {

        GameObject fireballInstance = (GameObject)Instantiate(fireBall, ProjectlitSpawn.position, ProjectlitSpawn.rotation);

        fireballInstance.GetComponent<FireBall>().Direction = ProjectlitSpawn.forward;
    }

    public void PerformSpecialAttack()
    {
        
    }
}
