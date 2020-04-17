using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Prop))]
public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.enabled = false;
	}

    public void Interact(){
        Debug.Log("interacting with " + name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
