using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIItem : MonoBehaviour
{
    public int coins;
    public void GivePlayerCoins()
    {
        GameObject.Find("Player").GetComponent<Player>().Coins += coins;
        Destroy(gameObject);
    }
}
