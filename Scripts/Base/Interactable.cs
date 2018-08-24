using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;

    private bool interacted = true;
    private void Start()
    {
        //注册事件
        MouseManager.Instance.OnLeftClick += MoveToInteraction;
        //获取player的navmesh agent设定目的地让其移动
        playerAgent = GameObject.FindGameObjectWithTag(TagManager.Instance.player).GetComponent<NavMeshAgent>();
    }
	public virtual void MoveToInteraction(GameObject go)
    {
        if (go == gameObject)
        {
            //点中可交互物品，设定停止距离（防止重叠），设定目的地，标识符更改
            playerAgent.stoppingDistance = 3f;
            playerAgent.destination = this.transform.position;
            interacted = false;
        }
        else
        {
            interacted = true;
        }
    }
    private void Update()
    {
        //判断是否有agent和判断是否正在计算路径
        if (playerAgent != null && !playerAgent.pathPending)
        {
            //判断与目标的距离是否在停止距离之内（是否到达）
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                if (!interacted)
                {
                    Interact();
                    interacted = true;
                }
            }
        }
    }
    //定义好一个虚互动方法方便子类重写
    public virtual void Interact()
    {
        Debug.Log("base interact!");
    }
}
