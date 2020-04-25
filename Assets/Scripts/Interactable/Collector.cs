using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Interactable {

    public Item item;

  
	public override void Interact()
	{
        GameManager.instance.AddToInventory(item);
	}
}
