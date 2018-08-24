using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 特殊技能控制器,负责装载技能,维护主角的特殊技能cd
/// </summary>
public class AblityController : MonoBehaviour {
    public static AblityController Instance;
    GameObject AblityLocal;             //控制特殊技能的场景物体
    public Image AblityIma;             //特殊技能的Icon
    public Image CDIma;                 //进入CD的Icon


    public float CollDownTime = 5f;     //冷却时间
    public float CoolingTime;           //已经进行的冷却时间
    public bool isCD = false;
	private void Start()
	{
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        AblityLocal = GameObject.Find("Ablity");
	}

	private void Update()
	{
        CDIma.fillAmount = CoolingTime/CollDownTime;
        if(CoolingTime <= 0)
        {
            CoolingTime = 0;
            isCD = false;
        }
	}
    /// <summary>
    /// 装载新技能
    /// </summary>
	public void EquipAblity(Item item)
    {
        //有且仅有一个技能
        if (AblityLocal.transform.childCount > 0)
        {
            AblityLocal.GetComponent<BoradCastAblity>().Board();
        }
        //加载技能
        GameObject NewAblity = Instantiate(Resources.Load<GameObject>("Weapons/Ablity/" + item.ObjectSlug), AblityLocal.transform.position, AblityLocal.transform.rotation);
        AblityIma.gameObject.SetActive(true);
        //加载技能对应的Icon
        AblityIma.sprite = Resources.Load<Sprite>("UI/Icons/" + item.ObjectSlug);
        NewAblity.transform.SetParent(AblityLocal.transform);
       
    }
}
