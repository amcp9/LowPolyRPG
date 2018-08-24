using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStaff : MonoBehaviour,IWeapon {

    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }

    GameObject fireBall;

    Vector3 pos;

    private void Start()
    {
        fireBall = Resources.Load<GameObject>("Weapons/FireStaff/Fireball");
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }


    public void PerformSpecialAttack()
    {
    }

    private void FireBallSpawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        pos.x = hit.point.x;
        pos.y = hit.point.y + 20f;
        pos.z = hit.point.z;
        GameObject fireballInstance = (GameObject)Instantiate(fireBall, pos,transform.rotation);
    }
}
