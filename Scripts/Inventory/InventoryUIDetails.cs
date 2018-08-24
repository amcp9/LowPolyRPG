using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {

    Item item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText;

    public Text statText;
	private void Start()
	{
        itemNameText = transform.Find("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.Find("Item_DescriptionText").GetComponent<Text>();
        itemInteractButton = transform.Find("Button").GetComponent<Button>();
        itemInteractButtonText = itemInteractButton.transform.Find("Text").GetComponent<Text>();
        gameObject.SetActive(false);
	}
	public void SetItem(Item item,Button selectedButton)
    {
        gameObject.SetActive(true);

        statText.text = "";
        if(item.stats != null)
        {
            foreach(BaseStat stat in item.stats)
            {
                statText.text += stat.StatName + ": " +stat.BaseValue + "\n";
            }
        }
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractButtonText.text = item.ActionName;

        itemInteractButton.onClick.AddListener(OnItemInteract);

    }

    public void OnItemInteract()
    { 
        if(item.ItemType == Item.ItemTypes.Consumeable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            //Destroy(selectedItemButton.gameObject);
            InventoryController.Instance.EquipItem(item);

        }else if (item.ItemType == Item.ItemTypes.Ablity)
        {
            InventoryController.Instance.EquipAblity(item);
        }
        //item = null;
        gameObject.SetActive(false);

    }
}
