using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    public Player player;

    Transform spawnProjectile;
    Transform bulletSpawn;
    Item currentlyEquippedItem;
    IWeapon equippedWeapon;
    CharacterStats characterStats;
    private void Start()
    {
        //获取投射武器的投射点
        spawnProjectile = transform.Find("ProjectileSpawn");
        //get bullet spawn point
        bulletSpawn = transform.Find("BulletSpawn");
        characterStats = GetComponent<Player>().characterStats;
    }
    public void EquipWeapon(Item itemToEquip)
    {
        //find that whether the player had weapon,and delete it
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(equippedWeapon.Stats);
            Destroy(EquippedWeapon.transform.gameObject);
            //InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
        }
            //生成prefab
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug) ,
            playerHand.transform.position , playerHand.transform.rotation);

        //get the IWeapon interface to get it power or sth
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        //find that whether projectile weapon
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            //获取投射武器的投射点
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectlitSpawn = spawnProjectile;
        }
        //find that whether gun weapon
        if(EquippedWeapon.GetComponent<IGun>() != null)
        {
            EquippedWeapon.GetComponent<IGun>().ProjectlitSpawn = bulletSpawn;
        }
        //设定武器为子物体
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.stats;
        currentlyEquippedItem = itemToEquip;
        //在character统计中给角色相应的power最后一个数组增加一行新元素
        characterStats.AddStatBonus(itemToEquip.stats);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();

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

    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2) +
            Random.Range(2, 8);
        damageToDeal += CalculateCrit(damageToDeal);
        Debug.Log("Damage : " + damageToDeal);
        return damageToDeal;
    }
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
