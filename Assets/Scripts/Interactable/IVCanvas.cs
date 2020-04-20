using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IVCanvas : MonoBehaviour {

    public Image imageHolder;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
    public void Activate(Sprite image){
        GameManager.instance.currentNode.SetReachableNodesCollider(false);
        GameManager.instance.currentNode.coll.enabled = false;
        gameObject.SetActive(true);
        imageHolder.sprite = image;

    }

    public void Close(){
        GameManager.instance.currentNode.SetReachableNodesCollider(true);
        GameManager.instance.currentNode.coll.enabled = true;
        gameObject.SetActive(false);
        imageHolder.sprite = null;
    }
}
