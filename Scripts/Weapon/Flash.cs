using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flash : MonoBehaviour {
    GameObject player;
    GameObject Effect;
    Vector3 pos;
    Vector3 newPlayerPos;
	private void Start()
	{
        Effect = Resources.Load<GameObject>("Effect/BladeStorm");
        player = GameObject.FindWithTag("Player").gameObject;
	}
	void Update () {
        if(Input.GetKeyDown(KeyCode.R)&& !AblityController.Instance.isCD)
        {

            AblityController.Instance.isCD = true;
            AblityController.Instance.CoolingTime = AblityController.Instance.CollDownTime;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.transform.tag == TagManager.Instance.Ground)
            {
                pos.x = hit.point.x;
                pos.y = hit.point.y + 2f;
                pos.z = hit.point.z;
                newPlayerPos = hit.point;
                Instantiate(Effect, pos, Quaternion.identity);
                Invoke("FlashToPos", 1.5f);
            }
        }

            AblityController.Instance.CoolingTime -= Time.deltaTime;
	}

    private void FlashToPos()
    {
        player.transform.position = newPlayerPos;
        player.GetComponent<NavMeshAgent>().SetDestination(newPlayerPos);
    }
    public void DestoryME()
    {
        Destroy(gameObject);
    }
}
