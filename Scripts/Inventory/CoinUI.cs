using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour {
    private Player player;
    public Text coinText;
	private void Start()
	{
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}

	private void Update()
	{
        coinText.text = player.Coins.ToString();
	}
}
