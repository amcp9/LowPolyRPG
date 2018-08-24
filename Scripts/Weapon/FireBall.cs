using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour 
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }
    Vector3 spawnPos;
    private void Start()
    {
        Range = 50f;
        Damage = 10;
        spawnPos = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 200f);

        gameObject.GetComponent<ParticleSystem>().Pause();
    }

    private void Update()
    {
        if(Vector3.Distance(spawnPos,transform.position) >= Range)
        {
            Extinguish();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        gameObject.GetComponent<ParticleSystem>().Play();
        //Extinguish();

    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
