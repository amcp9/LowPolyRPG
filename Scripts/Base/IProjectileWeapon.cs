using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 法杖武器接口
/// </summary>
public interface IProjectileWeapon 
{
    Transform ProjectlitSpawn { get; set; } //法杖武器的法球生成位置
    void CastProjectile();                  //法球的射击函数
}
