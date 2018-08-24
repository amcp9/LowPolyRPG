using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArround : MonoBehaviour {
    GameObject fireEffect;
     Transform playerPos;

    private Vector3 LastPos;
    private bool isEffectOpen = false;
    private bool isPlayerMoving = false;

    public List<GameObject> effects = new List<GameObject>();

    GameObject effect_1, effect_2, effect_3, effect_4;

	private void Start()
	{
        fireEffect = Resources.Load<GameObject>("Effect/Fire_A");
	}
	void Update () 
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        if (Input.GetKeyDown(KeyCode.R) && !AblityController.Instance.isCD)
        {
            AblityController.Instance.isCD = true;
            AblityController.Instance.CoolingTime = AblityController.Instance.CollDownTime;
            InsTheEffect();
            isEffectOpen = true;
        }
        if (playerPos.position != LastPos)
        {
            isPlayerMoving = true;
        }
        else isPlayerMoving = false;
        Debug.Log(isPlayerMoving);
        if(isPlayerMoving && isEffectOpen )
        {

        }
        if(isEffectOpen && !isPlayerMoving)
        {
                foreach (GameObject obj in effects)
                {
                    obj.transform.SetParent(playerPos);
                    obj.transform.RotateAround(playerPos.position, playerPos.up, 5);
                }

        }
        LastPos = playerPos.position;
        AblityController.Instance.CoolingTime -= Time.deltaTime;
	}
    public void InsTheEffect()
    {
         effect_1 = Instantiate(fireEffect, new Vector3(playerPos.position.x, playerPos.position.y+2, playerPos.position.z+3), fireEffect.transform.rotation);
         effect_2 = Instantiate(fireEffect, new Vector3(playerPos.position.x, playerPos.position.y+2, playerPos.position.z-3), fireEffect.transform.rotation);
         effect_3 = Instantiate(fireEffect, new Vector3(playerPos.position.x+3, playerPos.position.y+2, playerPos.position.z), fireEffect.transform.rotation);
         effect_4 = Instantiate(fireEffect, new Vector3(playerPos.position.x-3, playerPos.position.y+2, playerPos.position.z), fireEffect.transform.rotation);

        effects.Add(effect_1);
        effects.Add(effect_2);
        effects.Add(effect_3);
        effects.Add(effect_4);
    }

    public void DestoryME()
    {
        Destroy(gameObject);
    }
}
