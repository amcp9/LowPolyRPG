﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 奖励控制器,负责金币奖励的实例化
/// </summary>
public class RewordController : MonoBehaviour
{
    public RectTransform PlayerUICoinPenal;

    private RewardUIItem RewardUIItem;
    private Player player;
    bool isRewarUIOpen = false;
	private void Start()
	{
        RewardUIItem = Resources.Load<RewardUIItem>("UI/Reward");
        player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
	}

	private void Update()
	{
        if(isRewarUIOpen)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }
        }

        if(PlayerUICoinPenal.childCount <= 0)
        {
            ClosePanel();
        }

	}

    /// <summary>
    /// 关闭奖励面板
    /// </summary>
    public void ClosePanel()
    {
        foreach(Transform child in PlayerUICoinPenal)
        {
            Destroy(child.gameObject);
        }
        PlayerUICoinPenal.gameObject.SetActive(false);
        isRewarUIOpen = false;
    }
    /// <summary>
    /// 激活奖励面板
    /// </summary>
	public void InsRewardUI()
    {
        int Count = Random.Range(10, 50);
        isRewarUIOpen = true;
        PlayerUICoinPenal.gameObject.SetActive(true);
        RewardUIItem rewardUIItem = Instantiate(RewardUIItem);
        rewardUIItem.transform.SetParent(PlayerUICoinPenal);
        rewardUIItem.coins = Count;
        rewardUIItem.transform.Find("Text").GetComponent<Text>().text = Count.ToString();
    }
}
