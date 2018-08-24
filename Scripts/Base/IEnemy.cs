using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人接口
/// </summary>
public interface IEnemy
{
    /// <summary>
    /// 受伤函数
    /// </summary>
    void TakeDamage(int amount);
    /// <summary>
    /// 攻击函数
    /// </summary>
    void PerformAttack();
}