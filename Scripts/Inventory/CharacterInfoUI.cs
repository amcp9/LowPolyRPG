using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoUI : MonoBehaviour {
    [SerializeField] private Player player;
    //Character Stats
    private List<Text> playerStatTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    //EquippedWeaponStats
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
        UIEventHandler.OnstatsChanged += UpdateStats;
        UIEventHandler.OnItemEquipped += UpdateEquipWeapon;
        IniTializeStats();
	}

    void IniTializeStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }
    void UpdateStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count;i++)
        {
            playerStatTexts[i].text = player.characterStats.stats[i].StatName +": "+player.characterStats.stats[i].GetCalculatedStatValue().ToString();
        }
    }

    void UpdateEquipWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        for (int i = 0; i < item.stats.Count; i++)
        {
            weaponStatText.Add(Instantiate(weaponStatPrefab));
            weaponStatText[i].transform.SetParent(weaponStatPanel);
            weaponStatText[i].text =item.stats[i].StatName +": "+item.stats[i].BaseValue.ToString();
       
        }
        UpdateStats();
    }
}
