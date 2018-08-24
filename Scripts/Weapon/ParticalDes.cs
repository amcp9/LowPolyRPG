using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalDes : MonoBehaviour {
    private ParticleSystem[] particleSystems;  
  
    void Start()  
    {  
        particleSystems = GetComponentsInChildren<ParticleSystem>();  
    }  
      
    void Update ()  
    {  
        bool allStopped = true;  
  
        foreach (ParticleSystem ps in particleSystems)  
        {  
            if (!ps.isStopped)  
            {  
                allStopped = false;  
            }  
        }  
  
        if (allStopped) Destroy(gameObject);  
    }  
}
