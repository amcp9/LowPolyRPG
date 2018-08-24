using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour 
{
    CharacterStats stats;

    Vector3 pos;

	private void Start()
	{
        stats = GetComponent<Player>().characterStats;
	}

    public void ConsumeItem(Item item)
    {
        pos.x = transform.position.x;
        pos.y = transform.position.y + 2;
        pos.z = transform.position.z;
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Effect/" + item.ObjectSlug),pos,transform.rotation);
        if(item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        itemToSpawn.GetComponent<IConsumable>().Consume();
    }

}
