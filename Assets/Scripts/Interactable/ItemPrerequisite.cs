using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPrerequisite : Prerequisite {

    public Item item;

    public override bool IsCompleted()
    {
        if(item != null && GameManager.instance.inventory != null)
            return item.itemName.Equals(GameManager.instance.inventory.itemName);
        return false;
    }

   
}
