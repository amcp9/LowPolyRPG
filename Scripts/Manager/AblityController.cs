using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AblityController : MonoBehaviour {
    public static AblityController Instance;
    GameObject AblityLocal;
    public Image AblityIma;
    public Image CDIma;


    public float CollDownTime = 5f;
    public float CoolingTime;
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

	public void EquipAblity(Item item)
    {

            if (AblityLocal.transform.childCount > 0)
            {
                AblityLocal.GetComponent<BoradCastAblity>().Board();
            }
            GameObject NewAblity = Instantiate(Resources.Load<GameObject>("Weapons/Ablity/" + item.ObjectSlug), AblityLocal.transform.position, AblityLocal.transform.rotation);
            AblityIma.gameObject.SetActive(true);
            Debug.Log(item.ObjectSlug);
            AblityIma.sprite = Resources.Load<Sprite>("UI/Icons/" + item.ObjectSlug);
            NewAblity.transform.SetParent(AblityLocal.transform);
       
    }
}
