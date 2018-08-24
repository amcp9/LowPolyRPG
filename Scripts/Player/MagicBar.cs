using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour {
    private Image bar;
    public Player player;

    private void Start()
    {
        bar = GetComponent<Image>();
    }
    private void Update()
    {
        bar.fillAmount = player.currentMagic / player.maxMagic;
    }
}
