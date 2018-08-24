using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生命药水
/// </summary>
public class Potion_Log : MonoBehaviour, IConsumable
{
    private Player player;
    public void Consume()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.currentHealth += 30;
    }

    public void Consume(CharacterStats stats)
    {
        Debug.Log("You drank a potion");
    }
}
