using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    private Image Healthbar;
    public Player player;

	private void Start()
	{
        Healthbar = GetComponent<Image>();
	}
	private void Update()
	{
        Healthbar.fillAmount = player.currentHealth / player.maxHealth;
	}
}
