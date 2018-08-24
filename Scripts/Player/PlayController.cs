using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayController : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    public GameObject ClickEffect;

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
