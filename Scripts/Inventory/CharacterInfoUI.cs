using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 个人信息UI面板脚本，显示玩家当前属、当前装备武器属性
/// </summary>
public class CharacterInfoUI : MonoBehaviour
{
    [SerializeField] private Player player;
    //玩家属性
    private List<Text> playerStatTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    //已装备武器属性
    [SerializeField] private Sprite defaultWeaponSprite;
    [SerializeField] private PlayerWeaponController playerWeaponController;
    [SerializeField] private Text weaponStatPrefab;
    [SerializeField] private Transform weaponStatPanel;
    [SerializeField] private Text weaponNameText;
    [SerializeField] private Image weaponIcon;
    [SerializeField] private List<Text> weaponStatText = new List<Text>();


    private void Start()
    {
        playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnstatsChanged += UpdateStats;                   //UI事件驱动
        UIEventHandler.OnItemEquipped += UpdateEquipWeapon;             //UI事件驱动
        IniTializeStats();
    }
    /// <summary>
    /// 显示玩家出生时基础属性
    /// </summary>
    void IniTializeStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }

    /// <summary>
    /// 更新玩家属性信息，每装备新的武器时，执行一次
    /// </summary>
    void UpdateStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts[i].text = player.characterStats.stats[i].StatName + ": " + player.characterStats.stats[i].GetCalculatedStatValue().ToString();
        }
    }

    /// <summary>
    /// 更换武器时，更新武器UI信息
    /// </summary>
    void UpdateEquipWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        for (int i = 0; i < item.stats.Count; i++)
        {
            weaponStatText.Add(Instantiate(weaponStatPrefab));
            weaponStatText[i].transform.SetParent(weaponStatPanel);
            weaponStatText[i].text = item.stats[i].StatName + ": " + item.stats[i].BaseValue.ToString();

        }
        UpdateStats();
    }
}
