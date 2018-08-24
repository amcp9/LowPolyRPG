using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 枪械武器接口
/// </summary>
public interface IGun 
{
	Transform ProjectlitSpawn { get; set; } //枪械子弹初始化的Transform
    void PerformAttack();                   //攻击函数
}
