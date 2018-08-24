using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rewards : Interactable 
{
	public override void Interact()
	{
        GameObject.Find("RewardController").GetComponent<RewordController>().InsRewardUI();
        GameObject player = GameObject.Find("Player");
        player.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        //点击粒子特效后两秒消除该特效
        Invoke("des",2f);
	}

	private void des()
	{
        gameObject.SetActive(false);
	}
}
