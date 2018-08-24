using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可拾取装备
/// </summary>
public class PickUpItem : Interactable
{
    public override void Interact()
    {
        Debug.Log("item interact!");
    }

}
