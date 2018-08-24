using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

/// <summary>
/// 基础属性类
/// </summary>
public class BaseStat 
{
    public enum BaseStatType{ Power , Toughness , AttackSpeed }     //每一个实例代表的基础属性


    public List<StatBonus> BaseAdditives { get; set; }              //拓展集合，用户日后RPG对该属性进行拓展
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }                      //该属性所属的枚举类型
    public int BaseValue { get; set; }                              //该属性的基础值
    public string StatName { get; set; }                            //该属性的名称
    public string StatDescription { get; set; }                     //该属性的具体描述
    public int FinalValue { get; set; }                             //该属性算上拓展集合后表现出来的最终值



    /// <summary>
    /// 构造函数（非预设属性） <see cref="T:BaseStat"/> class.
    /// </summary>
    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }

    /// <summary>
    /// 构造函数（预设属性） <see cref="T:BaseStat"/> class.
    /// </summary>
    /// <param name="statType">Stat type.</param>
    /// <param name="baseValue">Base value.</param>
    /// <param name="statName">Stat name.</param>
    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    /// <summary>
    /// 在拓展集合中添加一条新的拓展数据
    /// </summary>
    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }
    /// <summary>
    /// 在拓展集合中移除一条新的拓展数据
    /// </summary>
    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    /// <summary>
    /// 获取该属性的最终值
    /// </summary>
    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}
