using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// 物品类，所有装备或武器或消耗品都属于物品
/// </summary>
public class Item 
{   public enum ItemTypes { Weapon, Consumeable, Quest, Ablity }            //该物品种类
    public List<BaseStat> stats { get; set; }                               //该物品的属性
    public string ObjectSlug { get; set; }                                  //物品标识符，游戏内部根据标识符区分不同的物品
    public string Description { get; set; }                                 //该物品描述
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }                                 //该物品种类
    public string ActionName { get; set; }                                  //该物品的互动名称
    public string ItemName { get; set; }                                    //该物品的名称
    public bool ItemModifier { get; set; }                                  //该物品是否带来属性增益


    public Item(List<BaseStat> _Stats,string _ObjectSlug)
    {
        this.stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }
    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> _Stats, string _ObjectSlug,string _Description,ItemTypes _ItemType,string _ActionName,string _ItemName,bool _ItemModifier)
    {
        this.stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
        this.Description = _Description;
        this.ItemType = _ItemType;
        this.ActionName = _ActionName;
        this.ItemName = _ItemName;
        this.ItemModifier = _ItemModifier;

    }
}
