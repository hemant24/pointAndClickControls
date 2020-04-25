using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {
    
    Text displayText;
 

	private void Awake()
	{
        displayText = GetComponent<Text>();
        displayText.text = "Item Held: None";
	}

	private void Start()
	{
        GameManager.instance.ItemCollected += OnItemCollected;
	}

	private void OnItemCollected(Item item){
        displayText.text = "Item Held: " + item.itemName;
    }
}
