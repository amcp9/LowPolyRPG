using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消耗品控制器
/// </summary>
public class ConsumableController : MonoBehaviour 
{
    CharacterStats stats;

    Vector3 pos;

	private void Start()
	{
        stats = GetComponent<Player>().characterStats;
	}

    /// <summary>
    /// 执行消耗品的消耗
    /// </summary>
    public void ConsumeItem(Item item)
    {
        //生成的粒子特效的位置
        pos.x = transform.position.x;
        pos.y = transform.position.y + 2;
        pos.z = transform.position.z;
        //实例化该特效
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Effect/" + item.ObjectSlug),pos,transform.rotation);
        //该消耗品是否能带来属性增益
        if(item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        itemToSpawn.GetComponent<IConsumable>().Consume();
    }

}
