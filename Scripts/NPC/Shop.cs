using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable {
    public GameObject ShopUI;
    bool isOpen = false;
	public override void Interact()
	{
        Debug.Log("asdasd");
        ShopUI.gameObject.SetActive(true);
        isOpen = true;
	}

    public void Close()
    {
        ShopUI.SetActive(false);
        isOpen = false;
    }
}
