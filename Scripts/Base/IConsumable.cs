using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消耗品接口
/// </summary>
public interface IConsumable
{
    /// <summary>
    /// 执行不修改属性的消耗品
    /// </summary>
    void Consume();

    /// <summary>
    /// 执行修改属性的消耗品
    /// </summary>
    void Consume(CharacterStats stats);

}
