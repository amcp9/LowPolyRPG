using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家武器管理单例，控制新武器的装载，武器的攻击，武器带来的伤害数值
/// </summary>
public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;                   //玩家手部位置，实例化武器所处的位置
    public GameObject EquippedWeapon { get; set; }  //当前正在穿戴的武器
    public Player player;                           //玩家脚本

    Transform spawnProjectile;                      //法杖武器法球生成点
    Transform bulletSpawn;                          //枪械武器子弹生成点
    Item currentlyEquippedItem;                     //当前装备的Item脚本
    IWeapon equippedWeapon;                         //当前装备的Iweapon接口
    CharacterStats characterStats;                  //玩家属性
    private void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        bulletSpawn = transform.Find("BulletSpawn");
        characterStats = GetComponent<Player>().characterStats;
    }
    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)                                 //判断当前是否有武器
        {
            characterStats.RemoveStatBonus(equippedWeapon.Stats);   //移除该武器的属性增益
            Destroy(EquippedWeapon.transform.gameObject);
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug) ,
        playerHand.transform.position , playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();    //获得武器接口
        //判断是否法杖武器
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            //设定法球生成位置
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectlitSpawn = spawnProjectile;
        }
        //判断是否枪械武器
        if(EquippedWeapon.GetComponent<IGun>() != null)
        {
            //设置子弹生成位置
            EquippedWeapon.GetComponent<IGun>().ProjectlitSpawn = bulletSpawn;
        }
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.stats;
        currentlyEquippedItem = itemToEquip;
        characterStats.AddStatBonus(itemToEquip.stats);             //实现武器带来的属性增益
        UIEventHandler.ItemEquipped(itemToEquip);                   //UI事件驱动
        UIEventHandler.StatsChanged();                              //UI事件驱动

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PerformWeaponAttack();
            player.TakeMagic(20);
        }
    }
    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }
    /// <summary>
    /// 计算本次攻击的伤害
    /// </summary>
    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2) +
            Random.Range(2, 8);
        damageToDeal += CalculateCrit(damageToDeal);
        Debug.Log("Damage : " + damageToDeal);
        return damageToDeal;
    }
    /// <summary>
    /// 根据暴击率判断本次攻击是否暴击
    /// </summary>
    private int CalculateCrit(int damage)
    { 
        if(Random.value >= .1f)
        {
            int critDamage = (int)(damage * Random.Range(.25f, .5f));
            return critDamage;
        }
        return 0;
    }
        

}
