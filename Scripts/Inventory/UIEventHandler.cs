using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI事件驱动器,在游戏逻辑与UI交互之间,负责发布能引起UI变化的事件,由对应的UI面板监听
/// </summary>
public class UIEventHandler : MonoBehaviour {


    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;    //“玩家获得新物品”事件
    public static event ItemEventHandler OnItemEquipped;            //“玩家装备新物品”事件

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnstatsChanged;           //“玩家属性发生变化”事件

    /// <summary>
    /// 发布“玩家获得新物品”事件
    /// </summary>
    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    /// <summary>
    /// 发布“玩家装备新物品”事件
    /// </summary>
    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    /// <summary>
    /// 发布“玩家属性发生变化”事件
    /// </summary>
    public static void StatsChanged()
    {
        OnstatsChanged();
    }
}
