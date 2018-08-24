using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly_flying : MonoBehaviour
{
    private float RandomX, RandomY, RandomZ;
    private float time = 1f;

    private void Start()
    {
        InvokeRepeating("GiveRandomPos", 1f, time);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(RandomX,RandomY,RandomZ), Time.deltaTime);
    }

    void GiveRandomPos()
    {
        time = Random.Range(2, 6);
        RandomX = transform.position.x + Random.Range(-10, 10);
        if(transform.position.y < 0)
        {
            RandomY = transform.position.y + Random.Range(2f,4f);
        }
        RandomY = transform.position.y + Random.Range(-1f, 3);
        RandomZ = transform.position.z + Random.Range(-5, 5);
    }
}