using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        PlayerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }
    //选中物品时右侧详细
    public void SetItemDetails(Item item,Button selectedButton)
    {
        inventoryUIDDetailsPanel.SetItem(item, selectedButton);
    }
    //装备能力
    public void EquipAblity(Item itemToEquip)
    {
        ablityController.EquipAblity(itemToEquip);
    }
    //UI调用
    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }
    //UI调用
    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }
}
