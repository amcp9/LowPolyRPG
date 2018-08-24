using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour {
    Collider[] colliders;
    GameObject father;
	private void Start()
	{
        father = GameObject.Find("fire_Arround_mod");
        Invoke("des", 4.8f);
	}
	void Update () {
        colliders =  Physics.OverlapSphere(transform.position, 10);
        if(colliders.Length >0)
        {
            foreach(Collider col in colliders)
            {
                if(col.transform.tag == "Enemy")
                {
                    transform.position = Vector3.Lerp(transform.position,col.transform.position,Time.deltaTime);
                    col.GetComponent<IEnemy>().TakeDamage(10);
                    Invoke("des", .7f);
                }
            }
        }
	}

    private void des()
	{
        gameObject.SetActive(false);
       // Destroy(gameObject);
	}
}
