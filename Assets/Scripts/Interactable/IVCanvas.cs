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
        gameObject.SetActive(true);
        imageHolder.sprite = image;

    }
}
