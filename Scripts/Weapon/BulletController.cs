using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
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
		GetComponent<Rigidbody>().AddForce(Direction * 400f);
	}

	private void Update()
	{
		if (Vector3.Distance(spawnPos, transform.position) >= Range)
		{
			Extinguish();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
		}
        Extinguish();

	}

	void Extinguish()
	{
		Destroy(gameObject);
	}
}
