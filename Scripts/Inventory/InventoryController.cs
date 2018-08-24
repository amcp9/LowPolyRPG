using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背包系统单例,同时也是中介者模式间接调用各大控制器
/// </summary>
public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    [HideInInspector]
    public PlayerWeaponController playerWeaponController;
    [HideInInspector]
    public ConsumableController consumableController;
    public InventoryUIDetails inventoryUIDDetailsPanel;
    public AblityController ablityController;
    public List<Item> PlayerItems = new List<Item>();

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;   
        }
        ablityController = GetComponent<AblityController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        GiveItem("sword");
        GiveItem("staff");
        //GiveItem("Gun");
        GiveItem("potion_log");
        GiveItem("firestaff");
        GiveItem("fire_Arround_mod");
        GiveItem("Flash");
    }

    /// <summary>
    /// 给予玩家物品
    /// </summary>
    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        PlayerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    /// <summary>
    /// 选中物品时，右侧显示详细信息
    /// </summary>
    public void SetItemDetails(Item item,Button selectedButton)
    {
        inventoryUIDDetailsPanel.SetItem(item, selectedButton);
    }

    /// <summary>
    /// 装备新能力
    /// </summary>
    public void EquipAblity(Item itemToEquip)
    {
        ablityController.EquipAblity(itemToEquip);
    }

    /// <summary>
    /// 装备武器，由背包UI调用
    /// </summary>
    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    /// <summary>
    /// 消耗品消耗，由背包UI调用
    /// </summary>
    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }
}
