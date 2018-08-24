using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    /// <summary>
    /// 用于处理基础人物能力如：力量，生命，防御等
    /// </summary>


    
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int power, int toughness, int attackSpeed)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Power,power,"Power"),
            new BaseStat(BaseStat.BaseStatType.Toughness,toughness,"Def"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed,attackSpeed,"Speed")
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }


    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            //找出含有名字相同的能力的装备并加上，比如power,这样只会在stats[0]中的 BaseAdditives数组增加一条
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            //找出含有名字相同的能力的装备并移除
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

}
