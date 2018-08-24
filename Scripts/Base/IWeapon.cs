using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器装备接口
/// </summary>
public interface IWeapon
{
    List<BaseStat> Stats { get; set; }  //该武器自身的属性
    int CurrentDamage{ get; set; }      //武器伤害值
    void PerformAttack(int damage);     //普通攻击
    void PerformSpecialAttack();        //特殊攻击

}