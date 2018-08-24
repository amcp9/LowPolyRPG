using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileWeapon 
{
    Transform ProjectlitSpawn { get; set; }
    void CastProjectile();
}
