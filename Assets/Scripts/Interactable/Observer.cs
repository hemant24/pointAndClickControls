using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Interactable {

	public override void Interact()
	{
        GameManager.instance.obsCamera.Activate(gameObject);
        /*
        GameObject item = Instantiate(gameObject);
        item.transform.SetParent(GameManager.instance.obsCamera.rig);
        item.transform.localPosition = Vector3.zero;
        item.transform.GetChild(0).localPosition = Vector3.zero;
        GameManager.instance.obsCamera.model = item.transform;
        GameManager.instance.obsCamera.gameObject.SetActive(true);
        */
	}
}
