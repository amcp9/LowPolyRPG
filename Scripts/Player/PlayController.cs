using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 玩家移动控制器，负责响应鼠标点击与调用NavMesh移动
/// </summary>
public class PlayController : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    public GameObject ClickEffect;      //点击特效

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        MouseManager.Instance.OnLeftClick += ReceiveLeft;
    }

    void ReceiveLeft(GameObject go)
    {
        if (go.tag == TagManager.Instance.Ground)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Instantiate(ClickEffect, hit.point, Quaternion.identity);
            playerAgent.stoppingDistance = 0f;
            playerAgent.SetDestination(hit.point);
        }
        if (go.tag == "Enemy")
        {
            transform.LookAt(go.transform);
        }
    }
}
